namespace Advent22.Lib.Day7;

public class Day7 : Day
{
    // Go through each line in the input
    // v Determine whether the line is a command or an output
    // If the line is a command:
    // v Determine what kind of command (ls or cd)
    // v If the command is a cd, update our working directory path.
    // v If the command is an ls, do nothing.
    // If the line is output:
    // v Determine whether the item is a directory or a file.
    // If the item is a file, add the file to the current directory with size.
    // If the item is a directory, add the directory to the structure.
    public const int TotalDiskSpace = 70000000;
    public const int FreeSpaceRequired = 30000000;
    public override int DayNumber => 7;
    
    public bool IsCommand(string input)
    {
        return input.StartsWith('$');
    }

    public Terminal ProcessPuzzleInput(TextReader reader)
    {
        var result = new Terminal();
        
        while (reader.ReadLine() is { } line)
        {
            if (IsCommand(line))
            {
                var command = ParseCommand(line);
                result.RunCommand(command);
            }
            else
            {
                var item = ParseItem(line);
                result.AddItem(item);
            }
        }

        return result;
    }

    public TerminalCommand ParseCommand(string input)
    {
        if (!IsCommand(input))
        {
            throw new ArgumentException("input was not a valid command", nameof(input));
        }

        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var type = parts[1].ToLowerInvariant() switch
        {
            "cd" => CommandType.ChangeDir,
            "ls" => CommandType.List,
            _ => throw new ArgumentOutOfRangeException(nameof(input), $"got {parts[1]}, expected cd or ls")
        };

        return new TerminalCommand(type, parts.Length > 2 ? parts[2] : null);
    }

    public DirectoryItem ParseItem(string input)
    {
        if (IsCommand(input))
        {
            throw new ArgumentException("input was a command, not a valid file/directory", nameof(input));
        }

        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var sizeString = parts[0];
        var name = parts[1];
        if (int.TryParse(sizeString, out int size))
        {
            return new File(name, size);
        }

        if (sizeString == "dir")
        {
            return new Directory(name);
        }

        throw new ArgumentException("input was not a valid file/directory", nameof(input));
    }

    public int Part1Solution(TextReader reader)
    {
        var terminal = ProcessPuzzleInput(reader);
        var result = terminal.Root.GetDirectories(true)
            .Where(d => d.GetSize() <= 100000)
            .Sum(d => d.GetSize());
        return result;
    }
    
    public int Part2Solution(TextReader reader)
    {
        var terminal = ProcessPuzzleInput(reader);
        var freeSpace = TotalDiskSpace - terminal.Root.GetSize();
        var deletionsNeeded = FreeSpaceRequired - freeSpace;
        var result = terminal.Root
            .GetDirectories(true)
            .OrderBy(d => d.GetSize())
            .First(d => d.GetSize() >= deletionsNeeded);
        return result.GetSize();
    }

    public override string Part1Solution()
    {
        var reader = GetInput();
        return Part1Solution(reader).ToString();
    }
    
    public override string Part2Solution()
    {
        var reader = GetInput();
        return Part2Solution(reader).ToString();
    }
}