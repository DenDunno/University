using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LocalDBMS;

public class UI
{
    private readonly MainWindow _view;

    public UI(MainWindow view)
    {
        _view = view;
    }
    
    public void HideEntryPanel()
    {
        _view.EntryPanel.Visible = false;
    }

    public void CreateDataGridView()
    {
        const int xOffset = 38;
        const int yOffset = 64;
        
        var dataGridView = new DataGridView();
        var dataTable = new DataTable();
            
        dataGridView.Location = new Point(12, 12);
        dataGridView.Size = new Size(_view.Size.Width - xOffset, _view.Size.Height - yOffset);
        
        dataTable.Columns.Add(new DataColumn("STRING"));
        dataTable.Columns.Add(new DataColumn("INT"));
        dataTable.Columns.Add(new DataColumn("CHAR"));
        dataTable.Columns.Add(new DataColumn("REAL"));
        dataTable.Columns.Add(new DataColumn("COLOR"));
        dataTable.Columns.Add(new DataColumn("DATE"));
            
        dataGridView.DataSource = dataTable;
        _view.Controls.Add(dataGridView);
    }

    public void SetWindowName(string name)
    {
        _view.Text = $"LocalDBMS - {name}";
    }

    public bool TryGetPathToDatabase(out string path)
    {
        bool success;
        path = string.Empty;
        
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            success = openFileDialog.ShowDialog() == DialogResult.OK;
            
            if (success)
            {
                path = openFileDialog.FileName;
            }
        }
        
        return success;
    }
}