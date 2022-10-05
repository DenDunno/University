using System;
using System.Collections.Generic;
using System.Windows.Forms;

[Serializable]
public class Database : DatabaseElement
{
    private readonly List<Table> _tables = new List<Table>();
    
    public Database(string name) : base(name)
    {
    }

    public IReadOnlyCollection<DatabaseElement> TablesNames => _tables;

    public void Add(Table tableToAdd)
    {
        if (_tables.Find(table => table.Name == tableToAdd.Name) != null)
        {
            throw new Exception($"Table with name {tableToAdd.Name} already exists");
        }
            
        _tables.Add(tableToAdd);
    }

    public void Delete(string tableName)
    {
        _tables.Remove(table => table.Name == tableName);
    }

    public void Load(string path)
    {
        MessageBox.Show(path);
    }

    public void Save(string path)
    {
    }
}