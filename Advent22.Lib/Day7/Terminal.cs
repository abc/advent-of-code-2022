namespace Advent22.Lib.Day7;

public class Terminal
{
    public Directory Root { get; set; }
    
    public Stack<Directory> WorkingDirectory { get; set; }

    public string GetWorkingDirectory => string.Join("/", WorkingDirectory.Reverse().Select(d => d.Name)) + "/";

    public Terminal()
    {
        Root = new Directory("");
        WorkingDirectory = new Stack<Directory>();
        WorkingDirectory.Push(Root);
    }

    public void AddItem<T>(T item) where T: DirectoryItem
    {
        WorkingDirectory.Peek().Items.Add(item);
    }

    public void RunCommand(TerminalCommand command)
    {
        switch (command.Command)
        {
            case CommandType.ChangeDir:
                RunChangeDirCommand(command.Argument!);
                break;
            case CommandType.List:
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public void RunChangeDirCommand(string argument)
    {
        switch (argument)
        {
            // Up one level
            case "..":
                WorkingDirectory.Pop();
                break;
            // Return to root
            case "/":
                WorkingDirectory.Clear();
                WorkingDirectory.Push(Root);
                break;
            case "":
                throw new InvalidDataException();
            case null:
                throw new InvalidDataException();
            default:
                var targetDir = (Directory)WorkingDirectory.Peek().Items.Single(i => i.Name == argument); 
                WorkingDirectory.Push(targetDir);
                break;
        }
    }
}