using System.Text;

SoundsLoading soundsLoading = new("Sounds");
List<string> sounds = soundsLoading.Load();
SyllableParser syllableParser = new(sounds);
AACPlayer aacPlayer = new();

Console.InputEncoding = Encoding.Unicode;

while (true)
{
    string input = Console.ReadLine()!;
    string[] words = input.Split();

    foreach (string word in words)
    {
        List<string> syllables = syllableParser.Parse(word);
        await aacPlayer.Play(syllables);
    }
}