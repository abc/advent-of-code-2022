namespace Advent22.Lib;

public abstract class Day
{
    public abstract int DayNumber { get; }
    public abstract string Part1Solution();
    public abstract string Part2Solution();

    public StreamReader GetInput()
    {
        var filePath = $"data/input_day{DayNumber}.txt";
        var inputData = new FileInfo(filePath);
        if (!inputData.Exists)
        {
            throw new FileNotFoundException($"Input data for day {DayNumber} not found", inputData.Name);
        }
        return inputData.OpenText();
    }
}