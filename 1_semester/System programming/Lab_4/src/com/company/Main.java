package com.company;

//import com.sun.source.tree.LambdaExpressionTree;

import java.io.*;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        String projPath = new File(".").getAbsolutePath();
        String inputPath = projPath.substring(0, projPath.length() - 1) + "Input.txt";
        String outputPath = projPath.substring(0, projPath.length() - 1) + "Output.txt";
        try (Scanner sc = new Scanner(new File(inputPath)); FileWriter output = new FileWriter(new File(outputPath))) {
            LexicalAnalyser analyser = new LexicalAnalyser();
            while (sc.hasNext()) {
                var line = sc.nextLine();
                if (line.length() == 0) continue;
                analyser.setLine(line);
                while (!analyser.reachEndOfTheLine()) {
                    var token = analyser.scan();
                    output.write(token.toString());
                    output.write("\n");
                }
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Requested file is not found.");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
