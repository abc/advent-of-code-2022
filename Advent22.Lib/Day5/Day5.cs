using System.ComponentModel;
using System.Text;
using Microsoft.Toolkit.HighPerformance;

namespace Advent22.Lib.Day5;

public class Day5 : Day
{
    public override int DayNumber => 5;

    public Plan ProcessPuzzleInput(TextReader reader)
    {
        var plan = new Plan();
        var stackStringBuilder = new StringBuilder();
        var loadingStack = true;
        string? previousLine = null;
        while (reader.ReadLine() is { } line)
        {
            if (loadingStack)
            {
                // Stack loading completes on an empty line 
                if (string.IsNullOrWhiteSpace(line))
                {
                    loadingStack = false;
                }
                else
                {
                    if (previousLine != null)
                        stackStringBuilder.AppendLine(previousLine[1..]);
                    
                    previousLine = line;
                }
            }
            else
            {
                plan.Operations.Add(OperationFromString(line));
            }
        }

        var stack = ProcessStackString(stackStringBuilder.ToString());
        for (int i = 0; i < stack.GetLength(0); i++)
        {
            plan.AddStack(stack.GetRow(i).ToArray());
        }
        return plan;
    }

    public Operation OperationFromString(string input)
    {
        // Assume that operations are in format: move x from y to z
        // Probably would be more optimal as regex.
        // var parts = input
        //     .Where(char.IsDigit)
        //     .Select(i => Convert.ToInt32(char.GetNumericValue(i)))
        //     .ToArray();
        //
        // return new Operation (parts[0], parts[1], parts[2]);

        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return new Operation(int.Parse(parts[1]), int.Parse(parts[3]), int.Parse(parts[5]));
    }

    public char[,] ProcessStackString(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        // All lines should have an identical length.
        var lineLength = lines.Max(s => s.Length);
        if (lines.All(l => l.Length != lineLength))
        {
            throw new ArgumentException("Input was not in valid stack layout format.");
        }
        var numberOfElements = lineLength / 4 + 1;
        var arr = new char[numberOfElements, lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < numberOfElements; j++)
            {
                arr[j, i] = lines[i][j * 4];
            }
        }

        return arr;
    }

    public string Part1Solution(Plan data)
    {
        data.ProcessPart1();
        return data.Result();
    }
    
    public string Part2Solution(Plan data)
    {
        data.ProcessPart2();
        return data.Result();
    }
    
    public override string Part1Solution()
    {
        var input = GetInput();
        var data = ProcessPuzzleInput(input);
        return Part1Solution(data);
    }
    
    public override string Part2Solution()
    {
        var input = GetInput();
        var data = ProcessPuzzleInput(input);
        return Part2Solution(data);
    }
}