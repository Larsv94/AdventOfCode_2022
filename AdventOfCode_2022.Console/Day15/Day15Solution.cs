using AdventOfCode_2022.Console.Helpers;
using System.Text.RegularExpressions;

namespace AdventOfCode_2022.Console.Day15;

public partial class Day15Solution : ISolution
{
    public int Row { get; set; } = 2000000;
    public int Range { get; set; } = 4000000;
    public int Day => 15;
    public object SolvePartOne(string[] input)
    {
        var data = ParseInput(input);

        var atRow = data.Select(g =>
        {
            var yDistance = Math.Abs(g.SensorY - Row);
            if (yDistance > g.Distance) return Enumerable.Empty<int>();
            var xDistance = g.Distance - yDistance;
            var min = g.SensorX - xDistance;
            var max = g.SensorX + xDistance;
            return Enumerable.Range((int)min, (int)(max - min) + 1);
        });

        var existingBeacons = data.Where(g => g.BeaconY == Row).Select(g => (int)g.BeaconX);

        return atRow.SelectMany(x => x).Distinct().Except(existingBeacons).Count();
    }

    public object SolvePartTwo(string[] input)
    {
        var data = ParseInput(input).ToArray();

        var covered = GetCovered(data);

        var yPosition = 0L;
        var xPosition = 0L;
        for (int i = 0; i < covered.GetLength(0); i++)
        {
            var row = covered[i];
            var ordered = row.OrderBy(x => x.min).ThenBy(x => x.max);
            var max = 0;
            foreach (var cover in ordered)
            {
                if (max + 1 < cover.min)
                {
                    xPosition = max + 1;
                    break;
                }
                max = Math.Max(max, cover.max);
            }
            if (xPosition != 0) break;
            yPosition++;
        }

        return xPosition * 4000000 + yPosition;
    }

    private static IEnumerable<Data> ParseInput(string[] input)
    {
        return input
        .Select(x => CoordinateRegex()
            .Match(x)
            .Groups
        )
        .Select(g => new Data(
            int.Parse(g[1].Value),
            int.Parse(g[2].Value),
            int.Parse(g[3].Value),
            int.Parse(g[4].Value)
            )
        );
    }

    private (int min, int max)[][] GetCovered(Span<Data> dataSpan)
    {
        var covered = new (int min, int max)[Range][];
        for (int row = 0; row < Range; row++)
        {
            var arr = new (int min, int max)[dataSpan.Length];
            for (int i = 0; i < dataSpan.Length; i++)
            {
                var data = dataSpan[i];
                var yDistance = Math.Abs(data.SensorY - row);
                if (yDistance > data.Distance)
                {
                    arr[i] = (0, 0);
                    continue;
                }

                var xDistance = data.Distance - yDistance;
                var min = (int)Math.Max(0, data.SensorX - xDistance);
                var max = (int)Math.Min(Range, data.SensorX + xDistance);
                arr[i] = (min, max);
            }
            covered[row] = arr;
        }
        return covered;
    }


    struct Data
    {
        public int SensorX { get; set; }
        public int SensorY { get; set; }
        public int BeaconX { get; set; }
        public int BeaconY { get; set; }
        public long Distance { get; set; }

        public Data(int sensorX, int sensorY, int beaconX, int beaconY) : this()
        {
            SensorX = sensorX;
            SensorY = sensorY;
            BeaconX = beaconX;
            BeaconY = beaconY;
            Distance = Math.Abs(SensorX - BeaconX) + Math.Abs(SensorY - BeaconY);
        }
    }

    [GeneratedRegex("Sensor at x=([-\\d]*), y=([-\\d]*): closest beacon is at x=([-\\d]*), y=([-\\d]*)")]
    private static partial Regex CoordinateRegex();
}