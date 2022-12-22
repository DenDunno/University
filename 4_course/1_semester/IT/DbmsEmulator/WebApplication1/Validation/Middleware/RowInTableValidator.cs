using DbmsEmulator.Models.RequestModels;
using FluentValidation;

namespace DbmsEmulator.Validation.Middleware
{
    public class RowInTableValidator : AbstractValidator<RowInTable>
    {
        public RowInTableValidator()
        {
            RuleFor(address => address.BaseAddress)
                .SetValidator(new BaseAddressValidator());
        }
    }
}
