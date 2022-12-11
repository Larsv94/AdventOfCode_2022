using AdventOfCode_2022.Console.Day7.OS;
using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day7;

public class Day7Solution : ISolution
{
    public int Day => 7;
    public object SolvePartOne(string[] input)
    {

        var elfSystem = new FileSystem();
        foreach (var instruction in input)
        {
            elfSystem.Execute(instruction);
        }
        return elfSystem
            .Directories
            .Where(dir => dir.Size < 100_000)
            .Sum(dir => dir.Size);
    }

    public object SolvePartTwo(string[] input)
    {
        var requiredSpace = 30_000_000;
        var elfSystem = new FileSystem();
        foreach (var instruction in input)
        {
            elfSystem.Execute(instruction);
        }

        var unusedSize = elfSystem.GetUnusedSize();

        return elfSystem
            .Directories
            .Where(dir => (unusedSize + dir.Size) >= requiredSpace)
            .Min(dir => dir.Size);
    }
}