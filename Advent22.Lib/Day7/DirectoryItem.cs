namespace Advent22.Lib.Day7;

public abstract class DirectoryItem
{
    public string Name { get; }

    public DirectoryItem(string name)
    {
        Name = name;
    }

    public abstract int GetSize();
}