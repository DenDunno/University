using DbmsEmulator.Constants;
using DbmsEmulator.Models.RequestModels;
using FluentValidation;

namespace DbmsEmulator.Validation.Middleware
{
    public class ColumnInTableValidator : AbstractValidator<ColumnInTable>
    {
        public ColumnInTableValidator()
        {
            RuleFor(address => address.BaseAddress)
                .SetValidator(new BaseAddressValidator());

            RuleFor(column => column.ColumnType)
                .Must(type => type != null && ColumnTypes.AllTypes.Contains(type.ToUpper()))
                .WithMessage(ValidationErrorMessages.WrondColumnType);
        }
    }
}
