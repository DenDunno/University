package com.company;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.List;
import java.util.Scanner;

public class Main
{
    public static void main(String[] args) throws FileNotFoundException {
        String projPath = new File(".").getAbsolutePath();
        String automataPath = projPath.substring(0, projPath.length() - 1) + "AutomatExample.txt";
        
        Scanner in = new Scanner(System.in);

        Automata automata = new Automata(automataPath);

        List<Integer> deadEndStates = automata.findDeadEndStates();
        System.out.print("Dead end states: ");
        deadEndStates.forEach(state -> System.out.print(state + " "));

        System.out.println();

        List<Integer> unattainableStates = automata.findUnattainableStates();
        System.out.print("Unattainable states: ");
        unattainableStates.forEach(state -> System.out.print(state + " "));
    }
}
