package com.company;

public class Token {
    LexemType type;
    String word;

    public Token(LexemType type, String word) {
        this.type = type;
        this.word = word;
    }

    public Token(LexemType type, char word) {
        this.type = type;
        this.word = String.valueOf(word);
    }

    public Token(LexemType type, Integer word) {
        this.type = type;
        this.word = String.valueOf(word);
    }


    public Token(LexemType type, Double word) {
        this.type = type;
        this.word = String.valueOf(word);
    }

    public String toString() {
        return String.format("%s\t\t\t\t%s", this.type.toString(), this.word);
    }

}
