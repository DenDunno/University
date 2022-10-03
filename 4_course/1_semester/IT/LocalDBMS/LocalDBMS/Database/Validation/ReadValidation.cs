
using System;

public class ReadValidation : IValidation
{
    public void Apply(object value)
    {
        Convert.ToDouble(value);
    }
}