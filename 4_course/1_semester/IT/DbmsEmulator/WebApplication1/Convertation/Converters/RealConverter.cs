using System.Globalization;

namespace DbmsEmulator.Convertation.Converters
{
    public class RealConverter : TypeConverter
    {
        public RealConverter(string value) : base(value)
            { }

        public override bool IsConverted() =>
            _value == null || double.TryParse(_value, NumberStyles.Float, CultureInfo.InvariantCulture, out _);
    }
}
