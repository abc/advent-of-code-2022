namespace Advent22.Lib.Day3;

public sealed class Day3 : Solution<List<Tuple<string, string>>>
{
    public override int DayNumber => 3;

    public override List<Tuple<string, string>> ProcessPuzzleInput(TextReader reader)
    {
        var results = new List<Tuple<string, string>>();

        while (reader.ReadLine() is { } line)
        {
            int halfCount = line.Length / 2;
            var firstHalf = line.Substring(0, halfCount);
            var secondHalf = line.Substring(halfCount, halfCount);
            results.Add(new Tuple<string, string>(firstHalf, secondHalf));
        }

        return results;
    }

    public List<char> CharactersInCommon(string input1, string input2)
    {
        return input1.Intersect(input2).ToList();
    }

    public int Part1Solution(IEnumerable<Tuple<string, string>> data)
    {
        return data.Sum(i =>
            CharactersInCommon(i.Item1, i.Item2)
                .ToArray()
                .Sum(c => c.GetPriority()));
    }

    public override string Part1Solution()
    {
        var input = GetInput();
        var data = ProcessPuzzleInput(input);
        return Part1Solution(data).ToString();
    }

    public List<char> GetGroupBadges(IEnumerable<Tuple<string, string>> data)
    {
        var results = new List<char>();
        int i = 0;
        int max = data.Count();
        do
        {
            var result = data.Skip(i * 3).Take(3)
                .Select(p => (p.Item1 + p.Item2).ToCharArray())
                .Cast<IEnumerable<char>>()
                .Aggregate((x, y) => x.Intersect(y));
            // var result = group[0].Intersect(group[1]).Intersect(group[2]);
            results.Add(result.Single());
            i++;
        } while (i * 3 < max);

        return results;
    }

    public int Part2Solution(IEnumerable<Tuple<string, string>> data)
    {
        return GetGroupBadges(data)
                .Sum(c => c.GetPriority());
    }
    
    public override string Part2Solution()
    {
        var input = GetInput();
        var data = ProcessPuzzleInput(input);
        return Part2Solution(data).ToString();
    }
}