#nullable disable

namespace DbmsEmulator.Models.RequestModels
{
    public class RowInTable
    {
        public BaseAddress BaseAddress { get; set; }

        public IEnumerable<object> Values { get; set; }
    }
}
