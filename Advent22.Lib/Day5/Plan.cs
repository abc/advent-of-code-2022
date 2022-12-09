using System.Text;

namespace Advent22.Lib.Day5;

public class Plan
{
    public List<Stack<char>> Stacks { get; set; }
    public List<Operation> Operations { get; set; }

    public Plan()
    {
        this.Stacks = new List<Stack<char>>();
        this.Operations = new List<Operation>();
    }

    public void AddStack(params char[] items)
    {
        Stacks.Add(new Stack<char>(items.Where(i => i != ' ').Reverse()));
    }

    public void AddOperation(int cratesToMove, int source, int destination)
    {
        Operations.Add(new Operation (cratesToMove, source, destination));
    }

    public void ProcessPart1()
    {
        foreach (var operation in Operations)
        {
            ProcessStepPart1(operation);
        }
    }
    
    public void ProcessPart2()
    {
        foreach (var operation in Operations)
        {
            ProcessStepPart2(operation);
        }
    }

    public void ProcessStepPart1(Operation operation)
    {
        for (int i = 0; i < operation.CratesToMove; i++)
        {
            if (!Stacks[operation.Source].Any()) continue;
            
            var item = Stacks[operation.Source].Pop();
            Stacks[operation.Destination].Push(item);
        }
    }

    public void ProcessStepPart2(Operation operation)
    {
        var items = new List<char>();
        
        for (int i = 0; i < operation.CratesToMove; i++)
        {
            if (!Stacks[operation.Source].Any()) continue;
            
            var item = Stacks[operation.Source].Pop();
            items.Add(item);
        }

        items.Reverse();
        
        foreach (var item in items)
        {
            Stacks[operation.Destination].Push(item);
        }
    }

    public string Result()
    {
        var resultBuilder = new StringBuilder();
        foreach (var stack in Stacks)
        {
            if (stack.Any())
            {
                resultBuilder.Append(stack.Peek());
            }
        }

        return resultBuilder.ToString();
    }
}