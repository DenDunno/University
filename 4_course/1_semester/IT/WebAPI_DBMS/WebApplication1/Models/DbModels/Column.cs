#nullable disable

namespace DbmsEmulator.Models.DbModels
{
    public abstract class Column
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
