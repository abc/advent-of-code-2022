namespace Advent22.Lib;

public abstract class Solution<T> : Day
{
    public abstract T ProcessPuzzleInput(TextReader reader);
}