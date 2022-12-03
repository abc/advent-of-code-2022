using Advent22.Lib.Day3;

namespace Advent22.Tests;

public class Day3Tests
{
    const string InputData =
        "vJrwpWtwJgWrhcsFMMfFFhFp\n" + 
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\n" +
        "PmmdzqPrVvPwwTWBwg\n" +
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\n" +
        "ttgJtRGJQctTZtZT\n" +
        "CrZsJsPPZsGzwwsLwLmpwMDw\n";
    
    [Fact]
    public static void ProcessPuzzleInput_SampleData_ReturnsExpected()
    {
        var expected = new List<Tuple<string, string>>
        {
            new("vJrwpWtwJgWr", "hcsFMMfFFhFp"),
            new("jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL"),
            new("PmmdzqPrV", "vPwwTWBwg"),
            new("wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn"),
            new("ttgJtRGJ", "QctTZtZT"),
            new("CrZsJsPPZsGz", "wwsLwLmpwMDw"),
        };

        var reader = new StringReader(InputData);
        var actual = Day3.ProcessPuzzleInput(reader);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("vJrwpWtwJgWr", "hcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrV", "vPwwTWBwg", 'P')]
    [InlineData("wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn", 'v')]
    [InlineData("ttgJtRGJ", "QctTZtZT", 't')]
    [InlineData("CrZsJsPPZsGz", "wwsLwLmpwMDw", 's')]

    public static void CharactersInCommon_SampleData_ReturnsExpected(string input1, string input2, char expected)
    {
        var output = Day3.CharactersInCommon(input1, input2);
        Assert.Single(output);
        var actual = output.Single();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData('a', 1)]
    [InlineData('z', 26)]
    [InlineData('A', 27)]
    [InlineData('Z', 52)]
    public static void GetCharacterPriority_SampleCharacters_ReturnsExpected(char input, int expected)
    {
        var actual = input.GetPriority();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static void Part1Solution_SampleInput_ExpectedOutput()
    {
        var reader = new StringReader(InputData);
        var data = Day3.ProcessPuzzleInput(reader);
        var actual = Day3.Part1Solution(data);
        var expected = 157;
        
        Assert.Equal(expected, actual);
    }
}