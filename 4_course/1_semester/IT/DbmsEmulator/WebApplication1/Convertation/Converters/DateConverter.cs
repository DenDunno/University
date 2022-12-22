namespace DbmsEmulator.Convertation.Converters
{
    public class DateConverter : TypeConverter
    {
        public DateConverter(string value) : base(value)
        { }

        public override bool IsConverted() => 
            _value == null || DateTime.TryParse(_value, out _);
    }
}
