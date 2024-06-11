package org.example;


import com.fasterxml.jackson.databind.JsonNode;
import org.hibernate.Session;
import org.hibernate.Transaction;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class MainFrame extends JFrame {
    private JPanel container;
    private LoginPanel loginPanel;
    private RegisterPanel registerPanel;
    private Quiz quizPanel;
    private User currentUser;
    private int question_amount;

    public MainFrame() {
        setTitle("Quizzler");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setPreferredSize(new Dimension(600, 800));

        container = new JPanel();
        container.setLayout(new CardLayout());

        loginPanel = new LoginPanel();
        registerPanel = new RegisterPanel();
        quizPanel = new Quiz();

        UIManager.put("OptionPane.background", new Color(0x3C3633));
        UIManager.put("Panel.background", new Color(0x3C3633));
        UIManager.put("OptionPane.messageForeground", new Color(0xEEEDCB));
        UIManager.put("Button.background", new Color(0x747264));
        UIManager.put("Button.foreground", new Color(0xEEEDCB));


        container.add(loginPanel.getLoginPanel(), "loginPanel");
        container.add(registerPanel.getRegisterPanel(), "registerPanel");
        container.add(quizPanel.getQuizPanel(), "quizPanel");
        add(container);


        CardLayout cardLayout = (CardLayout) container.getLayout();
        cardLayout.show(container, "loginPanel");

        pack();
        setLocationRelativeTo(null);
        setVisible(true);

        loginPanel.setRegisterButtonAction(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                cardLayout.show(container, "registerPanel");
            }
        });

        loginPanel.setLoginButtonAction(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String email = loginPanel.getEmail();
                String password = loginPanel.getPassword();

                Session session = HibernateUtil.getSessionFactory().openSession();
                Transaction transaction = session.beginTransaction();

                try {
                    CriteriaBuilder builder = session.getCriteriaBuilder();
                    CriteriaQuery<User> criteriaQuery = builder.createQuery(User.class);
                    Root<User> root = criteriaQuery.from(User.class);
                    criteriaQuery.select(root).where(builder.equal(root.get("email"), email));
                    List<User> users = session.createQuery(criteriaQuery).getResultList();

                    if (users.isEmpty()) {
                        JOptionPane.showMessageDialog(null, "User does not exist", "Error", JOptionPane.ERROR_MESSAGE);
                    } else {
                        User user = users.get(0);
                        if (user.checkPassword(password)) {
                            currentUser = user;
                            question_amount = Integer.parseInt(loginPanel.getSelectedValueFromComboBox());
                            quizPanel.set_Question_amount(question_amount);
                            cardLayout.show(container, "quizPanel");
                            List<Question> quiz_questions = new ArrayList<>();
                            Data data = new Data();
                            List<JsonNode> questions = data.fetch_questions(question_amount, "boolean");
                            for (JsonNode questionNode : questions) {
                                Question question = new Question(questionNode.get("question").asText(), questionNode.get("correct_answer").asText());
                                quiz_questions.add(question);
                            }
                            QuizEngine engine = new QuizEngine(quiz_questions);
                            quizPanel.setUser(currentUser);
                            quizPanel.setQuiz_engine(engine);
                            quizPanel.setRatio();
                            quizPanel.resultsaved = false;
                            quizPanel.update_score();
                            quizPanel.show_question(engine.first_question());
                        } else {
                            JOptionPane.showMessageDialog(null, "Incorrect email or password", "Error", JOptionPane.ERROR_MESSAGE);
                        }
                    }
                    transaction.commit();
                } catch (Exception ex) {
                    if (transaction != null) {
                        transaction.rollback();
                    }
                    JOptionPane.showMessageDialog(null, "Error occurred: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
                    ex.printStackTrace();
                } finally {
                    session.close();
                }
            }
        });

        registerPanel.setBackButtonAction(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                cardLayout.show(container, "loginPanel");
            }
        });

        registerPanel.setRegisterButtonAction(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String email = registerPanel.getEmail();
                String nickname = registerPanel.getNickname();
                String password1 = registerPanel.getPassword1();
                String password2 = registerPanel.getPassword2();

                if(!email.contains("@") || !email.contains(".")) {
                    JOptionPane.showMessageDialog(null, "Enter a proper e-mail address", "Error", JOptionPane.ERROR_MESSAGE);
                    return;
                }

                if (!password1.equals(password2)) {
                    JOptionPane.showMessageDialog(null, "Passwords do not match", "Error", JOptionPane.ERROR_MESSAGE);
                    return;
                }

                Session session = HibernateUtil.getSessionFactory().openSession();
                Transaction transaction = session.beginTransaction();
                try {

                    CriteriaBuilder builder = session.getCriteriaBuilder();
                    CriteriaQuery<User> criteriaQuery = builder.createQuery(User.class);
                    Root<User> root = criteriaQuery.from(User.class);
                    criteriaQuery.select(root).where(builder.equal(root.get("email"), email));
                    List<User> users = session.createQuery(criteriaQuery).getResultList();

                    if (!users.isEmpty()) {
                        JOptionPane.showMessageDialog(null, "User with e-mail " + email +" already exists", "Error", JOptionPane.ERROR_MESSAGE);
                        return;
                    }

                    User user = new User();
                    user.setEmail(email);
                    user.setPassword(password1);
                    user.setNickname(nickname);
                    session.save(user);

                    transaction.commit();

                    JOptionPane.showMessageDialog(null, "User " + email + " registered successfully", "Success", JOptionPane.INFORMATION_MESSAGE);

                } catch (Exception ex) {
                    if (transaction != null) {
                        transaction.rollback();
                    }
                    JOptionPane.showMessageDialog(null, "Error occurred: " + ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
                    ex.printStackTrace();
                } finally {
                    session.close();
                }
            }
        });
        quizPanel.setTrueButtonAction( new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                check_answer("True");
            }
        });
        quizPanel.setFalseButtonAction( new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                check_answer("False");
            }
        });
        quizPanel.setBackButtonAction(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                int dialogResult = JOptionPane.showConfirmDialog(null, "Are you sure you want to quit?", "Quit", JOptionPane.YES_NO_OPTION);
                if (dialogResult == JOptionPane.YES_OPTION) {
                    cardLayout.show(container, "loginPanel");
                }
            }
        });
    }
    private void check_answer(String answer){
        if (quizPanel.quiz_engine.still_has_questions()) {
            if (quizPanel.quiz_engine.check_answer(answer)) {
                quizPanel.update_score();
            }
            String nextQuestion = quizPanel.quiz_engine.next_question();
            if (nextQuestion != null) {
                quizPanel.show_question(nextQuestion);
            } else {
                quizPanel.end_quiz();

            }
        } else {
            quizPanel.end_quiz();
        }
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                new MainFrame();
            }
        });
    }
}
