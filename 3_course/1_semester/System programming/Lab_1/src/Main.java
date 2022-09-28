import java.io.File;
import java.util.List;

public class Main
{
    public static void main(String[] args)
    {
        File selectedFile = new FileSelection().getFile();

        if (selectedFile != null)
        {
            List<String> rawContent = new TextReader(selectedFile).getRawContent();
            List<String> answer = new Parser().getWordsWithVowels(rawContent);

            answer.forEach(System.out::println);
        }
    }
}
