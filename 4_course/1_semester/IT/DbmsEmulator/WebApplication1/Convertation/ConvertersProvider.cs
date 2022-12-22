using DbmsEmulator.Constants;
using DbmsEmulator.Convertation.Converters;

namespace DbmsEmulator.Convertation
{
    public static class ConvertersProvider
    {
        private static Dictionary<string, Func<string, TypeConverter>> _typedConverters = new()
        {
            { ColumnTypes.Int, value => new IntConverter(value) },
            { ColumnTypes.Char, value => new CharConverter(value) },
            { ColumnTypes.Real, value => new RealConverter(value) },
            { ColumnTypes.Date, value => new DateConverter(value) },
            { ColumnTypes.Color, value => new ColorConverter(value) }
        };

        public static TypeConverter GetConverter(string type, string value) =>
            _typedConverters[type](value);
    }
}
