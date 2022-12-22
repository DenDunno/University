using DbmsEmulator.Exceptions.Constants;
using DbmsEmulator.Services.Validation;
using DbmsEmulator.Validation.Interfaces;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DbmsEmulator.Models.DbModels
{
    public class TableModel : IValidatableModel
    {
        [RegularExpression("^\\w+$", ErrorMessage = ErrorMessages.UnacceptableSymbolsInTableName)]
        public string Name { get; set; }

        public List<RowModel> Rows { get; set; } = new();

        public List<ColumnModel> Columns { get; set; } = new();

        public TableModel(string name)
        {
            Name = name;
        }

        public void Validate()
        {
            ValidationService validationService = new(this);

            validationService.ValidateModel();
        }
    }
}
