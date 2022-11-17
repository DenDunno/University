
public class SoundsLoading
{
    private readonly string _directory;

    public SoundsLoading(string directory)
    {
        _directory = directory;
    }

    public List<string> Load()
    {
        string[] files = Directory.GetFiles(_directory);

        return files.Select(SelectSoundName).ToList();
    }

    private string SelectSoundName(string filePath)
    {
        int start = filePath.IndexOf('\\') + 1;
        int end = filePath.IndexOf('.');

        return filePath.Substring(start, end - start);
    }
}