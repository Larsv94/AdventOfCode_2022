using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day13;

public class Day13Solution : ISolution
{
    public int Day => 13;
    public object SolvePartOne(string[] input)
    {
        var cleaned = input.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => (Signal)x).ToArray();
        var pairs = cleaned.Where((x, i) => i % 2 == 0)
                    .Zip(cleaned.Where((x, i) => i % 2 != 0)).ToArray();

        var answer = 0;
        for (int i = 0; i < pairs.Length; i++)
        {
            (var left, var right) = pairs[i];
            if (left.CompareTo(right) <= 0)
            {
                answer += i + 1;
            }
        }
        return answer;
    }

    public object SolvePartTwo(string[] input)
    {
        var signals = input.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => (Signal)x).ToList();
        var dividerPackets = new Signal[] { "[[2]]", "[[6]]" };
        signals.AddRange(dividerPackets);
        signals.Sort();
        return (signals.IndexOf(dividerPackets.First()) + 1) * (signals.IndexOf(dividerPackets.Last()) + 1);
    }
}