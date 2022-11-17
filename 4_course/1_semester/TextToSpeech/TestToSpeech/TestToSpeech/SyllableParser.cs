using System.Collections.ObjectModel;

public class SyllableParser
{
    private readonly ReadOnlyCollection<string> _syllables;

    public SyllableParser(List<string> syllables)
    {
        _syllables = new ReadOnlyCollection<string>(syllables);
    }
    
    public List<string> Parse(string word)
    {
        List<string> result = new();
        List<char> syllableTemp = new();
        
        foreach (char character in word)
        {
            syllableTemp.Add(character);
            string syllable = new(syllableTemp.ToArray());
            
            if (_syllables.Contains(syllable))
            {
                syllableTemp.Clear();
                result.Add(syllable);
            }
        }
        
        return result;
    }
}