using DbmsEmulator.Exceptions;
using DbmsEmulator.Validation.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DbmsEmulator.Services.Validation
{
    public class ValidationService
    {
        private readonly IValidatableModel _model;

        public ValidationService(IValidatableModel model)
        {
            _model = model;
        }

        public void ValidateModel()
        {
            var context = new ValidationContext(_model, serviceProvider: null, items: null);
            List<ValidationResult> validationResults = new();

            if (!Validator.TryValidateObject(_model, context, validationResults, true))
            {
                throw new NotImplementedHttpException(validationResults.First().ErrorMessage!);
            }
        }
    }
}
