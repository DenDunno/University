using System;
using System.Windows.Forms;

namespace LocalDBMS
{
    public partial class MainWindow : Form
    {
        private readonly UI _ui;
        
        public MainWindow()
        {
            InitializeComponent();
            _ui = new UI(this);
        }

        private void CreateDatabaseButton_Click(object sender, EventArgs e)
        {
            string databaseName = DatabaseNameTextBox.Text;
            
            if (databaseName != string.Empty)
            {
                var database = new Database(databaseName);
                _ui.HideEntryPanel();
                _ui.CreateDataGridView();
                _ui.SetWindowName(databaseName);
            }
            else
            {
                MessageBox.Show("Name cannot be empty"); 
            }
            
        }

        private void LoadDatabaseButton_Click(object sender, EventArgs e)
        {
            if (_ui.TryGetPathToDatabase(out string path))
            {
                MessageBox.Show("China");
            }
        }
    }
}