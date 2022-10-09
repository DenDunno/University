using System;
using System.Collections.Generic;

[Serializable]
public class DatabaseSaveData
{
    public string Name { get; set; }
    public List<string> TableNames { get; set; }
    public List<Table> Tables { get; set; }
}