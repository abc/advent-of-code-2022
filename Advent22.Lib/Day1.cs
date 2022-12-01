namespace Advent22.Lib;

public class Day1
{
    public static int Part1Solution()
    {
        var elvesWithCalories = ProcessPuzzleInput();
        return elvesWithCalories.Max();
    }

    public static List<int> ProcessPuzzleInput()
    {
        var output = new List<int>();
        const string filePath = @"data/input_day1.txt";
        var inputData = new FileInfo(filePath);
        using var reader = inputData.OpenText();
        var runningTotal = 0;
        while (reader.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                output.Add(runningTotal);
                runningTotal = 0;
            }
            else if (int.TryParse(line, out int value))
            {
                runningTotal += value;
            }
        }

        return output;
    }
}