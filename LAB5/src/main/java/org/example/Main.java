package org.example;
import java.util.Scanner;



public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.println("Input the number of items you want to generate: ");
        int number = scan.nextInt();

        System.out.println("Input the seed: ");
        int seed = scan.nextInt();

        Problem problem = new Problem(number,seed,1,10);
        System.out.println("\nCurrent instance of problem: \n");
        System.out.println(problem);

        System.out.println("Input the capacity: ");
        int capacity = scan.nextInt();

        Result result = problem.Solve(capacity);
        System.out.println("\nResults: \n");
        System.out.println(result);
    }
}