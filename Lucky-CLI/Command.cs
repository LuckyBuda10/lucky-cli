public class Command
{
    //Information about the commands
    private string _name;
    private string _description;
    private int _numArgs;

    private static List<Command> validCommands = new();

    public string Name
    {
        get => _name;
    }

    public string Description
    {
        get => _description;
    }

    public int NumArgs
    {
        get => _numArgs;
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
        validCommands.Add(new Command("clear", "Clear the terminal", 0));
        validCommands.Add(new Command("cdir", "Change current directory", 1));
        validCommands.Add(new Command("dir", "View all items in active directory", 0));
        validCommands.Add(new Command("del", "Delete file", 1));
        validCommands.Add(new Command("exit", "Close the program", 0));
        validCommands.Add(new Command("help", "Display all valid commands", 0));
        validCommands.Add(new Command("new", "Create new file", 1));
        validCommands.Add(new Command("open", "Open file", 1));
    }

    public static List<Command> GetValidCommands()
    {
        return new List<Command>(validCommands);
    }

    public static bool CheckInvalidCommand(string[] userCommand)
    {
        if (userCommand == null)
        {
            CommandLine.Error("Command cannot be empty");
            return true;
        }

        string commandName = userCommand[0];

        //Make sure the command is valid
        if (!validCommands.Any(c => c.Name == commandName))
        {
            CommandLine.Error("Invalid Command, use `help`");
            return true;
        }

        //-1 to account for name arg, ensure correct num args
        if (userCommand.Length - 1 != GetCommandInfo(commandName)!.NumArgs)
        {
            CommandLine.Error("Invalid number of args");
            return true;
        }

        //is a valid command
        return false;
    }

    //Won't be null, as command validity is checked before this function
    public static Command? GetCommandInfo(string commandName)
    {
        return validCommands.Find(c => c.Name == commandName);
    }

    //userArgs[0] = command name
    public void Run(List<string> userArgs)
    {
        switch (_name)
        {
            case "clear":
                CommandLine.Clear();
                break;
            case "cdir":
                FileHandler.SetDirectory(userArgs[1]);
                break;
            case "dir":
                FileHandler.DisplayDirectory();
                break;
            case "del":
                FileHandler.DeleteFile(userArgs[1]);
                break;
            case "exit":
                CommandLine.Exit();
                break;
            case "help":
                Help();
                break;
            case "new":
                FileHandler.CreateFile(userArgs[1]);
                break;
            case "open":
                FileHandler.OpenFile(userArgs[1]);
                break;
            default:
                Console.Write("Command not found");
                break;
        }
    }

    //Display every valid command
    void Help()
    {
        for (int i = 0; i < validCommands.Count; i++)
        {
            Command validCommand = validCommands[i];

            CommandLine.DisplayColoredText($"{validCommand.Name}", ConsoleColor.Magenta);
            Console.WriteLine($" - {validCommand.Description}");
        }
    }
}