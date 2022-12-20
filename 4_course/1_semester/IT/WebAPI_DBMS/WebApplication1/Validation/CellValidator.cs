using DbmsEmulator.Models.DbModels;
using FluentValidation;

namespace DbmsEmulator.Validation
{
    public class CellValidator : AbstractValidator<Cell>
    {
        public CellValidator()
        {
            RuleFor(cell => cell.ColumnName)
                .NotNull().NotEmpty().Matches("^\\w$");

            RuleFor(cell => cell.Value)
                .NotNull().NotEmpty().Matches("^\\w$");
        }
    }
}
