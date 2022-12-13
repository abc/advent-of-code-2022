using Advent22.Lib.Day8;

namespace Advent22.Tests;

public class Day8Tests : SolutionTests<Day8, TreeMap, int>
{
    public override string GetSampleString() =>
        "30373\n" +
        "25512\n" +
        "65332\n" +
        "33549\n" +
        "35390\n";
    public override TreeMap GetExpectedInput() => new (new[,] {
        {3, 0, 3, 7, 3},
        {2, 5, 5, 1, 2},
        {6, 5, 3, 3, 2},
        {3, 3, 5, 4, 9},
        {3, 5, 3, 9, 0}
    });
    
    public override int Task1ExpectedOutput() => 21;
    public override int Task2ExpectedOutput() => 8;

    [Fact]
    public void GetHeight_SampleInput_5()
    {
        var map = GetExpectedInput();
        var height = map.GetHeight();
        height.Should().Be(5);
    }
    
    [Fact]
    public void GetWidth_SampleInput_5()
    {
        var map = GetExpectedInput();
        var height = map.GetWidth();
        height.Should().Be(5);
    }
    
    [Fact]
    public void GetHeight_2x3_3()
    {
        TreeMap map = new(new[,]
        {
            { 1, 2 },
            { 3, 4 },
            { 5, 6 },
        });
        
        var height = map.GetHeight();
        height.Should().Be(3);
    }
    
    [Fact]
    public void GetWidth_2x3_2()
    {
        TreeMap map = new(new[,]
        {
            { 1, 2 },
            { 3, 4 },
            { 5, 6 },
        });
        
        var width = map.GetWidth();
        width.Should().Be(2);
    }

    [Theory]
    [InlineData(0, new [] {3, 2, 6, 3, 3})]
    [InlineData(1, new [] {0, 5, 5, 3, 5})]
    [InlineData(2, new [] {3, 5, 3, 5, 3})]
    [InlineData(3, new [] {7, 1, 3, 4, 9})]
    [InlineData(4, new [] {3, 2, 2, 9, 0})]
    public void GetColumn_SampleData_Expected(int x, int[] expected)
    {
        GetExpectedInput().GetColumn(x).ToArray().Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData(0, new [] {3, 0, 3, 7, 3})]
    [InlineData(1, new [] {2, 5, 5, 1, 2})]
    [InlineData(2, new [] {6, 5, 3, 3, 2})]
    [InlineData(3, new [] {3, 3, 5, 4, 9})]
    [InlineData(4, new [] {3, 5, 3, 9, 0})]
    public void GetRow_SampleData_Expected(int y, int[] expected)
    {
        GetExpectedInput().GetRow(y).ToArray().Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(1, 1, 5)]
    [InlineData(2, 1, 5)]
    [InlineData(3, 1, 1)]
    [InlineData(1, 2, 5)]
    [InlineData(2, 2, 3)]
    [InlineData(3, 2, 3)]
    [InlineData(1, 3, 3)]
    [InlineData(2, 3, 5)]
    [InlineData(3, 3, 4)]
    public void TreeAtCoordinate_SampleData_SampleOutput(int x, int y, int expected)
    {
        var output = GetExpectedInput().TreeAtCoordinate(x, y);
        output.Should().Be(expected);
    }

    [Theory]
    
