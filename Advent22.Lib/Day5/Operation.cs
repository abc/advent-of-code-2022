namespace Advent22.Lib.Day5;

public class Operation
{
    public int CratesToMove { get; init; }
    public int Source { get; init; }
    public int Destination { get; init; }

    public Operation(int cratesToMove, int source, int destination)
    {
        CratesToMove = cratesToMove;
        Source = source - 1;
        Destination = destination - 1;
    }
}