public class Program
{
    public static void Main(string[] args)
    {
        //Can set valid commands inside this method
        Command.SetValidCommands();

        //Set up the terminal in user directory
        CommandLine.DisplayCommandLineText();
        FileHandler.SetDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

        //Main loop
        while (true)
        {
            string[]? userCommand = CommandLine.GetUserCommand();

            //Reprompt the user if they put an invalid command
            if (Command.CheckInvalidCommand(userCommand!))
                continue;

            //It won't be null, it's checked in above function
            string commandName = userCommand![0];
            Command command = Command.GetCommandInfo(commandName)!;

            command.Run(userCommand.ToList());
        }
    }
}