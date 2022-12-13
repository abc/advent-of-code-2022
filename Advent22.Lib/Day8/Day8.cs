namespace Advent22.Lib.Day8;

public class Day8 : Solution<TreeMap, int>
{
    public override int DayNumber => 8;
    public override TreeMap ProcessPuzzleInput(TextReader reader)
    {
        var grid = new List<List<int>>();
        
        while (reader.ReadLine() is { } line)
        {
            grid.Add(line.ToCharArray()
                .Select(char.GetNumericValue)
                .Select(Convert.ToInt32)
                .ToList());
        }

        return new TreeMap(CollectionHelpers.Get2DArray(grid));
    }

    public override int Task1Solution(TreeMap input)
    {
        int width = input.GetWidth();
        int height = input.GetHeight();

        int count = 0;
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (input.VisibleFromOutside(x, y))
                    count++;
            }
        }

        return count;
    }

    public override int Task2Solution(TreeMap input)
    {
        int max = 0;
        
        int width = input.GetWidth();
        int height = input.GetHeight();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                max = Math.Max(max, input.ScenicScore(x, y));
            }
        }

        return max;
    }
}