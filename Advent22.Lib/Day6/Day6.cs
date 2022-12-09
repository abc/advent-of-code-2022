namespace Advent22.Lib.Day6;

public class Day6
{
    public static string GetInput()
    {
        const string filePath = @"data/input_day6.txt";
        var inputData = new FileInfo(filePath);
        var reader = inputData.OpenText();
        return reader.ReadToEnd();
    }
    
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

    public static int Part1Solution()
    {
        var input = GetInput();
        return GetStartOfPacketIndex(input, 4);
    }
    
    public static int Part2Solution()
    {
        var input = GetInput();
        return GetStartOfPacketIndex(input, 14);
    }
}