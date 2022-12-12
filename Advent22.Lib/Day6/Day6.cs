namespace Advent22.Lib.Day6;

public sealed class Day6 : Solution<string, int>
{
    public override int DayNumber => 6;
    
    public static int GetStartOfPacketIndex(string datastreamBuffer, int markerLength)
    {
        var len = datastreamBuffer.Length;
        
        for (int i = 0; i < len; i++)
        {
            var potentialMarker = datastreamBuffer.Substring(i, Math.Min(len - i, markerLength));
            if (potentialMarker.Distinct().Count() == markerLength)
            {
                return i + markerLength;
            }
        }

        throw new InvalidDataException();
    }
    
    public override string ProcessPuzzleInput(TextReader reader)
    {
        return reader.ReadToEnd();
    }

    public override int Task1Solution(string data)
    {
        return GetStartOfPacketIndex(data, 4);
    }

    public override int Task2Solution(string data)
    {
        return GetStartOfPacketIndex(data, 14);
    }
}