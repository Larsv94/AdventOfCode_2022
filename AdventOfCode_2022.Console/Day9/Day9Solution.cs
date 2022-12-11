using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day9;

public class Day9Solution : ISolution
{
    public int Day => 9;
    public object SolvePartOne(string[] input)
    {
        var rope = new Rope();
        foreach (var instruction in input)
        {
            rope.Move(instruction);
        }

        return rope.AllTailCoordinates.Count;
    }

    public object SolvePartTwo(string[] input)
    {
        var rope = new Rope(9);
        foreach (var instruction in input)
        {
            rope.Move(instruction);
        }

        return rope.AllTailCoordinates.Count;
    }
}