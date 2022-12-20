using DbmsEmulator.Models.DbModels;
using FluentValidation;

namespace DbmsEmulator.Validation
{
    public class ColumnValidator : AbstractValidator<Column>
    {
        public ColumnValidator()
        {
            RuleFor(column => column.Name).NotNull().NotEmpty().Matches("^\\w$");
        }
    }
}
