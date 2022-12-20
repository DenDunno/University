using DbmsEmulator.Validation.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DbmsEmulator.Models.DbModels
{
    public class Database : IValidatableModel
    {
        [RegularExpression("^\\w+$")]
        public string Name { get; }

        public List<Table> Tables { get; set; } = new();

        public Database(string name) => Name = name;
    }
}
