using Advent22.Lib.Day7;
using Directory = Advent22.Lib.Day7.Directory;
using File = Advent22.Lib.Day7.File;

namespace Advent22.Tests;

public class Day7Tests : AdventTests<Day7>
{
    public override string GetSampleString() => 
        "$ cd /\n" +
        "$ ls\n" +
        "dir a\n" +
        "14848514 b.txt\n" +
        "8504156 c.dat\n" +
        "dir d\n" +
        "$ cd a\n" +
        "$ ls\n" +
        "dir e\n" +
        "29116 f\n" +
        "2557 g\n" +
        "62596 h.lst\n" +
        "$ cd e\n" +
        "$ ls\n" +
        "584 i\n" +
        "$ cd ..\n" +
        "$ cd ..\n" +
        "$ cd d\n" +
        "$ ls\n" +
        "4060174 j\n" +
        "8033020 d.log\n" +
        "5626152 d.ext\n" +
        "7214296 k\n";

    [Theory]
    [InlineData("$ cd /")]
    [InlineData("$ ls")]
    [InlineData("$ cd a")]
    [InlineData("$ cd ..")]
    public void IsCommand_WithCommands_ReturnsTrue(string command)
    {
        var output = GetDay().IsCommand(command);
        output.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("dir a")]
    [InlineData("14848514 b.txt")]
    [InlineData("62596 h.lst")]
    [InlineData("4060174 j")]
    public void IsCommand_WithOutput_ReturnsFalse(string command)
    {
        var output = GetDay().IsCommand(command);
        output.Should().BeFalse();
    }
    
    [Theory]
    [InlineData("$ cd /", CommandType.ChangeDir, "/")]
    [InlineData("$ ls", CommandType.List, null)]
    [InlineData("$ cd a", CommandType.ChangeDir, "a")]
    [InlineData("$ cd ..", CommandType.ChangeDir, "..")]
    public void ParseCommand_WithCommands_ReturnsExpected(string command, CommandType expected, string param)
    {
        var output = GetDay().ParseCommand(command);
        output.Command.Should().Be(expected);
        output.Argument.Should().Be(param);
    }

    [Fact]
    public static void GetWorkingDirectory_WithNoChanges_ReturnsRoot()
    {
        var term = new Terminal();
        term.GetWorkingDirectory.Should().Be("/");
    }
    
    [Fact]
    public static void GetSize_WithFile_ShouldReturnFileSize()
    {
        var file = new File("test.txt", 1024);
        file.GetSize().Should().Be(1024);
    }
    
    [Fact]
    public static void GetSize_WithEmptyDir_ShouldReturnZero()
    {
        var dir = new Directory("directory");
        dir.GetSize().Should().Be(0);
    }
    
    [Fact]
    public static void GetSize_WithDirContainingOneFile_ShouldReturnFileSize()
    {
        var dir = new Directory("directory");
        dir.Items.Add(new File("test.txt", 1024));
        dir.GetSize().Should().Be(1024);
    }
    
    [Fact]
    public static void GetSize_WithDirContainingMultipleFile_ShouldReturnSumOfFileSizes()
    {
        var dir = new Directory("directory");
        dir.Items.Add(new File("test.txt", 1024));
        dir.Items.Add(new File("test2.txt", 1024));
        dir.Items.Add(new File("test3.txt", 1024));
        dir.Items.Add(new File("test4.txt", 1024));
        dir.GetSize().Should().Be(4096);
    }
    
    [Fact]
    public static void AddItem_WithDirectory_CreatesDirectory()
    {
        var term = new Terminal();
        
        term.AddItem(new Directory("home"));
        term.WorkingDirectory.Peek().Should().BeSameAs(term.Root);
        term.Root.Items.Count().Should().Be(1);
        term.Root.Items.First().Name.Should().Be("home");
        term.Root.Items.First().GetSize().Should().Be(0);
    }
    
