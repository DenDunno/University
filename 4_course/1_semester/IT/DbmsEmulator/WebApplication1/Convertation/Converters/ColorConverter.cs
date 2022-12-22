using System.Text.RegularExpressions;

namespace DbmsEmulator.Convertation.Converters
{
    public class ColorConverter : TypeConverter
    {
        public ColorConverter(string value) : base(value)
        { }

        public override bool IsConverted()
        {
            Regex reg = new("^#{1}[a-fA-F0-9]{6}$");

            return _value == null || reg.IsMatch(_value);
        }
    }
}
