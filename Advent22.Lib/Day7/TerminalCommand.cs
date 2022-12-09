namespace Advent22.Lib.Day7;

public class TerminalCommand
{
    public CommandType Command { get; set; }
    public string? Argument { get; set; }

    public TerminalCommand(CommandType command, string? argument = null)
    {
        if (command == CommandType.ChangeDir && argument == null)
            throw new ArgumentNullException(argument);
        
        Command = command;
        Argument = argument;
    }
}