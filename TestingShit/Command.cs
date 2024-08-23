using System;
using System.IO;

public class Command
{
    //Information about the commands
    private string _name;
    private string _description;
    private int _numArgs;

    private static List<Command> validCommands = new();

    public string Name
    {
        get { return _name; }
    }

    public string Description
    {
        get { return _description; }
    }

    public int NumArgs
    {
        get { return _numArgs; }
    }

    public Command(string name, string description, int numArgs)
    {
        _name = name;
        _description = description;
        _numArgs = numArgs;
    }

    //Commands that the program can run
    public static void SetValidCommands()
    {
        validCommands.Add(new Command("args", "Not implemented yet", 1));
        validCommands.Add(new Command("clear", "Not implemented yet", 0));
        validCommands.Add(new Command("create", "Not implemented yet", 1));
        validCommands.Add(new Command("dir", "Not implemented yet", 1));
        validCommands.Add(new Command("exit", "Not implemented yet", 0));
        validCommands.Add(new Command("help", "Display all valid commands", 0));
        validCommands.Add(new Command("open", "Not implemented yet", 1));
        validCommands.Add(new Command("write", "Not implemented yet", -1));
    }

    public static List<Command> GetValidCommands()
    {
        return new List<Command>(validCommands);
    }

    public static bool IsValidCommand(string commandName)
    {
        return validCommands.Any(c => c.Name == commandName);
    }

    public static Command? GetCommandInfo(string commandName)
    {
        return validCommands.Find(c => c.Name == commandName);
    }

    //userArgs[0] = command name,
    public void Run(List<string> userArgs)
    {
        switch (this.Name)
        {
            case "args":
                break;
            case "clear":
                Clear();
                break;
            case "create":
                break;
            case "dir":
                Dir(userArgs[1]);
                break;
            case "exit":
                Exit();
                break;
            case "help":
                Help();
                break;
            case "open":
                break;
            case "write":
                break;
            default:
                Console.Write("Command not found");
                break;
        }
    }

    void Clear()
    {
        Console.Clear();
        CommandLine.DisplayCommandLineText();
    }

    void Exit()
    {
        Environment.Exit(0);
    }

    void Help()
    {
        for (int i = 0; i < validCommands.Count; i++)
        {
            Command validCommand = validCommands[i];
            Console.WriteLine($"{validCommand.Name} - {validCommand.Description}");
        }
    }

    void Dir(string path)
    {
        FileHandler.SetDirectory(path);
    }
}