using System;

public class CommandLine
{
    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
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

    public static void DisplayColoredText(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);

        //White is the default color for console text
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static string[]? GetUserCommand()
    {
        //Cuts off the C:\Users part of the directory name and displays it to the console
        string[] directoryText = Directory.GetCurrentDirectory().Split(@"\")[2..];
        DisplayColoredText($@"(@{string.Join(@"\", directoryText)})-[~]: ", ConsoleColor.DarkCyan);

        return Console.ReadLine()?.Split(" ");
    }

    public static void Clear()
    {
        Console.Clear();
        DisplayCommandLineText();
    }

    public static void Exit()
    {
        DisplayColoredText("Exiting...", ConsoleColor.DarkGreen);
        Environment.Exit(0);
    }
}