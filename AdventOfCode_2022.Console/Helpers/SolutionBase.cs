namespace AdventOfCode_2022.Console.Helpers;

public interface ISolution
{
    public int Day { get; }
    public object SolvePartOne(string[] input) => throw new NotImplementedException();
    public object SolvePartTwo(string[] input) => 0;

}