namespace DbmsEmulator.Exceptions.Constants
{
    public static class ErrorMessages
    {
        public const string UnacceptableSymbolsInDbName = "Unacceptable symbols in the database name";
        public const string DbWithSamehNameAlreadyExists = "Database with the same name already exists";
        public const string DatabaseNotFound = "Database with such a name was not found";

        public const string UnacceptableSymbolsInTableName = "Unacceptable symbols in the table name";
        public const string TableWithSameNameAlreadyExists = "Table with the same name already exists";
        public const string TableNotFound = "Table with such a name does not exist in the database";

        public const string ColumnNotFound = "Column with such number doesn't exist";

        public const string RowNotFound = "Row with such number doesn't exist";
        public const string RowsSizeShouldBeEqualToColumns = "Row size should be the same as columns quantity.";

        public const string ValueAndTypeDoNotMatch = "Value and column type doesn't match each other";


        //public const string TwoOrMoreColumnsHaveSameName = "Two or more columns have the same name";
        //public const string NotAllColumnsHaveValue = "One or more columns don't have a value in the row";
        //public const string RedundantColumnsInTheRow = "One or more rows have redundant columns";
    }
}
