namespace Advent22.Lib;

public class Day2
{
    public static List<Strategy> StrategyGuidePart1 = new List<Strategy>();
    public static List<Strategy> StrategyGuidePart2 = new List<Strategy>();
    
    static Day2()
    {
        const string filePath = @"data/input_day2.txt";
        var inputData = new FileInfo(filePath);
        using var reader = inputData.OpenText();
        ProcessPuzzleInput(reader);
    }
    
    public static int Part1Solution()
    {
        return StrategyGuidePart1.Sum(s => s.CalculateScore());
    }
    
    public static int Part2Solution()
    {
        return StrategyGuidePart2.Sum(s => s.CalculateScore());
    }

    public static void ProcessPuzzleInput(TextReader reader)
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