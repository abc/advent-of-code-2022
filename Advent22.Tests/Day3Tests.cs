using Advent22.Lib.Day3;

namespace Advent22.Tests;

public class Day3Tests : SolutionTests<Day3, IEnumerable<Tuple<string, string>>, int>
{
    public override string GetSampleString() =>
        "vJrwpWtwJgWrhcsFMMfFFhFp\n" + 
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\n" +
        "PmmdzqPrVvPwwTWBwg\n" +
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\n" +
        "ttgJtRGJQctTZtZT\n" +
        "CrZsJsPPZsGzwwsLwLmpwMDw\n";

    public override IEnumerable<Tuple<string, string>> GetExpectedInput() =>
        new List<Tuple<string, string>>
        {
            new("vJrwpWtwJgWr", "hcsFMMfFFhFp"),
            new("jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL"),
            new("PmmdzqPrV", "vPwwTWBwg"),
            new("wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn"),
            new("ttgJtRGJ", "QctTZtZT"),
            new("CrZsJsPPZsGz", "wwsLwLmpwMDw"),
        };

    public override int Task1ExpectedOutput() => 157;
    public override int Task2ExpectedOutput() => 70;

    [Theory]
    [InlineData("vJrwpWtwJgWr", "hcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrV", "vPwwTWBwg", 'P')]
    [InlineData("wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn", 'v')]
    [InlineData("ttgJtRGJ", "QctTZtZT", 't')]
    [InlineData("CrZsJsPPZsGz", "wwsLwLmpwMDw", 's')]

    public void CharactersInCommon_SampleData_ReturnsExpected(string input1, string input2, char expected)
    {
        var output = GetDay().CharactersInCommon(input1, input2);
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
    public void GetGroupBadges_SampleInput_ExpectedOutput()
    {
        var reader = new StringReader(GetSampleString());
        var data = GetDay().ProcessPuzzleInput(reader);
        var actual = GetDay().GetGroupBadges(data);
        var expected = new List<char> { 'r', 'Z' };
        Assert.Equal(expected, actual);
    }
}