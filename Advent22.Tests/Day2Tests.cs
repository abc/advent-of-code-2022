using System.Text;

namespace Advent22.Tests;

public class Day2Tests
{
    [Theory]
    [InlineData('A', Play.Rock)]
    [InlineData('B', Play.Paper)]
    [InlineData('C', Play.Scissors)]
    [InlineData('X', Play.Rock)]
    [InlineData('Y', Play.Paper)]
    [InlineData('Z', Play.Scissors)]
    public static void GetPlay_ValidInput_ExpectedOutput(char input, Play expected)
    {
        var actual = input.GetPlay();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static void GetPlay_InvalidInput_ThrowsException()
    {
        try
        {
            var value = 'T'.GetPlay();
        }
        catch (InvalidOperationException ex)
        {
            Assert.StartsWith("'T' was not a valid play.", ex.Message);
        }
    }

    [Theory]
    [InlineData('A', 'Y', 8)]
    [InlineData('B', 'X', 1)]
    [InlineData('C', 'Z', 6)]
    public static void CalculateScore_SampleInput_ExpectedOutput(char opponentPlay, char yourPlay, int expected)
    {
        var strategy = new Strategy(opponentPlay.GetPlay(), yourPlay.GetPlay());
        var actual = strategy.CalculateScore();
        Assert.Equal(expected, actual);
    }
}