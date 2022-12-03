namespace Advent22.Lib.Day3;

public class Day3
{
    public static StreamReader GetInput()
    {
        const string filePath = @"data/input_day3.txt";
        var inputData = new FileInfo(filePath);
        return inputData.OpenText();
    }
    
    public static List<Tuple<string, string>> ProcessPuzzleInput(TextReader reader)
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

    public static List<char> CharactersInCommon(string input1, string input2)
    {
        return input1.Intersect(input2).ToList();
    }

    public static int Part1Solution(IEnumerable<Tuple<string, string>> data)
    {
        return data.Sum(i =>
            CharactersInCommon(i.Item1, i.Item2)
                .ToArray()
                .Sum(c => c.GetPriority()));
    }

    public static int Part1Solution()
    {
        var input = GetInput();
        var data = ProcessPuzzleInput(input);
        return Part1Solution(data);
    }
}