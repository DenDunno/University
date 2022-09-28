package com.company;

import java.awt.image.ImagingOpException;
import java.io.*;
import java.util.*;
import java.util.logging.Logger;

public class LexicalAnalyser {
    private static final Logger logger = Logger.getLogger(LexicalAnalyser.class.getName());
    private static final List<String> keywords = Collections.unmodifiableList(Arrays.asList("and", "array", "begin", "case", "const",
            "div", "do", "downto", "else", "end", "file", "for", "function", "goto", "if",
            "in", "label", "mod", "nil", "not", "of", "or", "packed", "procedure", "program",
            "record", "repeat", "set", "then", "to", "type", "until", "var", "while", "with", "writeln", "write", "readln", "read"));

    private static final List<String> types = Collections.unmodifiableList(Arrays.asList("integer", "real", "character", "string", "boolean"));

    private String line;
    private static Integer lineNumber;
    private static boolean inDocumentComment;
    private Integer currentIndex;
    private char peek;

    public LexicalAnalyser() {
        this.peek = ' ';
        lineNumber = 0;
        inDocumentComment = false;
    }

    public void setLine(String lineOfCode) {
        this.currentIndex = 0;
        this.line = lineOfCode;
        this.peek = ' ';
        line += "\n";
        ++lineNumber;
    }

    public Token scan() {
        if (inDocumentComment) {
            return processDocumentComment();
        }
        for (; ; getNextChar()) {
            if (this.peek == ' ' || this.peek == '\t') continue;
            else if (this.peek == '\n') {
                ++lineNumber;
            } else break;
        }
        Token token;

        switch (this.peek) {

            case '{':
                //token = new Token(LexemType.ONE_LINE_COMMENT, "{");
                currentIndex = line.length() + 1;
                token = oneLineComment();
                /*if (inDocumentComment) {
                    token = new Token(LexemType.ONE_LINE_COMMENT, builder);
                    inDocumentComment = false;
                }
                else
                    token = new Token(LexemType.LEXICAL_ERROR, peek);*/
                //getNextChar();
                System.out.println(token.toString());
                return token;
            case '[':
                token = new Token(LexemType.OPEN_SQUARE_BRACE, peek);
                getNextChar();
                System.out.println(token.toString());
                return token;
            case ']':
                token = new Token(LexemType.CLOSE_SQUARE_BRACE, peek);
                getNextChar();
                System.out.println(token.toString());
                return token;
            case '(':
                if (getNextChar('*')) {
                    inDocumentComment = true;
                    token = processDocumentComment();
                } else {
                    token = new Token(LexemType.OPEN_PARENTHESIS, '(');
                    //getNextChar();
                }
                System.out.println(token.toString());
                return token;
            case ')':
                token = new Token(LexemType.CLOSE_PARENTHESIS, ')');
                getNextChar();
                System.out.println(token.toString());
                return token;
            case '<':
                if (getNextChar('=')) {
                    token = new Token(LexemType.LESS_OR_EQUAL, "<=");
                    getNextChar();
                } else if (getNextChar('>')) {
                    token = new Token(LexemType.NOT_EQUAL, "<>");
                    getNextChar();
                } else {
                    token = new Token(LexemType.LESS, '<');
                    getNextChar();
                }
                System.out.println(token.toString());
                return token;
            case '>':
                if (getNextChar('=')) {
                    token = new Token(LexemType.GREATER_OR_EQUAL, ">=");
                    getNextChar();
                } else {
                    token = new Token(LexemType.GREATER, '>');
                    getNextChar();
                }
                System.out.println(token.toString());
                return token;
            case '=':
                token = new Token(LexemType.EQUAL, '=');
                getNextChar();
                System.out.println(token.toString());
                return token;
            case ':':
                if (getNextChar('=')) {
                    token = new Token(LexemType.ASSIGNMENT_WITH_DEDUCTION, ":=");
                    getNextChar();
                } else {
                    token = new Token(LexemType.COLON, ':');
                    getNextChar();
                }
                System.out.println(token.toString());
                return token;
            case ';':
                token = new Token(LexemType.SEMICOLON, peek);
                getNextChar();
                System.out.println(token.toString());
                return token;
            case ',':
                token = new Token(LexemType.COMA, peek);
                getNextChar();
                System.out.println(token.toString());
                return token;
            case '.':
                token = new Token(LexemType.DOT, peek);
                getNextChar();
                return token;
            case '+':
                token = new Token(LexemType.PLUS, peek);
                getNextChar();
                System.out.println(token.toString());
                return token;
            case '-':
                token = new Token(LexemType.MINUS, peek);
                getNextChar();
                System.out.println(token.toString());
                return token;
            case '*':
                token = new Token(LexemType.MULTIPLICATION, peek);
                getNextChar();
                System.out.println(token.toString());
                return token;
            case '\'':
                token = processStringLiteral();
                getNextChar();
                System.out.println(token.toString());
                return token;
            case '$':
                getNextChar();
                if (Character.isLetterOrDigit(peek)) {
                    return processNumber2();
                }
        }
        if (Character.isDigit(peek)) {
            return processNumber();
        }
        if (Character.isLetter(peek)) {
            return processWord();
        }
        else {
            String error = " ";
            while (!Character.isWhitespace(peek)) {
                error += peek;
                getNextChar();
            }
            token = new Token(LexemType.LEXICAL_ERROR, error);
            System.out.println(token.toString());
            return new Token(LexemType.LEXICAL_ERROR, error);
        }
    }

