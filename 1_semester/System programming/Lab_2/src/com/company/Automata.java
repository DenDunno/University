package com.company;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class Automata
{
    private final HashMap<Integer, List<Integer>> inputArcs;
    private final HashMap<Integer, List<Integer>> outputArcs;
    private Integer startState;

    public Automata(String automataPath) throws FileNotFoundException {
        inputArcs = new HashMap<>();
        outputArcs = new HashMap<>();

        readStates(automataPath);
    }

    private void readStates(String automataPath) throws FileNotFoundException {
        Scanner sc = new Scanner(new File(automataPath));

        sc.nextLine();
        sc.nextLine();

        startState = sc.nextInt();

        sc.nextLine();

        while (sc.hasNextLine()) {
            int state1 = sc.nextInt();
            sc.next();
            int state2 = sc.nextInt();

            updateMap(inputArcs, state2, state1);
            updateMap(outputArcs, state1, state2);
        }
    }

    private void updateMap(HashMap<Integer, List<Integer>> transTable, int key, int state) {
        List<Integer> value;

        if(transTable.containsKey(key)) {
            value = transTable.get(key);
        }
        else {
            value = new ArrayList<>();
        }

        value.add(state);
        transTable.put(key, value);
    }

    public List<Integer> findDeadEndStates() {
        var deadEndStates = new ArrayList<Integer>();

        List<Integer> keys = outputArcs.keySet().stream().collect(Collectors.toList());
        List<Integer> value;
        for (var key : keys) {
            value = outputArcs.get(key);

            if(value.size() == 1 && value.get(0).equals(key)) {
                deadEndStates.add(key);
            }
        }

        return deadEndStates;
    }

    public List<Integer> findUnattainableStates() {
        var attainableStates = new ArrayList<Integer>();

        List<Integer> allStates = outputArcs.keySet().stream().collect(Collectors.toList());
        List<Integer> value;
        Integer startSize;
        Integer finalSize;

        value = outputArcs.get(startState);

        attainableStates.addAll(
                value.stream()
                        .filter(val -> val != startState)
                                                .collect(Collectors.toList())
        );

        do {
            startSize = attainableStates.size();

            for (var state : allStates) {
                if (!attainableStates.contains(state)) {
                    value = inputArcs.get(state);
                    value.forEach(val -> {
                        if (attainableStates.contains(val)) {
                            attainableStates.add(state);
                        }
                    });
                }
            }
            finalSize = attainableStates.size();
        }
        while(startSize != finalSize);

        allStates.removeAll(attainableStates);
        allStates.remove(startState);

        return allStates;
    }
}