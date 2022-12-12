namespace Advent22.Lib.Day2;

public sealed class Day2 : Solution<Tuple<List<Strategy>, List<Strategy>>>
{
    public override int DayNumber => 2;
    
    public readonly List<Strategy> StrategyGuidePart1;
    public readonly List<Strategy> StrategyGuidePart2;
    
    public Day2()
    {
        using var reader = GetInput();
        var guides = ProcessPuzzleInput(reader);
        StrategyGuidePart1 = guides.Item1;
        StrategyGuidePart2 = guides.Item2;
    }
    
    public override string Part1Solution()
    {
        return StrategyGuidePart1.Sum(s => s.CalculateScore()).ToString();
    }
    
    public override string Part2Solution()
    {
        return StrategyGuidePart2.Sum(s => s.CalculateScore()).ToString();
    }

    public override Tuple<List<Strategy>, List<Strategy>> ProcessPuzzleInput(TextReader reader)
    {
        var strategyGuidePart1 = new List<Strategy>();
        var strategyGuidePart2 = new List<Strategy>();
        
        while (reader.ReadLine() is { } line)
        {
            var inputs = line.Split();
            if (inputs.Length != 2 || inputs.Any(i => i.Length != 1))
            {
                throw new InvalidDataException("Input stream was not in a valid format");
            }

            strategyGuidePart1.Add(new Strategy(inputs[0][0].GetPlay(), inputs[1][0].GetPlay()));
            strategyGuidePart2.Add(new Strategy(inputs[0][0].GetPlay(), inputs[1][0].GetOutcome()));
        }

        return new Tuple<List<Strategy>, List<Strategy>>(strategyGuidePart1, strategyGuidePart2);
    }
}