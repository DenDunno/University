namespace DbmsEmulator.Convertation.Converters
{
    public class IntConverter : TypeConverter
    {
        public IntConverter(string value) : base(value)
        { }

        public override bool IsConverted() => 
            _value == null || int.TryParse(_value, out _);
    }
}
