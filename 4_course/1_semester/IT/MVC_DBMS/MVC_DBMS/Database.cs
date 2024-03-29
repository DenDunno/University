﻿using Newtonsoft.Json;

[Serializable]
public class Database
{
    public readonly string Name;
    public static Database Instance = null!;
    public readonly Dictionary<string, Table> Tables = new();
    
    [JsonConstructor]
    private Database(string name)
    {
        Name = name;
    }

    public static void Create(string name)
    {
        Instance = new Database(name);
    }
}