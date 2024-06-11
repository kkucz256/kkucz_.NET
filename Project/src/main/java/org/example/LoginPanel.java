package org.example;

import javax.swing.*;
import java.awt.event.ActionListener;


public class LoginPanel {
    private JComboBox<String> question_combo;
    private JTextField e_mail_field;
    private JPasswordField pswrd_field;
    private JButton loginButton;
    private JButton registerButton;
    private JPanel loginpanel;

    public LoginPanel() {
        question_combo.addItem("10");
        question_combo.addItem("20");
        question_combo.addItem("30");
    }

    public JPanel getLoginPanel() {
        return loginpanel;
    }

    public void setLoginButtonAction(ActionListener actionListener) {
        loginButton.addActionListener(actionListener);
    }

    public void setRegisterButtonAction(ActionListener actionListener) {
        registerButton.addActionListener(actionListener);
    }

    public String getEmail() {
        return e_mail_field.getText();
    }

    public String getPassword() {
        return new String(pswrd_field.getPassword());
    }
    public String getSelectedValueFromComboBox() {
        return question_combo.getSelectedItem().toString();
    }


}

