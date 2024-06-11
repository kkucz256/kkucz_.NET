package org.example;

import java.util.List;
import java.util.Objects;

public class QuizEngine {
    public List<Question> questions;
    private int question_number = 0;
    private int score = 0;
    public QuizEngine(List<Question> question_list)
    {
        this.questions = question_list;
    }

    public String next_question() {
        question_number++;
        if (question_number < questions.size()) {
            int question_to_print = question_number + 1;
            return "Q no." + question_to_print + ": " + questions.get(question_number).getQuestion();
        } else {
            return null;
        }
    }

    public String first_question(){
        int question_to_print = question_number + 1;
        return "Q no."+ question_to_print +": "+ questions.get(question_number).getQuestion();
    }

    public boolean check_answer(String user_answer) {
        String correct_ans = questions.get(question_number).getAnswer();
        if (Objects.equals(correct_ans, user_answer)) {
            score++;
            return true;
        } else {
            return false;
        }
    }

    public boolean still_has_questions() {
        return question_number < questions.size();
    }

    public int getScore() {
        return score;
    }
}
