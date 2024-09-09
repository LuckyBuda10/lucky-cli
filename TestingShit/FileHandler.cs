using System;
using System.Diagnostics;

public class FileHandler
{
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

    public static void CreateFile(string name)
    {
        string path = GetFilePath(name);

        if (File.Exists(path))
        {
            CommandLine.Error("File exists");
            return;
        }

        using (FileStream fs = File.Create(path))
        {
            CommandLine.DisplayColoredText("Created: ", ConsoleColor.DarkGreen);
            Console.WriteLine(path);
        }
    }

    public static void OpenFile(string name)
    {
        string path = GetFilePath(name);

        if (path == "" || !File.Exists(path))
        {
            CommandLine.Error("Invalid file path");
            return;
        }

        try
        {
            //Open the file using the default application
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });

            CommandLine.DisplayColoredText("Opened: ", ConsoleColor.DarkGreen);
            Console.WriteLine(name);
        }
        catch (Exception e)
        {
            CommandLine.Error(e.Message);
        }
    }

    private static string GetFilePath(string name)
    {
        try
        {
            return @$"{Directory.GetCurrentDirectory()}\{name}";
        }
        catch
        {
            return "";
        }
    }

    public static void DeleteFile(string name)
    {
        string path = GetFilePath(name);

        if (path == "" || !File.Exists(path))
        {
            CommandLine.Error("File not found");
            return;
        }

        File.Delete(path);
        CommandLine.DisplayColoredText("Deleted: ", ConsoleColor.DarkRed);
        Console.WriteLine(name);
    }

    //Display every folder + file in the current directory
    public static void DisplayDirectory()
    {
        string[] allFolders = Directory.GetDirectories(Directory.GetCurrentDirectory(), "*", SearchOption.TopDirectoryOnly);
        DisplayItemsFromDir(allFolders, "Folders");

        string[] allFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*", SearchOption.TopDirectoryOnly);
        DisplayItemsFromDir(allFiles, "Files");

        if (allFolders.Length == 0 && allFiles.Length == 0)
        {
            Console.WriteLine("Directory is empty");
        }
    }

    static void DisplayItemsFromDir(string[] items, string labelName)
    {
        if (items.Length != 0)
        {
            CommandLine.DisplayColoredText($"--{labelName}--\n", ConsoleColor.DarkGreen);

            for (int i = 0; i < items.Length; i++)
            {
                string curFolder = items[i];

                //Don't display the whole path, only display the items
                Console.WriteLine($"|--{curFolder.Substring(curFolder.LastIndexOf(@"\") + 1)}");
            }
        }
    }
}