using System;
using System.Windows.Forms;
using LocalDBMS;

public class UI
{
    private readonly MainWindow _view;
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
                HideInputPanel();
                onAccept();    
            }
        };
    }

    public void HideInputPanel()
    {
        _view.InputPanel.Visible = false;
    }

    public void SetUpUI(string databaseName)
    {
        _view.Text = $"LocalDBMS - {databaseName}";
        _view.TableMenuItem.Visible = true;
        _view.SaveMenuItem.Visible = true;
        _view.TabControl.TabPages.Clear();
    }

    public void CreateDataGridView() => _dataGridViewFactory.Create();

    public void DeleteTab(string tableName) => _view.TabControl.DeleteTab(tableName);

    public void AddColumn(string text)
    {
        var dataGridView = _view.TabControl.SelectedTab.Controls[0] as DataGridView;
        dataGridView.Columns.Add(text, text);
    }

    public void TryShowAddColumnItem()
    {
        _view.AddColumnMenuItem.Visible = _view.TabControl.TabPages.Count != 0;
    }
}