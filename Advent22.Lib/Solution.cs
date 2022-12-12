namespace Advent22.Lib;

public abstract class Solution<TInput, TSolution> : Day
{
    public abstract TInput ProcessPuzzleInput(TextReader reader);
    public abstract TSolution Task1Solution(TInput input);
    public abstract TSolution Task2Solution(TInput input);
    public override string Part1Solution()
    {
        var input = GetInput();
        var data = ProcessPuzzleInput(input);
        return Task1Solution(data).ToString();
    }
    
    public override string Part2Solution()
    {
        var input = GetInput();
        var data = ProcessPuzzleInput(input);
        return Task2Solution(data).ToString();
    }
}