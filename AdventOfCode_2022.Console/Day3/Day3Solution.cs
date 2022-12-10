using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day3;

public class Day3Solution : ISolution
{
    public int Day => 3;
    public object SolvePartOne(string[] input)
    {
        var parser = new BackpackParser();
        return input
            .Select(parser.GetDuplicateItem)
            .Sum(parser.GetPriority);
    }

    public object SolvePartTwo(string[] input)
    {
        var parser = new BackpackParser();
        return input
            .Chunk(3)
            .Select(parser.GetGroupCode)
            .Sum(parser.GetPriority);
    }
}