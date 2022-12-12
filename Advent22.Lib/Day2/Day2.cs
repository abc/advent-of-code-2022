namespace Advent22.Lib.Day2;

public class Day2 : Day
{
    public override int DayNumber => 2;
    
    public List<Strategy> StrategyGuidePart1 = new List<Strategy>();
    public List<Strategy> StrategyGuidePart2 = new List<Strategy>();
    
    public Day2()
    {
        using var reader = GetInput();
        ProcessPuzzleInput(reader);
    }
    
    public override string Part1Solution()
    {
        return StrategyGuidePart1.Sum(s => s.CalculateScore()).ToString();
    }
    
    public override string Part2Solution()
    {
        return StrategyGuidePart2.Sum(s => s.CalculateScore()).ToString();
    }

    public void ProcessPuzzleInput(TextReader reader)
    {
        while (reader.ReadLine() is { } line)
        {
            var inputs = line.Split();
            if (inputs.Length != 2 || inputs.Any(i => i.Length != 1))
            {
                throw new InvalidDataException("Input stream was not in a valid format");
            }

            StrategyGuidePart1.Add(new Strategy(inputs[0][0].GetPlay(), inputs[1][0].GetPlay()));
            StrategyGuidePart2.Add(new Strategy(inputs[0][0].GetPlay(), inputs[1][0].GetOutcome()));
        }
    }
}