namespace AdventOfCode_2022.Console.Day5;
public class CrateMover9001
{
    private readonly Stack<char>[] crates;

    public CrateMover9001(Stack<char>[] crates)
    {
        this.crates = crates;
    }

    public void FollowInstructions(IEnumerable<Instruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            var fromStack = crates[instruction.From - 1];
            var toStack = crates[instruction.To - 1];
            var stackToMove = new List<char>();
            for (int i = 0; i < instruction.Amount; i++)
            {
                stackToMove.Add(fromStack.Pop());
            }
            stackToMove.Reverse();
            foreach (var item in stackToMove)
            {
                toStack.Push(item);
            }
        }
    }
}
