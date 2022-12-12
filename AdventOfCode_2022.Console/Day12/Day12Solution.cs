using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day12;

public class Day12Solution : ISolution
{
    public int Day => 12;
    public object SolvePartOne(string[] input)
    {
        var parsedInput = input.Select(x => x.ToCharArray()).ToArray();
        var terrain = new TerrainMap(parsedInput);

        return terrain.GetShortestPathToEnd();
    }

    public object SolvePartTwo(string[] input)
    {
        var parsedInput = input.Select(x => x.ToCharArray()).ToArray();
        var terrain = new TerrainMap(parsedInput);

        return terrain.GetScenicRoute();
    }
}