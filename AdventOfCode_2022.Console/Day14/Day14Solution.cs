using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day14;

public class Day14Solution : ISolution
{
    public int Day => 14;
    public object SolvePartOne(string[] input)
    {
        var cave = new Cave(input);
        var grid = cave.CreateGrid();

        var count = 0;
        var current = cave.GetSart(grid);

        while (current.ProcessSand(out current))
        {
            count++;
        }

        return count;
    }
    public object SolvePartTwo(string[] input)
    {
        var cave = new Cave(input);
        var grid = cave.AddGround().CreateGrid();

        var count = 1;
        var current = cave.GetSart(grid);
        current.ProcessSand(out current);

        while (current is not { x: 500, y: 0 })
        {
            current.ProcessSand(out current);
            count++;
        }

        return count;
    }

}