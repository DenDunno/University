using DbmsEmulator.Exceptions;
using DbmsEmulator.Exceptions.Constants;
using DbmsEmulator.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace DbmsEmulator.Services
{
    public class ValidationService
    {
        private readonly Database _model;

        public ValidationService(Database model) => _model = model;

        public void ValidateModel() 
        {
            var context = new ValidationContext(_model, serviceProvider: null, items: null);

            if (!Validator.TryValidateObject(_model, context, null, true))
            {
                throw new NotImplementedHttpException(ErrorMessages.ValidationException);
            }
        }
    }
}
