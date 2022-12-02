namespace Advent22.Lib;

public class Day2
{
    public static List<Strategy> StrategyGuide;
    
    static Day2()
    {
        const string filePath = @"data/input_day2.txt";
        var inputData = new FileInfo(filePath);
        using var reader = inputData.OpenText();
        StrategyGuide = ProcessPuzzleInput(reader);
    }
    
    public static int Part1Solution()
    {
        return StrategyGuide.Sum(s => s.CalculateScore());
    }
    
    public static int Part2Solution()
    {
        return 0;
    }

    public static List<Strategy> ProcessPuzzleInput(TextReader reader)
    {
        var result = new List<Strategy>();
        while (reader.ReadLine() is { } line)
        {
            var inputs = line.Split();
            if (inputs.Length != 2 || inputs.Any(i => i.Length != 1))
            {
                throw new InvalidDataException("Input stream was not in a valid format");
            }

            result.Add(new Strategy(inputs[0][0].GetPlay(), inputs[1][0].GetPlay()));
        }

        return result;
    }
}