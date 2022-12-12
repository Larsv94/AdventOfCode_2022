using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day11;

public class Day11Solution : ISolution
{
    public int Day => 11;

    public object SolvePartOne(string[] input)
    {
        var monkeys = new List<Monkey>();
        var monkeyStrings = GroupMonkeyStrings(input);
        foreach (var monkeyString in monkeyStrings)
        {
            Monkey.Create(monkeyString, monkeys);
        }
        for (int i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.InspectAndThrowItems();
            }
        }
        var mostActiveMonkeys = monkeys.OrderByDescending(m => m.Actions).Take(2).ToArray();
        return mostActiveMonkeys.Aggregate(1, (x, y) => x * y.Actions);
    }

    public IEnumerable<List<string>> GroupMonkeyStrings(string[] input)
    {
        var list = new List<string>();
        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line))
            {
                yield return list;
                list = new List<string>();
                continue;
            }
            list.Add(line);
        }


        if (list.Count > 0)
        {
            yield return list;
        }
    }
}