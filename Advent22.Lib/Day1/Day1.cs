namespace Advent22.Lib.Day1;

public sealed class Day1 : Solution<List<int>, int>
{
    public override int DayNumber => 1;
    
    
    public override int Task1Solution(List<int> input)
    {
        return input.Max();
    }

    public override int Task2Solution(List<int> input)
    {
        return input.OrderByDescending(c => c)
            .Take(3).Sum();
    }

    public override List<int> ProcessPuzzleInput(TextReader reader)
    {
        var output = new List<int>();
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