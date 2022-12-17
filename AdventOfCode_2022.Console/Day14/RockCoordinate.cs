namespace AdventOfCode_2022.Console.Day14;
public class RockCoordinate
{
    public int X { get; set; }
    public int Y { get; set; }

    public RockCoordinate(string input)
    {
        var parsed = input.Split(',').Select(int.Parse).ToList();
        X = parsed[0];
        Y = parsed[1];
    }

    public RockCoordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public IEnumerable<RockCoordinate> GetProgressionTo(RockCoordinate to)
    {
        var from = this;
        if (from.X == to.X && from.Y != to.Y)
        {
            var count = Math.Abs(from.Y - to.Y);
            var isNegative = to.Y - from.Y < 0;
            var fromRange = isNegative ? from.Y - count : from.Y;
            return Enumerable.Range(fromRange, count + 1).Select(Y => new RockCoordinate(from.X, Y));
        }
        if (from.Y == to.Y && from.X != to.X)
        {
            var count = Math.Abs(from.X - to.X);
            var isNegative = to.X - from.X < 0;
            var fromRange = isNegative ? from.X - count : from.X;
            return Enumerable.Range(fromRange, count + 1).Select(X => new RockCoordinate(X, from.Y));
        }
        throw new NotSupportedException("diagonals not supported");
    }
}
