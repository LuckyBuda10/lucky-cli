using System;

public class FileHandler
{
    private string _path;
    private FileType _fileType;

    public string Path
    {
        get { return _path; }
    }

    public FileHandler(string path, FileType fileType)
    {
        _path = path;
        _fileType = fileType;

        IsValidPath(_path);
    }

    bool IsValidPath(string path)
    {
        return true;
    }

    public static void SetStartingDirectory(string targetDir)
    {
        try
        {
            //Get the first folder in the Users directory (should be the main user for most people)
            string userFolderPath = Directory.GetDirectories(targetDir, "*", SearchOption.TopDirectoryOnly)[0];
            Directory.SetCurrentDirectory(userFolderPath);
        }
        catch (Exception e)
        {
            CommandLine.Error(e.Message);
        }
    }

    public static void SetDirectory(string targetDir)
    {
        try
        {
            Directory.SetCurrentDirectory(targetDir);
        }
        catch (Exception e)
        {
            CommandLine.Error(e.Message);
        }
    }
}

public enum FileType
{
    Create,
    Read,
    Write,
    Open
}