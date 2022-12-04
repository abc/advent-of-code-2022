using Advent22.Lib.Day4;

namespace Advent22.Tests;

public class Day4Tests
{
    private const string InputData =
        "2-4,6-8\n" +
        "2-3,4-5\n" +
        "5-7,7-9\n" +
        "2-8,3-7\n" +
        "6-6,4-6\n" +
        "2-6,4-8";

    [Theory]
    [InlineData("2-4", new int[] {2, 3, 4})]
    [InlineData("6-8", new int[] {6, 7, 8})]
    [InlineData("2-3", new int[] {2, 3})]
    [InlineData("4-5", new int[] {4, 5})]
    [InlineData("5-7", new int[] {5, 6, 7})]
    [InlineData("7-9", new int[] {7, 8, 9})]
    [InlineData("2-8", new int[] {2, 3, 4, 5, 6, 7, 8})]
    [InlineData("3-7", new int[] {3, 4, 5, 6, 7})]
    [InlineData("6-6", new int[] {6})]
    [InlineData("4-6", new int[] {4, 5, 6})]
    [InlineData("2-6", new int[] {2, 3, 4, 5, 6})]
    [InlineData("4-8", new int[] {4, 5, 6, 7, 8})]
    public static void ParseRange_SampleInput_ExpectedOutput(string input, int[] expected)
    {
        var actual = Day4.ParseRange(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static void ProcessPuzzleInput_SampleData_ReturnsExpected()
    {
        var expected = new List<ElfPair>
        {
            new ElfPair
            {
                FirstElfAreas = new int[] { 2, 3, 4 },
                SecondElfAreas = new int[] { 6, 7, 8 }
            },
            new ElfPair
            {
                FirstElfAreas = new int[] {2, 3},
                SecondElfAreas = new int[] {4, 5}
            },
            new ElfPair
            {
                FirstElfAreas = new int[] {5, 6, 7},
                SecondElfAreas = new int[] {7, 8, 9}
            },
            new ElfPair
            {
                FirstElfAreas = new int[] {2, 3, 4, 5, 6, 7, 8},
                SecondElfAreas = new int[] {3, 4, 5, 6, 7}
            },
            new ElfPair
            {
                FirstElfAreas = new int[] {6},
                SecondElfAreas = new int[] {4, 5, 6}
            },
            new ElfPair
            {
                FirstElfAreas = new int[] {2, 3, 4, 5, 6},
                SecondElfAreas = new int[] {4, 5, 6, 7, 8}
            },
        };
        
        var reader = new StringReader(InputData);
        var actual = Day4.ProcessPuzzleInput(reader);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static void Part1Solution_SampleInput_ExpectedOutput()
    {
        var reader = new StringReader(InputData);
        var data = Day4.ProcessPuzzleInput(reader);
        var actual = Day4.Part1Solution(data);
        var expected = 2;

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public static void Part2Solution_SampleInput_ExpectedOutput()
    {
        var reader = new StringReader(InputData);
        var data = Day4.ProcessPuzzleInput(reader);
        var actual = Day4.Part2Solution(data);
        var expected = 4;

        Assert.Equal(expected, actual);
    }
}