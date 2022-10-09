using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

public class DatabaseSaving
{
    public void Save(TabControl tabControl, string databaseName, List<string> tableNames)
    {
        string json = GetJsonForSaving(tabControl, databaseName, tableNames);
        SaveJson(json);
    }

    private string GetJsonForSaving(TabControl tabControl, string databaseName, List<string> tableNames)
    {
        var data = new DatabaseSaveData()
        {   
            Name = databaseName,
            TableNames = tableNames,
            Tables = GetTables(tabControl),
        };

        return JsonConvert.SerializeObject(data);
    }

    private List<Table> GetTables(TabControl tabControl)
    {
        var tables = new List<Table>();
        
        foreach (TabPage tabPage in tabControl.TabPages)
        {
            var table = new Table();
            var dataGridView = tabPage.Controls[0] as DataGridView;
            
            for (int i = 0; i < dataGridView.ColumnCount; ++i)
            {
                table.Fields.Add(dataGridView.Columns[i].Name);
            }

            for (int i = 0; i < dataGridView.RowCount - 1; ++i)
            {
                var row = new List<string>();
                    
                for (int j = 0; j < dataGridView.ColumnCount; ++j)
                {
                    object value = dataGridView.Rows[i].Cells[j].Value;
                    row.Add(value == DBNull.Value ? null : (string)value);
                }
                    
                table.Data.Add(row);
            }
            
            tables.Add(table);
        }

        return tables;
    }

    private void SaveJson(string json)
    {
        var saveFileDialog = new SaveFileDialog();  
 
        if (saveFileDialog.ShowDialog() == DialogResult.OK)  
        {  
            using (var streamWriter = new StreamWriter(saveFileDialog.FileName + ".json"))  
            {  
                streamWriter.Write(json);  
                streamWriter.Flush();  
                streamWriter.Close();  
            }  
        } 
    }
}