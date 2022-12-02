namespace Advent22.Lib;

public class Strategy : IEquatable<Strategy>
{
    public Play OpponentPlay { get; set; }
    public Play YourPlay { get; set; }

    public Strategy(Play opponentPlay, Play yourPlay)
    {
        OpponentPlay = opponentPlay;
        YourPlay = yourPlay;
    }

    public bool Equals(Strategy? other)
    {
        return OpponentPlay == other?.OpponentPlay && YourPlay == other.YourPlay;
    }

    public int CalculateScore()
    {
        var playScore = (int)YourPlay;
        
        if (YourPlay == OpponentPlay)
        {
            return 3 + playScore;
        }

        if ((YourPlay == Play.Rock && OpponentPlay == Play.Paper)
            || YourPlay == Play.Paper && OpponentPlay == Play.Scissors
            || YourPlay == Play.Scissors && OpponentPlay == Play.Rock)
        {
            return 0 + playScore;
        }

        return 6 + playScore;
    }
}