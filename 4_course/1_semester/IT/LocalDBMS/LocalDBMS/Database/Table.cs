using System;
using System.Collections.Generic;

[Serializable]
public class Table
{
    public List<string> Fields { get; set; } = new List<string>();
    public List<List<string>> Data { get; set; } = new List<List<string>>();
}