using System;
using System.Windows.Forms;

namespace LocalDBMS
{
    public partial class MainWindow : Form
    {
        private readonly UI _ui;
        private readonly Database _database = new Database();
        private readonly DatabaseLoading _databaseLoading;

        public MainWindow()
        {
            InitializeComponent();
            _ui = new UI(this);
            _databaseLoading = new DatabaseLoading(_database, this, _ui);
            deleteToolStripMenuItem.MouseHover += OnDeleteItemHover;
            AddColumnMenuItem.MouseHover += OnAddColumnHover;
        }

        private void CreateDatabaseClick(object sender, EventArgs e)
        {
            _ui.ShowInputPanel(() =>
            {
                _ui.SetUpUI(TextBox.Text);
                _database.Clear();
                _database.SetName(TextBox.Text);
            });
        }

        private void CreateTableClick(object sender, EventArgs e)
        {
            _ui.ShowInputPanel(()=>
            {
                try
                {
                    _database.Add(TextBox.Text);
                    _ui.CreateDataGridView();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            });
        }

        private void SaveClick(object sender, EventArgs e)
        {
            _database.Save(TabControl);
        }

        private void LoadClick(object sender, EventArgs e)
        {
            _databaseLoading.TryLoad();
        }

        private void OnDeleteItemHover(object sender, EventArgs e)
        {
            var deleteTableItem = (ToolStripMenuItem)sender;
            deleteTableItem.DropDownItems.Clear();

            foreach (string tableName in _database.TableNames)
            {
                ToolStripItem tableToDelete = deleteTableItem.DropDownItems.Add(tableName);
                tableToDelete.Click += DeleteTable;
            }
        }

        private void OnAddColumnHover(object sender, EventArgs e)
        {
            var deleteTableItem = (ToolStripMenuItem)sender;
            deleteTableItem.DropDownItems.Clear();

            foreach (string type in DatabaseTypesName.Types)
            {
                ToolStripItem tableToDelete = deleteTableItem.DropDownItems.Add(type);
                tableToDelete.Click += AddColumn;
            }
        }

        private void AddColumn(object sender, EventArgs e)
        {
            _ui.AddColumn(((ToolStripMenuItem)sender).Text);
        }

        private void DeleteTable(object sender, EventArgs e)
        {
            string tableName = ((ToolStripMenuItem)sender).Text;

            _ui.DeleteTab(tableName);
            _database.Delete(tableName);
        }

        private void TableMenuItem_Click(object sender, EventArgs e)
        {
            _ui.TryShowAddColumnItem();
        }
    }
}