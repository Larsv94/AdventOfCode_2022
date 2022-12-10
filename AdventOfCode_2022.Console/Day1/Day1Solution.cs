using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day1;

public class Day1Solution : ISolution
{
    public int Day => 1;
    public object SolvePartOne(string[] input)
    {
        var mostCalories = GroupCalories(input)
             .Max();
        return mostCalories;
    }

    public object SolvePartTwo(string[] input)
    {
        var maxThree = GroupCalories(input)
            .OrderDescending()
            .Take(3)
            .Sum();
        return maxThree;
    }

    private IEnumerable<int> GroupCalories(string[] input)
    {
        var currentCalories = 0;
        foreach (var calories in input)
        {
            if (!string.IsNullOrEmpty(calories))
            {
                currentCalories += int.Parse(calories);
                continue;
            }
            yield return currentCalories;
            currentCalories = 0;
        }
        yield return currentCalories;
    }
}