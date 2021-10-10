package com.company;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.*;

public class Automata
{
    private final ArrayList<Transition> transitions;
    private final ArrayList<Integer> finalStates;
    private final char[] word;
    private Integer curState;
    private int startState;
    private int finalStatesCount;

    public Automata(String automataPath, char[] word) throws FileNotFoundException {
        finalStates = new ArrayList<>();
        transitions = new ArrayList<>();
        readStates(automataPath);
        this.word = word;
    }

    private void readStates(String automataPath) throws FileNotFoundException {
        Scanner sc = new Scanner(new File(automataPath));
        sc.nextInt();
        sc.nextInt();
        startState = sc.nextInt();

        finalStatesCount = sc.nextInt();

        for (int i = 0; i < finalStatesCount; i++) {
            finalStates.add(sc.nextInt());
        }

        while (sc.hasNextLine()) {
            int state1 = sc.nextInt();
            char symbol = sc.next().charAt(0);
            int state2 = sc.nextInt();
            Transition curTrans = new Transition(state1, symbol, state2);
            transitions.add(curTrans);
        }
    }

    private void setNextState() {
        curState = startState;

        for (char symbol : word) {
            transitions.stream().filter(s -> (s.State1.equals(curState) && s.Symbol == symbol))
                    .findFirst().ifPresentOrElse(s -> curState = s.State2, () -> curState = null);
        }
    }

    public Boolean isWordReadable() {
        setNextState();

        if (curState != null && curState != startState) {
            for (int i = 0; i < finalStatesCount; i++) {
                if (curState.equals(finalStates.get(i))) {
                    return true;
                }
            }
        }

        return false;
    }
}
