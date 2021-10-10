package com.company;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class Main
{
    public static void main(String[] args) throws FileNotFoundException {
        String projPath = new File(".").getAbsolutePath();
        String automataPath = projPath.substring(0, projPath.length() - 1) + "AutomatExample.txt";
        Scanner in = new Scanner(System.in);
        String w0;

        do {
            System.out.print("Input word w0: ");
            w0 = in.next();
            Automata automata = new Automata(automataPath, w0.toCharArray());
            System.out.println(automata.isWordReadable());
        }while (w0.equals("exit") == false);
    }
}
