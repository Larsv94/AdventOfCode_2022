namespace AdventOfCode_2022.Console.Day9;
public class Rope
{
    public Coord Head { get; set; }
    public Coord[] Segments { get; set; }

    public HashSet<Coord> AllTailCoordinates { get; set; } = new HashSet<Coord>();

    public Rope()
    {
        Head = new Coord(0, 0);
        Segments = new[] { new Coord(0, 0) };
    }

    public Rope(int segments)
    {
        Head = new Coord(0, 0);
        Segments = Enumerable.Range(0, segments).Select(_ => new Coord(0, 0)).ToArray();
    }

    public void Move(string instruction)
    {
        var parts = instruction.Split(' ');
        var movement = parts[0] switch
        {
            "R" => new Coord(1, 0),
            "L" => new Coord(-1, 0),
            "U" => new Coord(0, 1),
            "D" => new Coord(0, -1),
            _ => throw new NotSupportedException()
        };
        var amount = int.Parse(parts[1]);
        for (int i = 0; i < amount; i++)
        {
            Head.Move(movement);
            UpdateTail();
            PrintDebug(instruction, i, movement);
        }
    }

    public void PrintDebug(string instruction, int amount, Coord dir)
    {
        System.Console.WriteLine("============================================================");
        System.Console.WriteLine($"Instruction: {instruction}");
        System.Console.WriteLine($"Amount: {amount}, Direction: {dir}");

        var xMin = Math.Min(-5, AllTailCoordinates.Min(x => x.X));
        var xMax = Math.Max(5, AllTailCoordinates.Max(x => x.X));

        var yMin = Math.Min(-5, AllTailCoordinates.Min(y => y.Y));
        var yMax = Math.Max(5, AllTailCoordinates.Max(y => y.Y));

        for (int Y = yMax; Y > yMin; Y--)
        {
            //System.Console.Write(Y);
            for (int x = xMin; x < xMax; x++)
            {
                var writingCoord = new Coord(x, Y);
                var findIndex = Array.IndexOf(Segments, writingCoord);
                if (writingCoord == Head)
                {
                    System.Console.Write("H");
                }
                else if (findIndex != -1)
                {
                    System.Console.Write(findIndex + 1);
                }
                else
                {
                    System.Console.Write(AllTailCoordinates.TryGetValue(new Coord(x, Y), out var _) ? "#" : ".");
                }
            }
            System.Console.Write(Environment.NewLine);

        }

        System.Console.WriteLine("============================================================");

    }

    private void UpdateTail()
    {
        var head = Head;
        for (int i = 0; i < Segments.Length; i++)
        {
            var segment = Segments[i];
            var distance = segment.DistanceTo(head);
            var movement = distance.GetRequiredMovement();
            segment.Move(movement);
            if (i == Segments.Length - 1)
            {
                AllTailCoordinates.Add(segment with { });
            }
            head = segment;
        }

    }
}

public record Coord
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Coord(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Coord DistanceTo(Coord point)
    {
        return new Coord(point.X - X, point.Y - Y);
    }

    public Coord GetRequiredMovement()
    {

        return (X, Y) switch
        {
            ( > 1, 0) => new Coord(X - 1, 0),
            ( < -1, 0) => new Coord(X + 1, 0),
            ( > 1, 1 or -1) => new Coord(X - 1, Y),
            ( < -1, 1 or -1) => new Coord(X + 1, Y),
            (0, > 1) => new Coord(0, Y - 1),
            (0, < -1) => new Coord(0, Y + 1),
            (1 or -1, > 1) => new Coord(X, Y - 1),
            (1 or -1, < -1) => new Coord(X, Y + 1),
            ( > 1, > 1) => new Coord(X - 1, Y - 1),
            ( > 1, < -1) => new Coord(X - 1, Y + 1),
            ( < -1, > 1) => new Coord(X + 1, Y - 1),
            ( < -1, < -1) => new Coord(X + 1, Y + 1),
            (1 or 0 or -1, 1 or 0 or -1) => new Coord(0, 0),
        };
    }

    public void Move(Coord movement)
    {
        X += movement.X;
        Y += movement.Y;
    }
}