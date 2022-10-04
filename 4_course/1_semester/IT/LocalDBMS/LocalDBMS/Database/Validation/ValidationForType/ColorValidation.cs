using System;

public class ColorValidation : IValidation
{
    public void Apply(object value)
    {
        string input = value.ToString().ToLower();

        if (input.Length != 7)
            throw new Exception("HEX color must contain 7 symbols");
        
        if (input[0] != '#')
            throw new Exception("HEX color must start with '#'");

        for (int i = 1; i < input.Length; ++i)
        {
            if (IsBadInput(input[i]))
            {
                throw new Exception($"Bad input for {i + 1} symbol");
            }
        }
    }

    private bool IsBadInput(char symbol)
    {
        return (char.IsDigit(symbol) || InColorRange(symbol)) == false;
    }

    private bool InColorRange(char symbol)
    {
        return symbol >= 'a' && symbol <= 'f';
    }
}