    private void getNextChar() {
        if (currentIndex < line.length()) {
            this.peek = line.charAt(currentIndex);
        }
        ++currentIndex;
    }

    private boolean getNextChar(char c) {
        getNextChar();
        return this.peek == c;
    }

    private Token processNumber2() {
        StringBuilder number = new StringBuilder();
        do {
            if (peek == 'a' || peek == 'b' || peek == 'c' || peek == 'd' || peek == 'e' || peek == 'f' ||
                    Character.isDigit(peek)) {
                number.append(this.peek);
                getNextChar();}
            else{
                String error = number.toString();
                while (!Character.isWhitespace(peek) || peek != '\n' ) {
                    error += peek;
                    getNextChar();
                }
                return new Token(LexemType.LEXICAL_ERROR, error);
            }
        } while(Character.isLetterOrDigit(peek));
        return new Token(LexemType.INTEGER_LITERAL, number.toString());
    }

    private Token processNumber() {
        StringBuilder number= new StringBuilder();
        do {
            number.append(this.peek);
            getNextChar();
            if(Character.isLetter(peek)){
                String error = number.toString();
                while(!Character.isWhitespace(peek) || peek != '\n') {
                    error += peek;
                    getNextChar();
                }
                return new Token(LexemType.LEXICAL_ERROR, error);
            }
        } while (Character.isLetterOrDigit(peek));
        if (peek != '.') return new Token(LexemType.INTEGER_LITERAL, number.toString());
        number.append(this.peek);
        getNextChar();
        while (true) {
            if(!Character.isDigit(peek)) break;
            number.append(this.peek);
            getNextChar();
        }
        return new Token(LexemType.FLOATING_POINT_LITERAL, number.toString());
    }

    private Token processWord() {
        StringBuilder word = new StringBuilder();
        //word.append(peek);
        do {
            word.append(peek);
            getNextChar();
        } while (Character.isLetterOrDigit(peek));
        if (keywords.contains(word.toString())) {
            return new Token(LexemType.KEYWORD, word.toString());
        } else if (types.contains(word.toString())) {
            return new Token(LexemType.DATA_TYPE, word.toString());
        } else {
            return  new Token(LexemType.IDENTIFIER, word.toString());
        }
    }

    public boolean reachEndOfTheLine() {
        return currentIndex >= line.length();
    }


    private Token processStringLiteral() {
        StringBuilder literal = new StringBuilder();
        literal.append('\'');
        do {
            getNextChar();
            literal.append(this.peek);
        } while (Character.isLetterOrDigit(this.peek)||Character.isWhitespace(this.peek));
        literal.append('\'');
        getNextChar();
        getNextChar();
        return new Token(LexemType.STRING_LITERAL, literal.toString().substring(0, literal.toString().length() - 1));
    }

    private Token oneLineComment() {
        Integer temp = 0;
        StringBuilder builder = new StringBuilder();
        while (temp < line.length()) {
            this.peek = line.charAt(temp);
            temp++;
            if (this.peek == '}') {
                inDocumentComment = false;
                currentIndex = temp + 1;
                builder.append(this.peek);
                break;
            }
            builder.append(this.peek);
        }
        return new Token(LexemType.ONE_LINE_COMMENT, builder.toString());
    }

    private Token processDocumentComment() {
        line += "\n";
        StringBuilder builder = new StringBuilder();
        builder.append('(');
        do {
            builder.append(this.peek);
            getNextChar();
            if (this.peek == '*' && getNextChar(')')) {
                inDocumentComment = false;
                builder.append('*');
                builder.append(this.peek);
                break;
            }
            //builder.append(this.peek);
        } while (this.peek != '\n');
        currentIndex = line.length() + 1;
        return new Token(LexemType.DOCUMENT_COMMENT, builder.toString());
    }
}
