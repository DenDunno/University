using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using DbmsEmulator.Models.RequestModels;
using Newtonsoft.Json;

namespace LocalDBMS
{
    public partial class MainWindow : Form
    {
        private string _databaseName;
        private readonly HttpClient _httpClient;
        
        public MainWindow()
        {
            InitializeComponent();
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (asd, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
        }
        
        private async void CreateDatabaseButton_Click(object sender, EventArgs e)
        {
            string url = $"https://localhost:7006/database/create/{CreateDatabaseTextBox.Text}";
            
            HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, null);
            
            Output.Text = await responseMessage.Content.ReadAsStringAsync();
        }

        private void PutValueButton_Click(object sender, EventArgs e)
        {
            string column = PutColumnIndexTextBox.Text;
            string row = PutRowIndexTextBox.Text;
            string value = PutValueTextBox.Text;

            

            //https://localhost:7006/table/add/column
        }

        private async void CreateTableButton_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(new TableCreatePostData()
            {
                databaseName = _databaseName,
                tableName = CreateTableTextBox.Text
            });
            
            string url = $"https://localhost:7006/table/create/";
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, httpContent);
                    
            Output.Text = await responseMessage.Content.ReadAsStringAsync();
        }

        private async void SaveDatabaseButton_Click(object sender, EventArgs e)
        {
            string url = $"https://localhost:7006/database/save/{SaveDatabaseTextButton.Text}";
            
            HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, null);
            
            Output.Text = await responseMessage.Content.ReadAsStringAsync();
        }

        private async void GetDatabaseButton_Click(object sender, EventArgs e)
        {
            string url = $"https://localhost:7006/database/get/{GetDatabaseTextBox.Text}";
            
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
                    
            Output.Text = await responseMessage.Content.ReadAsStringAsync();
        }

        private async void DeleteTableButton_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(new TableCreatePostData()
            {
                databaseName = _databaseName,
                tableName = DeleteTableTextBox.Text
            });
            
            string url = $"https://localhost:7006/table/drop";
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, httpContent);
                    
            Output.Text = await responseMessage.Content.ReadAsStringAsync();
        }

        private async void AddColumnButton_Click(object sender, EventArgs e)
        {
            string tableName = AddColumnTextBox.Text;

            string json = JsonConvert.SerializeObject(new ColumnInTable()
            {
                BaseAddress = new BaseAddress()
                {
                    DatabaseName = _databaseName,
                    TableName = tableName,
                },
                ColumnType = "COLOR"
            });
            
            string url = $"https://localhost:7006/table/add/column";
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, httpContent);
                    
            Output.Text = await responseMessage.Content.ReadAsStringAsync();
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            // string tableName = AddRowTextBox.Text;
            //
            // string json = JsonConvert.SerializeObject(new RowInTable()
            // {
            //     BaseAddress = new BaseAddress()
            //     {
            //         DatabaseName = _databaseName,
            //         TableName = tableName,
            //     },
            //     ColumnType = "COLOR"
            // });
            //
            // string url = $"https://localhost:7006/table/add/column";
            // StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //
            // HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, httpContent);
            //         
            // Output.Text = await responseMessage.Content.ReadAsStringAsync();
        }

        private void RemoveColumnButton_Click(object sender, EventArgs e)
        {
            string tableName = AddColumnTextBox.Text;
            string index = RemoveColumnTextBox.Text;
        }

        private void RemoveRowButton_Click(object sender, EventArgs e)
        {
            string tableName = RemoveRowTextBox.Text;
            string index = RemoveRowIndexTextBox.Text;
        }

        private void SetupDatabaseButton_Click(object sender, EventArgs e)
        {
            _databaseName = SetupDatabaseTextbox.Text;
        }

        private async void DeleteDatabaseButton_Click(object sender, EventArgs e)
        {
            string url = $"https://localhost:7006/database/drop/{DeleteDatabaseTextBox.Text}";
            
            HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, null);
            
            Output.Text = await responseMessage.Content.ReadAsStringAsync();
        }
    }
}