    [InlineData(Direction.Top, 1, 1, true)]
    [InlineData(Direction.Left, 1, 1, true)]
    [InlineData(Direction.Bottom, 1, 1, false)]
    [InlineData(Direction.Right, 1, 1, false)]
    [InlineData(Direction.Top, 2, 1, true)]
    [InlineData(Direction.Left, 2, 1, false)]
    [InlineData(Direction.Bottom, 2, 1, false)]
    [InlineData(Direction.Right, 2, 1, true)]
    [InlineData(Direction.Top, 3, 1, false)]
    [InlineData(Direction.Left, 3, 1, false)]
    [InlineData(Direction.Bottom, 3, 1, false)]
    [InlineData(Direction.Right, 3, 1, false)]
    [InlineData(Direction.Top, 1, 2, false)]
    [InlineData(Direction.Left, 1, 2, false)]
    [InlineData(Direction.Bottom, 1, 2, false)]
    [InlineData(Direction.Right, 1, 2, true)]
    [InlineData(Direction.Top, 2, 2, false)]
    [InlineData(Direction.Left, 2, 2, false)]
    [InlineData(Direction.Bottom, 2, 2, false)]
    [InlineData(Direction.Right, 2, 2, false)]
    [InlineData(Direction.Top, 3, 2, false)]
    [InlineData(Direction.Left, 3, 2, false)]
    [InlineData(Direction.Bottom, 3, 2, false)]
    [InlineData(Direction.Right, 3, 2, true)]
    [InlineData(Direction.Top, 1, 3, false)]
    [InlineData(Direction.Left, 1, 3, false)]
    [InlineData(Direction.Bottom, 1, 3, false)]
    [InlineData(Direction.Right, 1, 3, false)]
    [InlineData(Direction.Top, 2, 3, false)]
    [InlineData(Direction.Left, 2, 3, true)]
    [InlineData(Direction.Bottom, 2, 3, true)]
    [InlineData(Direction.Right, 2, 3, false)]
    [InlineData(Direction.Top, 3, 3, false)]
    [InlineData(Direction.Left, 3, 3, false)]
    [InlineData(Direction.Bottom, 3, 3, false)]
    [InlineData(Direction.Right, 3, 3, false)]
    public void TreeVisibleFrom_SampleInput_Expected(Direction direction, int x, int y, bool expected)
    {
        var output = GetExpectedInput().TreeVisibleFrom(direction, x, y);
        output.Should().Be(expected);
    }

    [Theory]
    [InlineData(1, 1, new [] { 0 })]
    public void GetTreesAbove_SampleInput_Expected(int x, int y, int[] trees)
    {
        GetExpectedInput().GetTreesAbove(x, y).Should().BeEquivalentTo(trees);
    }
    
    [Theory]
    [InlineData(1, 1, new [] { 5, 3, 5 })]
    public void GetTreesBelow_SampleInput_Expected(int x, int y, int[] trees)
    {
        GetExpectedInput().GetTreesBelow(x, y).Should().BeEquivalentTo(trees);
    }

    [Theory]
    [InlineData(1, 1, new [] { 2 })]
    public void GetTreesLeft_SampleInput_Expected(int x, int y, int[] trees)
    {
        GetExpectedInput().GetTreesLeft(x, y).Should().BeEquivalentTo(trees);
    }
    
    [Theory]
    [InlineData(1, 1, new [] { 5, 1, 2 })]
    public void GetTreesRight_SampleInput_Expected(int x, int y, int[] trees)
    {
        GetExpectedInput().GetTreesRight(x, y).Should().BeEquivalentTo(trees);
    }
    
    [Theory]
    [InlineData(Direction.Top, 1, 1, new [] { 0 })]
    [InlineData(Direction.Left, 3, 3, new [] { 3, 3, 5 })]
    [InlineData(Direction.Bottom, 1, 2, new [] { 3, 5 })]
    [InlineData(Direction.Right, 2, 3, new [] { 4, 9 })]
    public void GetTreesInDirection_SampleInput_Expected(Direction direction, int x, int y, int[] trees)
    {
        GetExpectedInput().GetTreesInDirection(direction, x, y).Should().BeEquivalentTo(trees);
    }

    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(2, 1, true)]
    [InlineData(3, 1, false)]
    [InlineData(1, 2, true)]
    [InlineData(2, 2, false)]
    [InlineData(3, 2, true)]
    [InlineData(1, 3, false)]
    [InlineData(2, 3, true)]
    [InlineData(3, 3, false)]
    public void VisibleFromOutside_SampleInput_Expected(int x, int y, bool expected)
    {
        GetExpectedInput().VisibleFromOutside(x, y).Should().Be(expected);
    }

    [Theory]
    [InlineData(Direction.Top, 2, 1, 1)]
    [InlineData(Direction.Left, 2, 1, 1)]
    [InlineData(Direction.Right, 2, 1, 2)]
    [InlineData(Direction.Bottom, 2, 1, 2)]
    [InlineData(Direction.Top, 2, 3, 2)]
    [InlineData(Direction.Left, 2, 3, 2)]
    [InlineData(Direction.Right, 2, 3, 2)]
    [InlineData(Direction.Bottom, 2, 3, 1)]
    public void ViewingDistanceInDirection_SampleInput_Expected(Direction direction, int x, int y, int expected)
    {
        GetExpectedInput().ViewingDistanceInDirection(direction, x, y).Should().Be(expected);
    }

    [Theory]
    [InlineData(2, 1, 4)]
    [InlineData(2, 3, 8)]
    public void ScenicScore_SampleInput_Expected(int x, int y, int expected)
    {
        GetExpectedInput().ScenicScore(x, y).Should().Be(expected);
    }
}