package org.example;
import com.fasterxml.jackson.databind.JsonNode;
import org.junit.Assert;
import org.junit.jupiter.api.Test;

import java.io.IOException;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import static org.junit.jupiter.api.Assertions.*;

public class Tests {
    
    @Test
    public void check_if_has_data() throws IOException, InterruptedException {
        Data data = new Data();
        List<JsonNode> questions = data.fetch_questions(1, "boolean");
        assertTrue(!questions.isEmpty());
    }


    @Test
    public void test_game_creation() {
        User user = new User();
        Date now = new Date();
        float score = 95.5f;

        Game game = new Game();
        game.setUser(user);
        game.setCreatedAt(now);
        game.setScore(score);

        assertEquals(user, game.getUser());
        assertEquals(now, game.getCreatedAt());
        assertEquals(score, game.getScore(), 0.001);
    }

    @Test
    public void test_relation() {
        User user = new User();
        Game game = new Game();
        game.setUser(user);

        assertEquals(user, game.getUser());
    }

    @Test
    public void test_user_creation() {
        String email = "mail@mail.com";
        String password = "password";
        String nickname = "user";

        User user = new User();
        user.setEmail(email);
        user.setPassword(password);
        user.setNickname(nickname);

        assertEquals(email, user.getEmail());
        assertNotNull(user.getPassword());
        assertEquals(nickname, user.getNickname());
    }

    @Test
    public void test_hashing() {
        String plainTextPassword = "password";
        String expectedHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8";

        User user = new User();
        user.setPassword(plainTextPassword);

        assertEquals(expectedHash, user.getPassword());
    }

    @Test
    public void test_question(){
        Question question = new Question("Q", "Ans");
        assertEquals("Q", question.getQuestion());
        assertEquals("Ans", question.getAnswer());
    }

    @Test
    public void test_fist_question() {
        List<Question> questions = Arrays.asList(
                new Question("Question1", "True"));
        QuizEngine quizEngine = new QuizEngine(questions);
        assertEquals("Q no.1: Question1", quizEngine.first_question());
        assertTrue(quizEngine.check_answer("True"));
        assertEquals(1, quizEngine.getScore());
        assertTrue(quizEngine.still_has_questions());
    }

    @Test
    public void test_next_question() {
        List<Question> questions = Arrays.asList(
                new Question("Question1", "True"), new Question("Question2", "False"));
        QuizEngine quizEngine = new QuizEngine(questions);
        quizEngine.next_question();
        assertEquals("Q no.2: Question2", quizEngine.first_question());
        assertTrue(quizEngine.check_answer("False"));
        assertEquals(1, quizEngine.getScore());
        assertTrue(quizEngine.still_has_questions());
    }

    @Test
    public void test_no_questions() {
        List<Question> questions = Arrays.asList();
        QuizEngine quizEngine = new QuizEngine(questions);

        assertFalse(quizEngine.still_has_questions());
        assertEquals(0, quizEngine.getScore());
    }






}