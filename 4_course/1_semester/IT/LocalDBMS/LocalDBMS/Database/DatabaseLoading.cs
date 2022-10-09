using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

public class DatabaseLoading
{
    public bool TryLoad(out DatabaseSaveData databaseSaveData)
    {
        bool success = TryOpenJson(out string path);
        databaseSaveData = null;
        
        if (success)
        {
            databaseSaveData = ParseJson(path);
        }

        return success;
    }

    private bool TryOpenJson(out string path)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = "c:\\";
        openFileDialog.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;

        bool success = openFileDialog.ShowDialog() == DialogResult.OK;
        
        path = success ? openFileDialog.FileName : string.Empty;

        return success;
    }

    private DatabaseSaveData ParseJson(string path)
    {
        return JsonConvert.DeserializeObject<DatabaseSaveData>(File.ReadAllText(path));
    }
}