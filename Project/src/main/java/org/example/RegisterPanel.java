package org.example;

import javax.swing.*;
import java.awt.event.ActionListener;

public class RegisterPanel {
    private JPanel registerpanel;
    private JTextField mailfield;
    private JPasswordField passwordField1;
    private JPasswordField passwordField2;
    private JButton register;
    private JButton back;
    private JLabel maillabel;
    private JLabel pswrdlabel;
    private JLabel pswrdlabel2;
    private JTextField nicknamefield;
    private JLabel nicknamelabel;

    public JPanel getRegisterPanel() {
        return registerpanel;
    }
    public String getEmail() {
        return mailfield.getText();
    }

    public String getPassword1() {
        return new String(passwordField1.getPassword());
    }

    public String getPassword2() {
        return new String(passwordField2.getPassword());
    }

    public String getNickname() {
        return nicknamefield.getText();
    }

    public void setBackButtonAction(ActionListener actionListener) {
        back.addActionListener(actionListener);
    }

    public void setRegisterButtonAction(ActionListener actionListener) {
        register.addActionListener(actionListener);
    }

}
