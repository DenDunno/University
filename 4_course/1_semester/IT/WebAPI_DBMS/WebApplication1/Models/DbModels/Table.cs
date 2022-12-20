using DbmsEmulator.Validation.Interfaces;

#nullable disable

namespace DbmsEmulator.Models.DbModels
{
    public class Table : IValidatableModel
    {
        public string Name { get; set; }

        public List<Row> Rows { get; set; }

        public List<Column> Columns { get; set; }
    }
}
