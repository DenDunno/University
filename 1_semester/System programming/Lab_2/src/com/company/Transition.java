package com.company;

public class Transition
{
    public final Integer State1;
    public final char Symbol;
    public final Integer State2;

    Transition(Integer state1, char symbol, Integer state2) {
        State1 = state1;
        Symbol = symbol;
        State2 = state2;
    }
}
