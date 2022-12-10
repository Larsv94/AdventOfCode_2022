namespace AdventOfCode_2022.Console.Day5;
public class InputParser
{
    private readonly int StackSize = 4;
    public string[] GetCrateSection(string[] input)
    {
        return input.TakeWhile(x => x.Contains('[')).ToArray();
    }

    public IEnumerable<Instruction> GetInstructions(string[] input)
    {
        foreach (var instruction in input)
        {
            var splitInstruction = instruction.Split(' ')
                .Select(l => int.TryParse(l, out var result) ? result : -1)
                .Where(x => x > 0)
                .ToArray();
            yield return new(
                splitInstruction[0],
                splitInstruction[1],
                splitInstruction[2]
                );
        }
    }

    public Stack<char>[] GetStacks(string[] input)
    {
        return GetStacksInternal(input).Select(x => new Stack<char>(x)).ToArray();
    }

    private IEnumerable<List<char>> GetStacksInternal(string[] input)
    {
        var lineLength = input[0].Length;
        var position = 1;
        var currentStack = new List<char>();
        while (position < lineLength)
        {
            foreach (var line in input)
            {
                var crate = line.ElementAt(position);
                if (!char.IsWhiteSpace(crate))
                {
                    currentStack.Add(line.ElementAt(position));
                }
            }

            currentStack.Reverse();
            yield return currentStack;
            position += StackSize; //move to next stack
            currentStack = new List<char>();
        }
        yield break;
    }
}
