import java.io.File;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class TextReader
{
    private final File selectedFile;

    public TextReader(File file)
    {
        selectedFile = file;
    }

    public List<String> getRawContent()
    {
        List<String> content = new ArrayList<>();

        try
        {
            Scanner reader = new Scanner(selectedFile);

            while (reader.hasNextLine())
            {
                var line = new String((reader.nextLine()).getBytes(StandardCharsets.UTF_8), StandardCharsets.UTF_8);
                content.add(line);
            }

            reader.close();
        }
        catch (Exception e)
        {
            System.out.println("FileReading error occurred.");
        }

        return content;
    }
}
