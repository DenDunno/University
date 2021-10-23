import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Parser
{
    public List<String> getWordsWithVowels(Iterable<String> lines)
    {
        List<String> answer = new ArrayList<>();
        List<String> allWords = getAllWords(lines);

        for (String word : allWords)
        {
            if (StringHelper.isWordWithVowels(word))
            {
                answer.add(word);
            }
        }

        return  answer;
    }

    private void cutWords(String[] words)
    {
        int maxWordLength = 30;

        for (int i = 0 ; i < words.length ; ++i)
        {
            if (words[i].length() > maxWordLength)
            {
                words[i] = words[i].substring(0, maxWordLength + 1);
            }
        }
    }

    private List<String> getAllWords(Iterable<String> lines)
    {
        String delimiterRegex =  "[' ',@—:\\.?!]";
        String quoteRegex = "[\"“”]";
        List<String> answer = new ArrayList<>();
        List<String> finalAnswer = new ArrayList<>();

        for (String line : lines)
        {
            line = line.replaceAll(quoteRegex, ""); // quote
            String[] words = line.split(delimiterRegex);

            cutWords(words);

            Collections.addAll(answer , words);
        }

        answer.removeAll(Collections.singleton(""));

        for (String line : answer)
        {
            if (finalAnswer.contains(line) == false)
                finalAnswer.add(line);
        }
        return finalAnswer;
    }
}
