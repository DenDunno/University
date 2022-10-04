using System;

public class CharValidation : IValidation
{
    public void Apply(object value)
    {
        if (value.ToString().Length != 1)
            throw new Exception("CHAR must have 1 symbol");
    }
}