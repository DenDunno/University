using System;
using System.Windows.Forms;

namespace LocalDBMS
{
    public partial class MainWindow : Form
    {
        private readonly UI _ui;
        private Database _database;
        private DatabaseSave _databaseSave;
        
        public MainWindow()
        {
            InitializeComponent();
            _ui = new UI(this);
            _databaseSave = new DatabaseSave(TabControl);
            deleteToolStripMenuItem.MouseHover += OnDeleteItemHover;
            AddColumnMenuItem.MouseHover += OnAddColumnHover;
        }

        private void CreateDatabase_Click(object sender, EventArgs e)
        {
            _ui.ShowInputPanel(CreateDatabase);
        }

        private void LoadDatabase_Click(object sender, EventArgs e)
        {
        }

        private void CreateTable_Click(object sender, EventArgs e)
        {
            _ui.ShowInputPanel(CreateTable);
        }

        private void OnDeleteItemHover(object sender, EventArgs e)
        {
            var deleteTableItem = (ToolStripMenuItem)sender;
            deleteTableItem.DropDownItems.Clear();

            foreach (DatabaseElement databaseElement in _database.TablesNames)
            {
                ToolStripItem tableToDelete = deleteTableItem.DropDownItems.Add(databaseElement.Name);
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

        private void CreateDatabase()
        {
            _ui.SetUpUI();
            _database = new Database(TextBox.Text);
        }

        private void CreateTable()
        {
            try
            {
                _database.Add(new Table(TextBox.Text));
                _ui.CreateDataGridView();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

        private void SaveClick(object sender, EventArgs e)
        {
            _databaseSave.Save("D:/");
        }
    }
}