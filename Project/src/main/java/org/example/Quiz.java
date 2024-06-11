package org.example;

import org.hibernate.Session;
import org.hibernate.Transaction;
import org.hibernate.query.Query;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;
import javax.swing.*;
import java.awt.event.ActionListener;
import java.text.DecimalFormat;
import java.util.Date;

public class Quiz {
    private JPanel quizpanel;
    private JTextArea textArea1;
    private JButton true_btn;
    private JButton false_btn;
    private JLabel current_score;
    private JLabel ratio;
    private JButton backButton;
    public QuizEngine quiz_engine;
    private int question_amount;
    private User currentUser;
    public boolean resultsaved = false;

    public Quiz() {

    }

    public JPanel getQuizPanel() {
        return quizpanel;
    }
    public void update_score() {
        current_score.setText("Current score: " +quiz_engine.getScore() + "/" + question_amount);
    }

    public void setRatio() {
        if (currentUser != null) {
            Session session = HibernateUtil.getSessionFactory().openSession();
            Transaction transaction = null;

            try {
                transaction = session.beginTransaction();

                CriteriaBuilder builder = session.getCriteriaBuilder();
                CriteriaQuery<Double> criteriaQuery = builder.createQuery(Double.class);
                Root<Game> root = criteriaQuery.from(Game.class);

                criteriaQuery.select(builder.avg(root.get("score"))).where(builder.equal(root.get("user"), currentUser));

                Query<Double> query = session.createQuery(criteriaQuery);
                Double averageScore = query.uniqueResult();

                if (averageScore != null) {
                    String formattedAverageScore = String.format("%.2f", averageScore);

                    ratio.setText("Average score: " + formattedAverageScore + "%");
                } else {
                    ratio.setText("No games played yet");
                }

                transaction.commit();
            } catch (Exception ex) {
                if (transaction != null) {
                    transaction.rollback();
                }
                ex.printStackTrace();
                JOptionPane.showMessageDialog(null, "Error occurred while calculating average score: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
            } finally {
                session.close();
            }
        }
    }

    public void show_question(String text){
        textArea1.setText(text);
    }
    public void setTrueButtonAction(ActionListener actionListener) {
        true_btn.addActionListener(actionListener);
    }
    public void setFalseButtonAction(ActionListener actionListener) {
        false_btn.addActionListener(actionListener);
    }
    public void setBackButtonAction(ActionListener actionListener) {
        backButton.addActionListener(actionListener);
    }

    public void end_quiz() {
        if (!resultsaved) {
            float finalScore = (float) quiz_engine.getScore() / question_amount;
            float percents = finalScore * 100;
            String formattedPercents = String.format("%.2f", percents);
            JOptionPane.showMessageDialog(null, "Quiz ended. Your final score: " + formattedPercents + "%", "Quiz Ended", JOptionPane.INFORMATION_MESSAGE);
            if (currentUser != null) {
                Game game = new Game();
                game.setUser(currentUser);
                game.setCreatedAt(new Date());
                game.setScore(percents);
                Session session = HibernateUtil.getSessionFactory().openSession();
                Transaction transaction = null;
                try {
                    transaction = session.beginTransaction();
                    session.save(game);
                    transaction.commit();
                    resultsaved = true;
                } catch (Exception ex) {
                    if (transaction != null) {
                        transaction.rollback();
                    }
                    ex.printStackTrace();
                    JOptionPane.showMessageDialog(null, "Error occurred while saving the game: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
                } finally {
                    session.close();
                }
            }
        }
    }
    public void set_Question_amount(int amount) {
        this.question_amount = amount;
    }
    public void setQuiz_engine(QuizEngine quiz_engine) {
        this.quiz_engine = quiz_engine;
    }
    public void setUser(User currentUser) {
        this.currentUser = currentUser;
    }

}
