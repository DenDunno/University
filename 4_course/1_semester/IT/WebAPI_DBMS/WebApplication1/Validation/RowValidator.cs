using DbmsEmulator.Models.DbModels;
using FluentValidation;

namespace DbmsEmulator.Validation
{
    public class RowValidator : AbstractValidator<Row>
    {
        public RowValidator()
        {
            RuleFor(row => row.Cells)
                .ForEach(cell => cell.SetValidator(new CellValidator()));
        }
    }
}
