using System.Windows.Forms;

public class Database : DatabaseElement
{
    public Database(string name) : base(name)
    {
    }

    public void Load(string path)
    {
        MessageBox.Show(path);
    }

    public void Save(string path)
    {
    }
}