public class Program
{
    public static void Main(string[] args)
    {
        //Can change the valid commands inside that method
        Command.SetValidCommands();

        CommandLine.SetUsername();
        CommandLine.DisplayCommandLineText();
        FileHandler.SetStartingDirectory(@"C:\Users");

        //Main loop
        while (true)
        {
            string[]? userCommand = GetUserCommand();

            if (CheckInvalidCommand(userCommand!))
                continue;

            string commandName = userCommand![0];
            Command command = Command.GetCommandInfo(commandName)!; //it won't be null, it's checked above

            command.Run(userCommand.ToList());
        }
    }

    private static bool CheckInvalidCommand(string[] userCommand)
    {
        if (userCommand == null)
        {
            CommandLine.Error("Command Cannot be Empty");
            return true;
        }
        else if (userCommand.Length == 0)
        {
            CommandLine.Error("Command Length Cannot be Zero");
            return true;
        }

        string commandName = userCommand[0];

        if (!Command.IsValidCommand(commandName))
        {
            CommandLine.Error("Invalid Command, Use `help`");
            return true;
        }

        return false;
    }

    private static string[]? GetUserCommand()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        //Cuts off the C:\Users part of the directory name and displays it to the console
        string[] directoryText = Directory.GetCurrentDirectory().Split(@"\")[2..];
        Console.Write($@"(@{CommandLine.GetUsername()}\{string.Join(@"\", directoryText)})-[~]: ");

        Console.ForegroundColor = ConsoleColor.White;

        return Console.ReadLine()?.Split(" ");
    }
}