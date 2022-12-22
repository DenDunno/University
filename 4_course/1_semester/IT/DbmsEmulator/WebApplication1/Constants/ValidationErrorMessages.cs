namespace DbmsEmulator.Constants
{
    public static class ValidationErrorMessages
    {
        public const string WrondDbName = "Database name can only contain letters and digits.";
        public const string WrondTableName = "Table name can only contain letters and digits.";
        public const string WrondColumnType = "Column types supported: CHAR, STRING, DATE, REAL, INT, COLOR.";
        public const string WrondIndex = "Index should be greater than 0.";
    }
}
