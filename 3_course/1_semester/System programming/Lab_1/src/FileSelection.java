import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;
import javax.swing.filechooser.FileSystemView;
import java.io.File;

public class FileSelection
{
    public File getFile()
    {
        File selectedFile = null;

        var fileChooser = new JFileChooser(FileSystemView.getFileSystemView().getHomeDirectory());
        var filter = new FileNameExtensionFilter("text files", "txt");

        fileChooser.setFileFilter(filter);
        int result = fileChooser.showOpenDialog(null);

        if (result == JFileChooser.APPROVE_OPTION)
        {
            selectedFile = fileChooser.getSelectedFile();
        }

        return selectedFile;
    }
}
