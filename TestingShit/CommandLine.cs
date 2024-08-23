using System;

public class CommandLine
{
    private string _commandName;
    private List<string> _args = new();
    private static string? username;

    public CommandLine(string commandName, List<string> args)
    {
        _commandName = commandName;
        _args = args;

        CheckValidity();
    }

    void CheckValidity()
    {
        if (!Command.IsValidCommand(_commandName))
            Error("Invalid command");

        Command? command = Command.GetCommandInfo(_commandName);

        if (command == null)
        {
            Error("Command not found");
        }

        if (_args.Count != command?.NumArgs)
        {
            Error("Invalid number of arguments");
        }
    }

    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"Error: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
    }

    public static void DisplayCommandLineText()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("--Lucky's File Management CLI-----");
        Console.WriteLine("----------------------------------");
    }

    public static void SetUsername()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Username: ");

        string? _username = Console.ReadLine();

        if (_username != null)
        {
            username = _username;
            Console.Clear();
        }
        else
        {
            Error("Username cannot be null");
        }
    }

    public static string GetUsername()
    {
        return username!;
    }
}