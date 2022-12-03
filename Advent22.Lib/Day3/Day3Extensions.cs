namespace Advent22.Lib.Day3;

public static class Day3Extensions
{
    public static int GetPriority(this char input)
    {
        var asciiValue = (int)input;
        if (asciiValue is
            (< 64 or > 122) or
            (>= 91 and <= 96))
        {
            throw new InvalidOperationException();
        }
        
        if (asciiValue > 96)
        {
            asciiValue -= 96;
        }
        else if (asciiValue > 64)
        {
            asciiValue -= 38;
        }

        return asciiValue;
    }
}