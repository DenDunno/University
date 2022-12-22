using System.Data;
using System.IO;
using System.Windows.Forms;
using LocalDBMS;
using Newtonsoft.Json;

public class DatabaseLoading
{
    private readonly Database _database;
    private readonly MainWindow _view;
    private readonly UI _ui;

    public DatabaseLoading(Database database, MainWindow view, UI ui)
    {
        _database = database;
        _view = view;
        _ui = ui;
    }

    public void TryLoad()
    {
        if (TryOpenJson(out string path))
        {
            DatabaseSaveData databaseSaveData = ParseJson(path);
            SetUpDatabase(databaseSaveData);
        }
    }

    private bool TryOpenJson(out string path)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = "c:\\";
        openFileDialog.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;

        bool success = openFileDialog.ShowDialog() == DialogResult.OK;
        
        path = success ? openFileDialog.FileName : string.Empty;

        return success;
    }

    private DatabaseSaveData ParseJson(string path)
    {
        return JsonConvert.DeserializeObject<DatabaseSaveData>(File.ReadAllText(path));
    }

    private void SetUpDatabase(DatabaseSaveData databaseSaveData)
    {
        _database.Clear();
        _ui.HideInputPanel();
        _ui.SetUpUI(databaseSaveData.Name);

        for (int i = 0; i < databaseSaveData.TableNames.Count; ++i)
        {
            _ui.CreateDataGridView();
            _database.Add(databaseSaveData.TableNames[i]);
                    
            TabPage tabPage = _view.TabControl.TabPages[i];
            tabPage.Text = databaseSaveData.TableNames[i];
            var dataGridView = tabPage.Controls[0] as DataGridView;
            dataGridView.Columns.Clear();
                    
            Table table = databaseSaveData.Tables[i];
            var dataTable = new DataTable();
            
            SetUpDataTable(dataTable, table);
            SetUpDataGridView(dataGridView, dataTable, table);
        }
    }

    private void SetUpDataTable(DataTable dataTable, Table table)
    {
        for (int j = 0; j < table.Data.Count; j++)
        {
            dataTable.Rows.Add();
        }
                    
        for (int j = 0; j < table.Fields.Count; j++)
        {
            dataTable.Columns.Add();
        }

        for (int j = 0; j < table.Data.Count; ++j)
        {
            for (int k = 0; k < table.Fields.Count; ++k)
            {
                dataTable.Rows[j][k] = table.Data[j][k];
            }
        }
    }

    private void SetUpDataGridView(DataGridView dataGridView, DataTable dataTable, Table table)
    {
        dataGridView.DataSource = dataTable;

        for (int j = 0; j < table.Fields.Count; j++)
        {
            dataGridView.Columns[j].Name = table.Fields[j];
            dataGridView.Columns[j].HeaderText = table.Fields[j];
        }
    }
}