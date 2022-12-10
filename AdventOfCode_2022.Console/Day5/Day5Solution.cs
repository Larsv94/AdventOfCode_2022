using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day5;

public class Day5Solution : ISolution
{
    public int Day => 5;
    public object SolvePartOne(string[] input)
    {
        var inputParser = new InputParser();
        var crateLines = inputParser.GetCrateSection(input);
        var instructionLines = input.Skip(crateLines.Length + 2);
        var instructions = inputParser.GetInstructions(instructionLines.ToArray());
        var crates = inputParser.GetStacks(crateLines);

        var crane = new CraneOperator(crates);
        crane.FollowInstructions(instructions);

        var firstCrates = crates.Select(x => x.Pop());

        return new string(firstCrates.ToArray());

    }

    public object SolvePartTwo(string[] input)
    {
        var inputParser = new InputParser();
        var crateLines = inputParser.GetCrateSection(input);
        var instructionLines = input.Skip(crateLines.Length + 2);
        var instructions = inputParser.GetInstructions(instructionLines.ToArray());
        var crates = inputParser.GetStacks(crateLines);

        var crane = new CrateMover9001(crates);
        crane.FollowInstructions(instructions);

        var firstCrates = crates.Select(x => x.Pop());

        return new string(firstCrates.ToArray()); ;
    }
}