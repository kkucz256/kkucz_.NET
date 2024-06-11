package org.example;

import com.fasterxml.jackson.databind.JsonNode;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) throws IOException, InterruptedException {
        List<Question> quizQuestions = new ArrayList<>();
        Data data = new Data();
        List<JsonNode> questions = data.fetch_questions(10, "boolean");
        for (JsonNode questionNode : questions) {
            Question question = new Question(questionNode.get("question").asText(), questionNode.get("correct_answer").asText());
            quizQuestions.add(question);
        }

        QuizEngine quizEngine = new QuizEngine(quizQuestions);
        Scanner scanner = new Scanner(System.in);
        System.out.println("Type 'True' or 'False'.");
        System.out.println(quizEngine.first_question());

        while (quizEngine.still_has_questions()) {
            String userAnswer = scanner.nextLine();
            if (quizEngine.check_answer(userAnswer.toLowerCase())) {
                System.out.println("Correct!");
            } else {
                System.out.println("Wrong.");
            }
            String nextQuestion = quizEngine.next_question();
            if (nextQuestion != null) {
                System.out.println(nextQuestion);
            }
        }

        System.out.println("The end of quiz! Final score: " + quizEngine.getScore() + "/" + quizQuestions.size());
    }
}