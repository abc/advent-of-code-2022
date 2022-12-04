namespace Advent22.Lib.Day4;

public class ElfPair : IEquatable<ElfPair>
{
    public int[] FirstElfAreas { get; set; }
    public int[] SecondElfAreas { get; set; }

    public bool Equals(ElfPair? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return FirstElfAreas.SequenceEqual(other.FirstElfAreas) && SecondElfAreas.SequenceEqual(other.SecondElfAreas);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ElfPair)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstElfAreas, SecondElfAreas);
    }
}