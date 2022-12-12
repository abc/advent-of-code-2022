namespace Advent22.Lib.Day3;

public sealed class Day3 : Solution<IEnumerable<Tuple<string, string>>, int>
{
    public override int DayNumber => 3;

    public override IEnumerable<Tuple<string, string>> ProcessPuzzleInput(TextReader reader)
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

    public override int Task1Solution(IEnumerable<Tuple<string, string>> data)
    {
        return data.Sum(i =>
            CharactersInCommon(i.Item1, i.Item2)
                .ToArray()
                .Sum(c => c.GetPriority()));
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

    public override int Task2Solution(IEnumerable<Tuple<string, string>> data)
    {
        return GetGroupBadges(data)
                .Sum(c => c.GetPriority());
    }
}