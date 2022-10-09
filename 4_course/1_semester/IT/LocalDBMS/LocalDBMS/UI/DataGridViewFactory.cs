using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LocalDBMS;

public class DataGridViewFactory
{
    private readonly CellValidation _cellValidation = new CellValidation();
    private readonly MainWindow _view;
    private readonly int _xOffset = 38;
    private readonly int _yOffset = 64;

    public DataGridViewFactory(MainWindow view)
    {
        _view = view;
    }

    public void Create()
    {
        var dataTable = new DataTable();
        var dataGridView = new DataGridView()
        {
            DataSource = dataTable
        };

        dataGridView.CellEndEdit += OnCellEndEdit;
        dataGridView.CellMouseClick += OnCellMouseClick;
        
        SetTransform(dataGridView);
        CreateColumns(dataTable);
        AttachDataGridViewToTab(dataGridView);
    }

    private void OnCellMouseClick(object sender, DataGridViewCellMouseEventArgs args)
    {
        if (args.Button != MouseButtons.Right)
        {
            return;   
        }

        var dataGridView = (DataGridView)sender;
        
        if (args.RowIndex == -1 && args.ColumnIndex >= 0 && args.ColumnIndex < dataGridView.ColumnCount)
        {
            dataGridView.Columns.RemoveAt(args.ColumnIndex);
        }
        
        if (args.ColumnIndex == -1 && args.RowIndex >= 0 && args.RowIndex < dataGridView.RowCount - 1)
        {
            dataGridView.Rows.RemoveAt(args.RowIndex);
        }
    }

    private void OnCellEndEdit(object sender, DataGridViewCellEventArgs args)
    {
        var dataGridView = (DataGridView)sender;
        
        DataGridViewCell cell = dataGridView.Rows[args.RowIndex].Cells[args.ColumnIndex];
        string column = dataGridView.Columns[cell.ColumnIndex].Name;
        
        _cellValidation.TrySaveValue(cell, column);
    }

    private void AttachDataGridViewToTab(DataGridView dataGridView)
    {
        var tabPage = new TabPage(_view.TextBox.Text);
        tabPage.Controls.Add(dataGridView);
        _view.TabControl.Controls.Add(tabPage);
    }
    
    private void SetTransform(DataGridView dataGridView)
    {
        dataGridView.Location = new Point(12, 12);
        dataGridView.Size = new Size(_view.Size.Width - _xOffset, _view.Size.Height - _yOffset);
    }
    
    private void CreateColumns(DataTable dataTable)
    {
        dataTable.Columns.Add(new DataColumn(DatabaseTypesName.STRING));
        dataTable.Columns.Add(new DataColumn(DatabaseTypesName.INT));
        dataTable.Columns.Add(new DataColumn(DatabaseTypesName.CHAR));
        dataTable.Columns.Add(new DataColumn(DatabaseTypesName.REAL));
        dataTable.Columns.Add(new DataColumn(DatabaseTypesName.COLOR));
        dataTable.Columns.Add(new DataColumn(DatabaseTypesName.DATE));
    }
}