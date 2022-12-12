namespace Advent22.Lib.Day2;

public sealed class Day2 : Solution<Tuple<List<Strategy>, List<Strategy>>, int>
{
    public override int DayNumber => 2;
    
    public override int Task1Solution(Tuple<List<Strategy>, List<Strategy>> strategies)
    {
        return strategies.Item1.Sum(s => s.CalculateScore());
    }
    
    public override int Task2Solution(Tuple<List<Strategy>, List<Strategy>> strategies)
    {
        return strategies.Item2.Sum(s => s.CalculateScore());
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