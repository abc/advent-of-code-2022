using System.Text;

namespace Advent22.Lib.Day7;

public class Directory : DirectoryItem
{
    public ICollection<DirectoryItem> Items { get; }

    public Directory(string name) : base(name)
    {
        Items = new List<DirectoryItem>();
    }

    public override int GetSize()
    {
        return Items.Sum(i => i.GetSize());
    }

    public override string ToString()
    {
        var displayName = Name;
        if (string.IsNullOrWhiteSpace(displayName))
            displayName = "/";
        
        return $"- {displayName} (dir)";
    }

    public string Tree(int indent = 0)
    {
        var builder = new StringBuilder();
        builder.Append(GetIndent(indent));
        builder.AppendLine(ToString());

        foreach (var item in Items.OrderBy(i => i.Name))
        {
            if (item is Directory dir)
            {
                builder.Append(dir.Tree(indent + 1));
            }
            else
            {
                builder.Append(GetIndent(indent + 1));
                builder.AppendLine(item.ToString());
            }
        }
        
        return builder.ToString();
    }

    public string GetIndent(int indent)
    {
        var output = string.Empty;
        for (int i = 0; i < indent; i++)
        {
            output += "  ";
        }

        return output;
    }

    public IEnumerable<Directory> GetDirectories (bool recursive = false)
    {
        var directories = Items
            .Where(i => i is Directory)
            .Cast<Directory>();

        if (recursive)
            directories = directories.SelectMany(i => i.GetDirectories(recursive));
        
        return directories.Prepend(this);
    }

    public IEnumerable<File> GetFiles(bool recursive = false)
    {
        var files = Items
            .Where(i => i is File)
            .Cast<File>()
            .ToList();

        if (!recursive)
            return files;
        
        foreach (var directory in GetDirectories(true).Skip(1))
        {
            files.AddRange(directory.GetFiles());
        }
        
        return files;
    }
}