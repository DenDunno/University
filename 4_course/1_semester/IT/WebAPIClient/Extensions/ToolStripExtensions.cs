using System.Windows.Forms;

public static class ToolStripExtensions
{
    public static void DeleteTab(this TabControl tabControl, string name)
    {
        for (int i = 0; i < tabControl.TabCount; ++i)
        {
            TabPage page = tabControl.TabPages[i];
            
            if (page.Text == name)
            {
                tabControl.TabPages.Remove(page);
                break;
            }
        }
    }
}