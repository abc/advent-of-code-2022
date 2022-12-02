namespace Advent22.Lib;

public static class PlayExtensions
{
    public static Play GetPlay(this char input)
    {
        switch (input)
        {
            case 'A':
            case 'X':
                return Play.Rock;
            case 'B':
            case 'Y':
                return Play.Paper;
            case 'C':
            case 'Z':
                return Play.Scissors;
            default:
                throw new InvalidOperationException($"'{input}' was not a valid play." +
                                                    $"Only A, B, C, X, Y or Z are valid plays.");
        }
    }
}