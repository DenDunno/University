using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LocalDBMS;

public class UI
{
    private readonly MainWindow _view;
    private readonly DatabasePathDialog _databasePathDialog = new DatabasePathDialog();
    
    public UI(MainWindow view)
    {
        _view = view;
    }

    public void ShowInputPanel(Action onAccept)
    {
        _view.TextBox.Text = string.Empty;
        _view.AcceptInputButton.RemoveClickEvent();
        _view.InputPanel.Visible = true;
        _view.AcceptInputButton.Click += (sender, e) =>
        {
            _view.InputPanel.Visible = false;
            onAccept();
        };
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
        
        var tabPage = new TabPage(_view.TextBox.Text);
        tabPage.Controls.Add(dataGridView);
        _view.TabControl.Controls.Add(tabPage);
    }

    public void SetUpUI()
    {
        _view.Text = $"LocalDBMS - {_view.TextBox.Text}";
        _view.TableMenuItem.Visible = true;
        _view.SaveMenuItem.Visible = true;
    }

    public bool TryGetPathToDatabase(out string path) => _databasePathDialog.TryGetPathToDatabase(out path);

    public void DeleteTab(string tableName) => _view.TabControl.DeleteTab(tableName);
}