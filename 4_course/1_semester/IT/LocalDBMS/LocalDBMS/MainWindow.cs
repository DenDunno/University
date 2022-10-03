using System;
using System.Windows.Forms;

namespace LocalDBMS
{
    public partial class MainWindow : Form
    {
        private readonly UI _ui;
        private Database _database;
        
        public MainWindow()
        {
            InitializeComponent();
            _ui = new UI(this);
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

        private void DeleteItem_Hover(object sender, EventArgs e)
        {
            var deleteTableItem = (ToolStripMenuItem)sender;
            deleteTableItem.DropDownItems.Clear();

            foreach (DatabaseElement databaseElement in _database.TablesNames)
            {
                ToolStripItem tableToDelete = deleteTableItem.DropDownItems.Add(databaseElement.Name);
                tableToDelete.Click += DeleteTable;
            }
        }

        private void CreateDatabase()
        {
            _ui.SetUpUI();
            _database = new Database(TextBox.Text);
        }

        private void CreateTable()
        {
            _ui.CreateDataGridView();
            _database.Add(new Table(TextBox.Text));
        }

        private void DeleteTable(object sender, EventArgs e)
        {
            string tableName = ((ToolStripMenuItem)sender).Text;

            _ui.DeleteTab(tableName);
            _database.Delete(tableName);
        }
    }
}