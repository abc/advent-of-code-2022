namespace Advent22.Lib.Day4;

public sealed class Day4 : Solution<List<ElfPair>, int>
{
    public override int DayNumber => 4;

    public int[] ParseRange(string input)
    {
        var result = new List<int>();
        var elements = input.Split('-');
        if (elements.Length != 2)
        {
            throw new ArgumentException();
        }

        if (!int.TryParse(elements[0], out int start) || !int.TryParse(elements[1], out int end))
        {
            throw new ArgumentException();
        }

        for (int i = start; i <= end; i++)
        {
            result.Add(i);
        }

        return result.ToArray();
    }

    public override List<ElfPair> ProcessPuzzleInput(TextReader reader)
    {
        var results = new List<ElfPair>();
        
        while (reader.ReadLine() is { } line)
        {
            var elves = line.Split(',');
            results.Add(new ElfPair
            {
                FirstElfAreas = ParseRange(elves[0]),
                SecondElfAreas = ParseRange(elves[1])
            });
        }

        return results;
    }

    public override int Task1Solution(List<ElfPair> data)
    {
        return data.Count(p => p.FirstElfAreas.All(a => p.SecondElfAreas.Contains(a))
                               || p.SecondElfAreas.All(a => p.FirstElfAreas.Contains(a)));
    }

    public override int Task2Solution(List<ElfPair> data)
    {
        return data.Count(p => p.FirstElfAreas.Any(a => p.SecondElfAreas.Contains(a))
                               || p.SecondElfAreas.Any(a => p.FirstElfAreas.Contains(a)));
    }
}