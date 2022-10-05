using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

public class DatabaseSave
{
    private readonly TabControl _tabControl;

    public DatabaseSave(TabControl tabControl)
    {
        _tabControl = tabControl;
    }

    public void Save(string path)
    {
        IEnumerable<DataGridView> tables = GetTables();
        var data = new List<List<List<object>>>();
        var tableData = new List<List<object>>();
        var row = new List<object>();

        foreach (DataGridView dataGridView in tables)
        {
            tableData.Clear();
            
            for (int i = 0; i < dataGridView.RowCount; ++i)
            {
                row.Clear();
                
                for (int j = 0; j < dataGridView.ColumnCount; ++j)
                {
                    row.Add(dataGridView.Rows[i].Cells[j].Value);
                }
                
                tableData.Add(row);
            }
            
            data.Add(tableData);

            string json = JsonConvert.SerializeObject(data);
            int a = 10;
        }
    }

    private IEnumerable<DataGridView> GetTables()
    {
        var tables = new List<DataGridView>();

        foreach (TabPage tabControlTabPage in _tabControl.TabPages)
        {
            tables.Add(tabControlTabPage.Controls[0] as DataGridView);
        }

        return tables;
    }
}