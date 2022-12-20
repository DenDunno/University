using DbmsEmulator.Models.DbModels;
using FluentValidation;

namespace DbmsEmulator.Validation
{
    public class TableValidator : AbstractValidator<Table>
    {
        public TableValidator()
        {
            RuleFor(table => table.Name)
                .NotNull().NotEmpty().Matches("^\\w$");

            RuleFor(table => table.Columns)
                .ForEach(column => column.SetValidator(new ColumnValidator()));

            RuleFor(table => table.Rows)
                .ForEach(row => row.SetValidator(new RowValidator()));
        }
    }
}
