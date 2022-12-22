using DbmsEmulator.Exceptions.Constants;
using DbmsEmulator.Services.Validation;
using DbmsEmulator.Validation.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DbmsEmulator.Models.DbModels
{
    public class DatabaseModel : IValidatableModel
    {
        [RegularExpression("^\\w+$", ErrorMessage = ErrorMessages.UnacceptableSymbolsInDbName)]
        public string Name { get; }

        public List<TableModel> Tables { get; set; } = new();

        public DatabaseModel(string name) 
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
