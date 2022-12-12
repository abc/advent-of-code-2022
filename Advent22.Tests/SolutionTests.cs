using Advent22.Lib;

namespace Advent22.Tests;

public abstract class SolutionTests<TDay, TInput, TOutput> : AdventTests<TDay> 
    where TDay : Solution<TInput, TOutput>, new()
{
    public abstract TInput GetExpectedInput();
    public abstract TOutput Task1ExpectedOutput();
    public abstract TOutput Task2ExpectedOutput();

    public TInput GetSampleInput()
    {
        return GetDay().ProcessPuzzleInput(GetReader());
    }
    
    [Fact]
    public void ProcessPuzzleInput_WithSampleInput_AsExpected()
    {
        var input = GetSampleInput();
        input.Should().BeEquivalentTo(GetExpectedInput());
    }

    [Fact]
    public void Task1Output_WithSampleInput_MatchesExpectedOutput()
    {
        var output = GetDay().Task1Solution(GetSampleInput());
        output.Should().BeEquivalentTo(Task1ExpectedOutput());
    }
    
    [Fact]
    public void Task2Output_WithSampleInput_MatchesExpectedOutput()
    {
        var output = GetDay().Task2Solution(GetSampleInput());
        output.Should().BeEquivalentTo(Task2ExpectedOutput());
    }
}