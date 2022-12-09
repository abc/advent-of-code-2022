namespace Advent22.Lib.Day7;

public class File : DirectoryItem
{
    public int Size { get; }

    public File (string name, int size) : base(name)
    {
        Size = size;
    }

    public override int GetSize()
    {
        return Size;
    }
    
    public override string ToString()
    {
        return $"- {Name} (file, size={Size})";
    }
}