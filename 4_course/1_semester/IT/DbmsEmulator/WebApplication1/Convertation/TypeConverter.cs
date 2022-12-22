namespace DbmsEmulator.Convertation
{
    public abstract class TypeConverter
    {
        protected readonly string _value;

        public TypeConverter(string value) => _value = value;

        public abstract bool IsConverted();
    }
}
