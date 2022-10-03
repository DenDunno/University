using System;
using System.Windows.Forms;

public class DatabasePathDialog : IDisposable
{
    private readonly OpenFileDialog _openFileDialog = new OpenFileDialog();
    
    public bool TryGetPathToDatabase(out string path)
    {
        _openFileDialog.InitialDirectory = "c:\\";
        _openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        _openFileDialog.FilterIndex = 2;
        _openFileDialog.RestoreDirectory = true;

        bool success = _openFileDialog.ShowDialog() == DialogResult.OK;
        
        path = success ? _openFileDialog.FileName : string.Empty;

        return success;
    }
    
    public void Dispose()
    {
        _openFileDialog.Dispose();
    }
}