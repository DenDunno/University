using System;

public class IntValidation : IValidation
{
    public void Apply(object value)
    {
        Convert.ToInt32(value);
    }
}