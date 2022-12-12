namespace Advent22.Lib.Day6;

public class Day6 : Day
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

    public override string Part1Solution()
    {
        var input = GetInput().ReadToEnd();
        return GetStartOfPacketIndex(input, 4).ToString();
    }
    
    public override string Part2Solution()
    {
        var input = GetInput().ReadToEnd();
        return GetStartOfPacketIndex(input, 14).ToString();
    }
}