using Advent22.Lib.Day5;

namespace Advent22.Tests;

public class Day5Tests
{
    private static readonly Day5 Day = new Day5();
    
    private const string InputData =
        "    [D]    \n" +
        "[N] [C]    \n" +
        "[Z] [M] [P]\n" +
        " 1   2   3 \n" +
        "\n" +
        "move 1 from 2 to 1\n" +
        "move 3 from 1 to 3\n" +
        "move 2 from 2 to 1\n" +
        "move 1 from 1 to 2\n";

    [Fact]
    public static void ProcessPuzzleInput_SampleData_AsExpected()
    {
        var input = new StringReader(InputData);
        var actual = Day.ProcessPuzzleInput(input);
        var expected = new Plan();
        expected.AddStack('N', 'Z');
        expected.AddStack('D', 'C', 'M');
        expected.AddStack('P');
        expected.AddOperation(1, 2, 1);
        expected.AddOperation(3, 1, 3);
        expected.AddOperation(2, 2, 1);
        expected.AddOperation(1, 1, 2);
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public static void Process_SampleData_AsExpected()
    {
        var input = new StringReader(InputData);
        var data = Day.ProcessPuzzleInput(input);
        data.ProcessPart1();
        var output = data.Result();
        output.Should().BeEquivalentTo("CMZ");
    }

    [Fact]
    public static void ProcessStep_SampleData_AsExpected()
    {
        var input = new StringReader(InputData);
        var data = Day.ProcessPuzzleInput(input);
        var operation = new Operation(1, 2, 1);
        data.ProcessStepPart1(operation);
        var expected = new Plan();
        expected.AddStack('D', 'N', 'Z');
        expected.AddStack('C', 'M');
        expected.AddStack('P');
        data.Stacks.Should().BeEquivalentTo(expected.Stacks);
    }

    [Fact]
    public static void Part1Solution_SampleData_AsExpected()
    {
        var input = new StringReader(InputData);
        var data = Day.ProcessPuzzleInput(input);
        var answer = Day.Task1Solution(data);
        answer.Should().Be("CMZ");
    }

    [Theory]
    [InlineData("move 1 from 2 to 1", 1, 2, 1)]
    [InlineData("move 3 from 1 to 3", 3, 1, 3)]
    [InlineData("move 2 from 2 to 1", 2, 2, 1)]
    [InlineData("move 1 from 1 to 2", 1, 1, 2)]
    [InlineData("move 0 from 1 to 1", 0, 1, 1)]
    [InlineData("move 10 from 7 to 1", 10, 7, 1)]
    public static void OperationFromString_ValidInput_MatchingOutput(string input, int count, int source, int destination)
    {
        var output = Day.OperationFromString(input);
        var expected = new Operation(count, source, destination);
        output.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData(0, 1, 1, "NDP")]
    [InlineData(1, 2, 1, "DCP")]
    [InlineData(3, 2, 3, "NM")]
    [InlineData(10, 2, 3, "NM")]
    public static void ProcessStep_MultipleSteps_AsExpected (int count, int from, int to, string expected)
    {
        var operation = new Operation (count, from, to);
        var input = new StringReader(InputData);
        var data = Day.ProcessPuzzleInput(input);
        data.ProcessStepPart1(operation);
        var output = data.Result();
        output.Should().Be(expected);
    }
}