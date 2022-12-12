namespace Advent22.Lib.Day1;

public class Day1 : Day
{
    public override int DayNumber => 1;
    
    public List<int> ElfCalorieCounts;

    public Day1()
    {
        ElfCalorieCounts = ProcessPuzzleInput();
    }
    
    public override string Part1Solution()
    {
        return ElfCalorieCounts.Max().ToString();
    }

    public override string Part2Solution()
    {
        return ElfCalorieCounts.OrderByDescending(c => c)
            .Take(3).Sum().ToString();
    }

    public List<int> ProcessPuzzleInput()
    {
        var output = new List<int>();
        using var reader = GetInput();
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