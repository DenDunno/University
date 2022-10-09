using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class Database 
{
    private readonly List<string> _tableNames = new List<string>();
    private readonly DatabaseSaving _databaseSaving = new DatabaseSaving();
    private string _name;

    public void SetName(string name)
    {
        _name = name;
    }

    public IReadOnlyCollection<string> TableNames => _tableNames;

    public void Add(string tableToAdd)
    {
        if (_tableNames.Find(name => name == tableToAdd) != null)
        {
            throw new Exception($"Table with name {tableToAdd} already exists");
        }
            
        _tableNames.Add(tableToAdd);
    }

    public void Delete(string tableName) => _tableNames.Remove(table => table == tableName);

    public void Save(TabControl tabControl) => _databaseSaving.Save(tabControl, _name, _tableNames);

    public void Clear()
    {
        _name = string.Empty;
        _tableNames.Clear();
    }
}