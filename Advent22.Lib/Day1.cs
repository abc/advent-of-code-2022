namespace Advent22.Lib;

public class Day1
{
    public static List<int> ElfCalorieCounts;

    static Day1()
    {
        ElfCalorieCounts = ProcessPuzzleInput();
    }
    
    public static int Part1Solution()
    {
        return ElfCalorieCounts.Max();
    }

    public static int Part2Solution()
    {
        return ElfCalorieCounts.OrderByDescending(c => c)
            .Take(3).Sum();
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