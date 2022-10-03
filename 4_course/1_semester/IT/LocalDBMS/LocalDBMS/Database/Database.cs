using System.Collections.Generic;
using System.Windows.Forms;

public class Database : DatabaseElement
{
    private readonly List<Table> _tables = new List<Table>();
    
    public Database(string name) : base(name)
    {
    }

    public IReadOnlyCollection<DatabaseElement> TablesNames => _tables;

    public void Add(Table table)
    {
        _tables.Add(table);
    }

    public void Delete(string tableName)
    {
        Table tableToDelete = _tables.Find(table => table.Name == tableName);
        _tables.Remove(tableToDelete);
    }

    public void Load(string path)
    {
        MessageBox.Show(path);
    }

    public void Save(string path)
    {
    }
}