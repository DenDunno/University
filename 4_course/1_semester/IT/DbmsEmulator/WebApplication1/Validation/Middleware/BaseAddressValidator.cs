using DbmsEmulator.Constants;
using DbmsEmulator.Models.RequestModels;
using FluentValidation;

namespace DbmsEmulator.Validation.Middleware
{
    public class BaseAddressValidator : AbstractValidator<BaseAddress>
    {
        public BaseAddressValidator()
        {
            RuleFor(address => address.DatabaseName)
                .NotNull().NotEmpty().Matches("^\\w+$")
                .WithMessage(ValidationErrorMessages.WrondDbName); ;

            RuleFor(address => address.TableName)
                .NotNull().NotEmpty().Matches("^\\w+$")
                .WithMessage(ValidationErrorMessages.WrondTableName);
        }
    }
}
