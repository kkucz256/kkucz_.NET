package org.example;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.List;
import java.util.stream.Collectors;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.node.ObjectNode;
import org.apache.commons.text.StringEscapeUtils;

public class Data {
    private static final String API_URL = "https://opentdb.com/api.php";

    public static List<JsonNode> fetch_questions(int amount, String type) throws IOException, InterruptedException {
        HttpClient client = HttpClient.newHttpClient();
        String uri = String.format("%s?amount=%d&type=%s", API_URL, amount, type);
        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(uri))
                .GET()
                .build();

        HttpResponse<String> response;
        try {
            response = client.send(request, HttpResponse.BodyHandlers.ofString());
        } catch (IOException | InterruptedException e) {
            System.err.println("Error sending request to API: " + e.getMessage());
            throw e;
        }

        if (response.statusCode() != 200) {
            String errorMsg = "Failed to fetch data from API, HTTP status code: " + response.statusCode();
            System.err.println(errorMsg);
            throw new IOException(errorMsg);
        }

        ObjectMapper objectMapper = new ObjectMapper();
        JsonNode jsonNode;
        try {
            jsonNode = objectMapper.readTree(response.body());
        } catch (IOException e) {
            System.err.println("Error parsing JSON response: " + e.getMessage());
            throw e;
        }

        JsonNode resultsNode = jsonNode.get("results");
        if (resultsNode == null || !resultsNode.isArray()) {
            String errorMsg = "Invalid response from API: 'results' node is missing or not an array";
            System.err.println(errorMsg);
            throw new IOException(errorMsg);
        }

        List<JsonNode> questions;
        try {
            questions = objectMapper.readValue(resultsNode.toString(), new TypeReference<List<JsonNode>>() {});
        } catch (IOException e) {
            System.err.println("Error converting JSON results to list: " + e.getMessage());
            throw e;
        }

        questions = questions.stream().map(Data::process_question).collect(Collectors.toList());

        return questions;
    }

    private static JsonNode process_question(JsonNode node) {
        if (node.isObject()) {
            JsonNode questionNode = node.get("question");
            if (questionNode != null && questionNode.isTextual()) {
                String questionText = questionNode.asText();
                String without_html = StringEscapeUtils.unescapeHtml4(questionText);
                String formatted_text = without_html.replace("\\", "");
                ((ObjectNode) node).put("question", formatted_text);
            }
        }
        return node;
    }
}
