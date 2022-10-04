using System;
using System.Globalization;

public class DateValidation : IValidation
{
    public void Apply(object value)
    {
        DateTime.ParseExact(value.ToString(), "MM.dd.yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None);
    }
}