    [Fact]
    public static void AddItem_WithFile_AddsFile()
    {
        var term = new Terminal();
        
        term.AddItem(new File("info.txt", 1234));
        term.WorkingDirectory.Peek().Should().BeSameAs(term.Root);
        term.Root.Items.Count().Should().Be(1);
        term.Root.Items.First().Name.Should().Be("info.txt");
        term.Root.Items.First().GetSize().Should().Be(1234);
    }
    
    [Fact]
    public static void GetWorkingDirectory_WithOneDir_AsExpected()
    {
        var term = new Terminal();
        
        // Create /a/
        term.AddItem(new Directory("a"));
        
        // cd into /a/
        term.RunChangeDirCommand("a");
        term.GetWorkingDirectory.Should().Be("/a/");
    }
    
    [Fact]
    public static void GetWorkingDirectory_WithUpOneLevel_AsExpected()
    {
        var term = new Terminal();
        
        // Create /var/
        term.AddItem(new Directory("var"));
        
        // cd into /var/
        term.RunChangeDirCommand("var");
        term.GetWorkingDirectory.Should().Be("/var/");
        
        // Create /var/log
        term.AddItem(new Directory("log"));
        
        // cd into /var/log
        term.RunChangeDirCommand("log");
        term.GetWorkingDirectory.Should().Be("/var/log/");
        
        // cd up one level
        term.RunChangeDirCommand("..");
        term.GetWorkingDirectory.Should().Be("/var/");
    }
    
    [Fact]
    public static void GetWorkingDirectory_WithRoot_AsExpected()
    {
        var term = new Terminal();
        
        // Create /var/
        term.AddItem(new Directory("var"));
        
        // cd into /var/
        term.RunChangeDirCommand("var");
        term.GetWorkingDirectory.Should().Be("/var/");
        
        // Create /var/log
        term.AddItem(new Directory("log"));
        
        // cd into /var/log
        term.RunChangeDirCommand("log");
        term.GetWorkingDirectory.Should().Be("/var/log/");
        
        // cd to /
        term.RunChangeDirCommand("/");
        term.GetWorkingDirectory.Should().Be("/");
    }

    [Theory]
    [InlineData("dir a", typeof(Directory), "a", 0)]
    [InlineData("14848514 b.txt", typeof(File), "b.txt", 14848514)]
    [InlineData("8504156 c.dat", typeof(File), "c.dat", 8504156)]
    [InlineData("dir d", typeof(Directory), "d", 0)]
    [InlineData("dir e", typeof(Directory), "e", 0)]
    [InlineData("29116 f", typeof(File), "f", 29116)]
    [InlineData("2557 g", typeof(File), "g", 2557)]
    [InlineData("62596 h.lst", typeof(File), "h.lst", 62596)]
    [InlineData("584 i", typeof(File), "i", 584)]
    [InlineData("4060174 j", typeof(File), "j", 4060174)]
    [InlineData("8033020 d.log", typeof(File), "d.log", 8033020)]
    [InlineData("5626152 d.ext", typeof(File), "d.ext", 5626152)]
    [InlineData("7214296 k", typeof(File), "k", 7214296)]
    public void ParseItem_WithSampleInput_AsExpected(string input, Type type, string fileName, int size)
    {
        var output = GetDay().ParseItem(input);
        output.Should().BeOfType(type);
        output.Name.Should().Be(fileName);
        output.GetSize().Should().Be(size);
    }

    // [Fact]
    // public void ProcessPuzzleInput_WithSampleInput_AsExpected()
    // {
    //     var reader = new StringReader(InputData);
    //     var terminal = GetDay().ProcessPuzzleInput(reader);
    //     var tree = terminal.Root.Tree();
    //     var expected = 
    //         "- / (dir)\n" +
    //         "  - a (dir)\n" +
    //         "    - e (dir)\n" +
    //         "      - i (file, size=584)\n" +
    //         "    - f (file, size=29116)\n" +
    //         "    - g (file, size=2557)\n" +
    //         "    - h.lst (file, size=62596)\n" +
    //         "  - b.txt (file, size=14848514)\n" +
    //         "  - c.dat (file, size=8504156)\n" +
    //         "  - d (dir)\n" +
    //         "    - d.ext (file, size=5626152)\n" +
    //         "    - d.log (file, size=8033020)\n" +
    //         "    - j (file, size=4060174)\n" +
    //         "    - k (file, size=7214296)\n";
    //     tree.Should().Be(expected);
    // }

