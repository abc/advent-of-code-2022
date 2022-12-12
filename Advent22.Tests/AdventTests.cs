namespace Advent22.Tests;

public abstract class AdventTests<TDay> where TDay : new()
{
    public abstract string GetSampleString();
    
    public TDay GetDay()
    {
        return new TDay();
    }

    public TextReader GetReader()
    {
        return new StringReader(GetSampleString());
    }
}