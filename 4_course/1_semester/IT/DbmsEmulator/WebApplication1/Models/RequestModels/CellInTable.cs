#nullable disable

namespace DbmsEmulator.Models.RequestModels
{
    public class CellInTable
    {
        public BaseAddress BaseAddress { get; set; }

        public int ColumnNumber { get; set; }

        public int RowNumber { get; set; }

        public object Value { get; set; }
    }
}
