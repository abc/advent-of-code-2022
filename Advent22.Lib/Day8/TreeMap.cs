using Microsoft.Toolkit.HighPerformance;
using Microsoft.Toolkit.HighPerformance.Enumerables;

namespace Advent22.Lib.Day8;

public class TreeMap
{
    public int[,] Map { get; set; }
    public TreeMap(int[,] map)
    {
        Map = map;
    }

    public int TreeAtCoordinate(int x, int y)
    {
        return Map[y, x];
    }

    public bool TreeVisibleFrom(Direction direction, int x, int y)
    {
        var tree = TreeAtCoordinate(x, y);
        var treesInDirection = GetTreesInDirection(direction, x, y);
        return !treesInDirection.Any(t => t >= tree);
    }

    public int GetWidth()
    {
        return Map.GetLength(1);
    }

    public int GetHeight()
    {
        return Map.GetLength(0);
    }

    public RefEnumerable<int> GetColumn(int x)
    {
        return Map.GetColumn(x);
    }
    
    public RefEnumerable<int> GetRow(int y)
    {
        return Map.GetRow(y);
    }

    public IEnumerable<int> GetTreesAbove(int x, int y)
    {
        return Map.GetColumn(x).ToArray()[..y];
    }
    
    public IEnumerable<int> GetTreesBelow(int x, int y)
    {
        int start = y + 1;
        return Map.GetColumn(x).ToArray()[start..];
    }

    public IEnumerable<int> GetTreesLeft(int x, int y)
    {
        return Map.GetRow(y).ToArray()[..x];
    }

    public IEnumerable<int> GetTreesRight(int x, int y)
    {
        int start = x + 1;
        return Map.GetRow(y).ToArray()[start..];
    }
    
    public IEnumerable<int> GetTreesInDirection(Direction direction, int x, int y)
    {
        return direction switch
        {
            Direction.Left => GetTreesLeft(x, y),
            Direction.Top => GetTreesAbove(x, y),
            Direction.Bottom => GetTreesBelow(x, y),
            Direction.Right => GetTreesRight(x, y),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    public bool VisibleFromOutside(int x, int y)
    {
        return TreeVisibleFrom(Direction.Left, x, y) ||
               TreeVisibleFrom(Direction.Right, x, y) ||
               TreeVisibleFrom(Direction.Top, x, y) ||
               TreeVisibleFrom(Direction.Bottom, x, y);
    }

    public int ViewingDistanceInDirection(Direction direction, int x, int y)
    {
        var tree = TreeAtCoordinate(x, y);
        int count = 0;
        
        var visibleTrees = GetTreesInDirection(direction, x, y);
        if (direction is Direction.Top or Direction.Left)
        {
            visibleTrees = visibleTrees.Reverse();
        }

        var enumerable = visibleTrees as int[] ?? visibleTrees.ToArray();
        for (int i = 0; i < enumerable.Count(); i++)
        {
            count++;
            if (enumerable[i] >= tree)
            {
                break;
            }
        }

        return count;
    }

    public int ScenicScore(int x, int y)
    {
        return ViewingDistanceInDirection(Direction.Left, x, y)
               * ViewingDistanceInDirection(Direction.Right, x, y)
               * ViewingDistanceInDirection(Direction.Top, x, y)
               * ViewingDistanceInDirection(Direction.Bottom, x, y);
    }
}