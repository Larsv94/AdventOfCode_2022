using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day4;

public class Day4Solution : ISolution
{
    public int Day => 4;
    private readonly CleaningManager _cleaningMangager = new CleaningManager();
    public object SolvePartOne(string[] input)
    {
        var parsedInput = input.Select(x => x.Split(',').Select(y => y.Split('-')));
        return parsedInput
            .Where(x => _cleaningMangager.IsPairFullyOverlapping(
                x.First().Select(int.Parse).ToArray(),
                x.Last().Select(int.Parse).ToArray()
                )
            ).Count();
    }

    public object SolvePartTwo(string[] input)
    {
        var parsedInput = input.Select(x => x.Split(',').Select(y => y.Split('-')));
        return parsedInput
            .Where(x => _cleaningMangager.IsPartiallyOverlapping(
                x.First().Select(int.Parse).ToArray(),
                x.Last().Select(int.Parse).ToArray()
                )
            ).Count();
    }
}