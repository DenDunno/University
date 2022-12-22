namespace DbmsEmulator.Convertation.Converters
{
    public class CharConverter : TypeConverter
    {
        public CharConverter(string value) : base(value)
        { }

        public override bool IsConverted() =>
            _value == null || char.TryParse(_value, out _);
    }
}
