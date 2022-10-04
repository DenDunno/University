using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LocalDBMS;

public class UI
{
    private readonly MainWindow _view;
    private readonly DatabasePathDialog _databasePathDialog = new DatabasePathDialog();
    private readonly DataGridViewFactory _dataGridViewFactory;
    
    public UI(MainWindow view)
    {
        _view = view;
        _dataGridViewFactory = new DataGridViewFactory(view);
    }

    public void ShowInputPanel(Action onAccept)
    {
        _view.TextBox.Text = string.Empty;
        _view.AcceptInputButton.RemoveClickEvent();
        _view.InputPanel.Visible = true;
        
        _view.AcceptInputButton.Click += (sender, e) =>
        {
            if (_view.TextBox.Text == string.Empty)
            {
                MessageBox.Show("Name cannot be empty");
            }
            else
            {
                _view.InputPanel.Visible = false;
                onAccept();    
            }
        };
    }

    public void SetUpUI()
    {
        _view.Text = $"LocalDBMS - {_view.TextBox.Text}";
        _view.TableMenuItem.Visible = true;
        _view.SaveMenuItem.Visible = true;
        _view.TabControl.TabPages.Clear();
    }

    public void CreateDataGridView() => _dataGridViewFactory.Create();

    public bool TryGetPathToDatabase(out string path) => _databasePathDialog.TryGetPathToDatabase(out path);

    public void DeleteTab(string tableName) => _view.TabControl.DeleteTab(tableName);
}