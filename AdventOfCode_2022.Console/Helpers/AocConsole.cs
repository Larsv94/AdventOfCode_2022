using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode_2022.Console.Helpers;

public static class AocConsole
{
    public static void Start()
    {
        var baseType = typeof(ISolution);
        var allSolutions = Assembly.GetAssembly(baseType)!.GetTypes()
            .Where(myType => myType.IsClass && myType.GetInterfaces().Contains(baseType));

        var instances = allSolutions
            .Select(t => (ISolution)Activator.CreateInstance(t)!)
            .ToDictionary(s => s.Day);

        ISolution? solution = null;
        while (solution is null)
        {
            System.Console.WriteLine("Please enter a day:");
            var chosenDay = System.Console.ReadLine();
            if (int.TryParse(chosenDay, out var result) && instances.ContainsKey(result))
            {
                solution = instances[result];
                continue;
            }
            System.Console.WriteLine($"Day {chosenDay} not found...");
            System.Console.WriteLine();
        }

        var input = GetInput(solution);
        var startOne = Stopwatch.GetTimestamp();
        var solutionResultPartOne = solution.SolvePartOne(input);
        var endOne = Stopwatch.GetElapsedTime(startOne).TotalMilliseconds;
        System.Console.WriteLine($"The solution to part one of day{solution.Day} is:");
        System.Console.WriteLine(solutionResultPartOne);
        System.Console.WriteLine();
        System.Console.WriteLine($"It took {endOne}ms to solve Part One");
        System.Console.WriteLine();
        System.Console.WriteLine("  ----");


        var startTwo = Stopwatch.GetTimestamp();
        var solutionResultPartTwo = solution.SolvePartTwo(input);
        var endTwo = Stopwatch.GetElapsedTime(startTwo).TotalMilliseconds;
        System.Console.WriteLine($"The solution to part two of day{solution.Day} is:");
        System.Console.WriteLine(solutionResultPartTwo);
        System.Console.WriteLine();
        System.Console.WriteLine();
        System.Console.WriteLine($"It took {endTwo}ms to solve Part One");
        System.Console.WriteLine();
        System.Console.WriteLine("  ----");
        System.Console.WriteLine("Enter any key to quit");
        System.Console.Read();
    }

    public static string[] GetInput(ISolution solution)
    {
        var path = Path.Combine($"Day{solution.Day}", "input.txt");
        var input = File.ReadAllLines(path);
        return input;
    }
}