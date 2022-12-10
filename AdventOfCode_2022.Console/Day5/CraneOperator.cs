namespace AdventOfCode_2022.Console.Day5;
public class CraneOperator
{
    private readonly Stack<char>[] crates;

    public CraneOperator(Stack<char>[] crates)
    {
        this.crates = crates;
    }

    public void FollowInstructions(IEnumerable<Instruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            var fromStack = crates[instruction.From - 1];
            var toStack = crates[instruction.To - 1];

            for (int i = 0; i < instruction.Amount; i++)
            {
                var crate = fromStack.Pop();
                toStack.Push(crate);
            }
        }
    }
}
