
public class StringHelper
{
    public static boolean isVowel(char ch)
    {
        return "AEIOUaeiou".indexOf(ch) != -1;
    }

    public static boolean isWordWithVowels(String str)
    {
        boolean wordWithVowels = true;

        for (int i = 0 ; i < str.length() && wordWithVowels; ++i)
        {
            wordWithVowels = isVowel(str.charAt(i));
        }

        return wordWithVowels;
    }
}