    [Fact]
    public static void GetDirectories_RootOnly_ReturnsItself()
    {
        var dir = new Directory("root");
        var result = dir.GetDirectories();
        var expected = new List<Directory> { new Directory("root") };
        result.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public static void GetDirectories_NonRecursive_AsExpected()
    {
        var root = new Directory("");
        var home = new Directory("home");
        var var = new Directory("var");
        var etc = new Directory("etc");
        root.Items.Add(home);
        root.Items.Add(var);
        root.Items.Add(etc);

        var result = root.GetDirectories();
        var expected = new List<Directory>
        {
            root,
            home,
            var,
            etc
        };
        
        result.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public static void GetDirectories_Recursive_AsExpected()
    {
        var root = new Directory("");
        var home = new Directory("home");
        var var = new Directory("var");
        var etc = new Directory("etc");
        var www = new Directory("www");
        var.Items.Add(www);
        root.Items.Add(home);
        root.Items.Add(var);
        root.Items.Add(etc);

        var result = root.GetDirectories(true);
        var expected = new List<Directory>
        {
            root,
            home,
            var,
            etc,
            www
        };
        
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public static void GetFiles_NonRecursive_AsExpected()
    {
        var dir = new Directory("test");
        dir.Items.Add(new File("1.txt", 1000));
        dir.Items.Add(new File("2.txt", 1000));
        dir.Items.Add(new File("3.txt", 1000));
        dir.Items.Add(new File("4.txt", 1000));
        var dir2 = new Directory("test2");
        dir2.Items.Add(new File("a.txt", 1000));
        dir2.Items.Add(new File("b.txt", 1000));
        dir2.Items.Add(new File("c.txt", 1000));
        dir2.Items.Add(new File("d.txt", 1000));
        var expected = new List<File>
        {
            new File("1.txt", 1000),
            new File("2.txt", 1000),
            new File("3.txt", 1000),
            new File("4.txt", 1000)
        };
        var result = dir.GetFiles(false);
        result.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public static void GetFiles_Recursive_AsExpected()
    {
        var dir = new Directory("test");
        dir.Items.Add(new File("1.txt", 1000));
        dir.Items.Add(new File("2.txt", 1000));
        var dir2 = new Directory("blah");
        dir2.Items.Add(new File("3.txt", 1000));
        dir2.Items.Add(new File("4.txt", 1000));
        dir.Items.Add(dir2);
        var result = dir.GetFiles(true);
        var expected = new List<File>
        {
            new File("1.txt", 1000),
            new File("2.txt", 1000),
            new File("3.txt", 1000),
            new File("4.txt", 1000)
        };
        
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GetDirectories_SampleData_SizesMatch()
    {
        var reader = new StringReader(GetSampleString());
        var terminal = GetDay().ProcessPuzzleInput(reader);
        var directories = terminal.Root.GetDirectories(true);
        
        directories.Single(d => d.Name == "e").GetSize().Should().Be(584);
        directories.Single(d => d.Name == "a").GetSize().Should().Be(94853);
        directories.Single(d => d.Name == "d").GetSize().Should().Be(24933642);
        terminal.Root.GetSize().Should().Be(48381165);
    }

    [Fact]
    public void Part1Solution_SampleData_95437()
    {
        var reader = new StringReader(GetSampleString());
        var input = GetDay().ProcessPuzzleInput(reader);
        var result = GetDay().Task1Solution(input);
        result.Should().Be(95437);
    }
    
    [Fact]
    public void Part2Solution_SampleData_95437()
    {
        var reader = new StringReader(GetSampleString());
        var input = GetDay().ProcessPuzzleInput(reader);
        var result = GetDay().Task2Solution(input);
        result.Should().Be(24933642);
    }
}