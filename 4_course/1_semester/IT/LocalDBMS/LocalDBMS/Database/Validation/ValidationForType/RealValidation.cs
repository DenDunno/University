using System;

public class RealValidation : IValidation
{
    public void Apply(object value)
    {
        Convert.ToDouble(value);
    }
}