using System;
using System.Data;
using System.Windows.Forms;

namespace LocalDBMS
{
    public partial class MainWindow : Form
    {
        private readonly UI _ui;
        private readonly Database _database = new Database();

        public MainWindow()
        {
            InitializeComponent();
            _ui = new UI(this);
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
            if (_database.TryLoad(out DatabaseSaveData databaseSaveData))
            {
                _database.Clear();
                _ui.HideInputPanel();
                _ui.SetUpUI(databaseSaveData.Name);

                for (int i = 0; i < databaseSaveData.TableNames.Count; ++i)
                {
                    _ui.CreateDataGridView();
                    _database.Add(databaseSaveData.TableNames[i]);
                    
                    TabPage tabPage = TabControl.TabPages[i];
                    tabPage.Text = databaseSaveData.TableNames[i];
                    var dataGridView = tabPage.Controls[0] as DataGridView;
                    dataGridView.Columns.Clear();
                    
                    Table table = databaseSaveData.Tables[i];

                    var dataTable = new DataTable();

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
                    
                    dataGridView.DataSource = dataTable;

                    for (int j = 0; j < table.Fields.Count; j++)
                    {
                        dataGridView.Columns[j].Name = table.Fields[j];
                        dataGridView.Columns[j].HeaderText = table.Fields[j];
                    }
                }
            }
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