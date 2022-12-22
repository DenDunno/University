using DbmsEmulator.Constants;
using DbmsEmulator.Models.RequestModels;
using FluentValidation;

namespace DbmsEmulator.Validation.Middleware
{
    public class CellInTableValidator : AbstractValidator<CellInTable>
    {
        public CellInTableValidator()
        {
            RuleFor(address => address.BaseAddress)
                .SetValidator(new BaseAddressValidator());

            RuleFor(address => address.ColumnNumber)
                .GreaterThan(0)
                .WithMessage(ValidationErrorMessages.WrondIndex);

            RuleFor(address => address.ColumnNumber)
                .GreaterThan(0)
                .WithMessage(ValidationErrorMessages.WrondIndex);
        }
    }
}
