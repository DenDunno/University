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

    public Automata(String automataPath) throws FileNotFoundException {
        inputArcs = new HashMap<>();
        outputArcs = new HashMap<>();

        readStates(automataPath);
    }

    private void readStates(String automataPath) throws FileNotFoundException {
        Scanner sc = new Scanner(new File(automataPath));

        sc.nextLine();
        sc.nextLine();
        sc.nextLine();
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
        var unattainableStates = new ArrayList<Integer>();

        List<Integer> allStates = outputArcs.keySet().stream().collect(Collectors.toList());
        List<Integer> keys = inputArcs.keySet().stream().collect(Collectors.toList());
        List<Integer> value;

        if (keys.size() < allStates.size()) {
            allStates.forEach(state -> {
                if (!keys.contains(state)) {
                    unattainableStates.add(state);
                }
            });
        }

        if (unattainableStates.size() > 0) {
            int startSize;
            int finalSize;

            do {
                startSize = unattainableStates.size();
                for(var key : keys) {
                    if (!unattainableStates.contains(key)) {
                        value = inputArcs.get(key);

                        List<Integer> goodStates = value.stream()
                                .filter(state -> !unattainableStates.contains(state) && !state.equals(key))
                                .collect(Collectors.toList());

                        if(goodStates.size() == 0) {
                            unattainableStates.add(key);
                        }
                    }
                }
                finalSize = unattainableStates.size();
            }
            while (startSize != finalSize);
        }

        return unattainableStates;
    }
}