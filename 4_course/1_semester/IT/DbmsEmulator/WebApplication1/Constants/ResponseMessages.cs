namespace DbmsEmulator.Constants
{
    public static class ResponseMessages
    {
        public const string DatabaseCreated = "Database {0} is created!";
        public const string DatabaseDropped = "Database {0} is dropped!";

        public const string TableCreated = "Table {0} is created in the database {1}!";
        public const string TableDropped = "Table {0} is dropped from the database {1}!";

        public const string ColumnAdded = "Column is added in the database {0}, table {1}.";
        public const string ColumnDeleted = "Column is deleted from the database {0}, table {1}.";

        public const string RowInserted = "Row is inserted in the database {0}, table {1}.";
        public const string RowDeleted = "Row is deleted from the database {0}, table {1}.";

        public const string ValueSet = "Value {0} is set in the database {1}, table {2}, at {3} row and {4} column.";

        public const string DatabaseSaved = "Database {0} is saved.";
    }
}
