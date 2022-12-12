using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day10;

public class Day10Solution : ISolution
{
    public int Day => 10;

    public object SolvePartOne(string[] input)
    {
        var cycles = GetCycles(input);
        var importantCycles = cycles.Where(c => (c.tick == 20 || (c.tick - 20) % 40 == 0) && c.tick <= 220);
        return importantCycles.Sum(c => c.tick * c.signalStrength);
    }

    public object SolvePartTwo(string[] input)
    {
        var cycles = GetCycles(input);
        System.Console.WriteLine();
        DrawCRT(cycles);
        System.Console.WriteLine();
        return 0;
    }

    private IEnumerable<Cycle> GetCycles(string[] instructions)
    {
        var signalStrength = 1;
        var tick = 1;
        foreach (var instruction in instructions)
        {
            var parts = instruction.Split(' ');
            switch (parts[0])
            {
                case "noop":
                    yield return new Cycle(tick, signalStrength);
                    tick++;
                    break;
                case "addx":
                    yield return new Cycle(tick, signalStrength);
                    tick++;
                    yield return new Cycle(tick, signalStrength);
                    tick++;
                    signalStrength += int.Parse(parts[1]);
                    break;
            }

        }
    }

    private void DrawCRT(IEnumerable<Cycle> cycles)
    {
        var crtPos = 0;
        foreach (var cycle in cycles)
        {

            var crtDistanceToSprite = cycle.signalStrength - crtPos;
            if (crtDistanceToSprite is >= -1 and <= 1)
            {
                System.Console.Write("#");
            }
            else
            {
                System.Console.Write(".");
            }
            if (cycle.tick % 40 == 0)
            {
                crtPos = 0;
                System.Console.Write(Environment.NewLine);
                continue;
            }
            crtPos++;
        }
    }

    private record Cycle(int tick, int signalStrength);
}