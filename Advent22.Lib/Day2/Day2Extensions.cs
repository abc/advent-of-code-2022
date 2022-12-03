using System.ComponentModel;

namespace Advent22.Lib.Day2;

public static class Day2Extensions
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

    public static Outcome GetOutcome(this char input)
    {
        return input switch
        {
            'X' => Outcome.Lose,
            'Y' => Outcome.Draw,
            'Z' => Outcome.Win,
            _ => Outcome.Unknown
        };
    }

    public static Play GetDraw(this Play input)
    {
        return input;
    }

    public static Play GetWin(this Play input)
    {
        return input switch
        {
            Play.Rock => Play.Paper,
            Play.Paper => Play.Scissors,
            Play.Scissors => Play.Rock,
            _ => throw new InvalidEnumArgumentException()
        };
    }

    public static Play GetLoss(this Play input)
    {
        return input switch
        {
            Play.Rock => Play.Scissors,
            Play.Paper => Play.Rock,
            Play.Scissors => Play.Paper,
            _ => throw new InvalidEnumArgumentException()
        };
    }
}