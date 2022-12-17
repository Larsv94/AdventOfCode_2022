using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day14;
public class Cave
{
    private readonly List<IEnumerable<RockCoordinate>> _formations;
    private (int minX, int maxX, int minY, int maxY) _bounds;

    public Cave(string[] input)
    {
        _formations = input.Select(line => line.Split("->").Select(x => new RockCoordinate(x))).ToList();
        _bounds = GetBounds(_formations.SelectMany(x => x));
    }

    public Structure GetSart(Structure[,] grid)
    {
        return grid[0, 500 - _bounds.minX];
    }

    public Cave AddGround()
    {
        var maxRange = (int)Math.Ceiling(Math.Tan(45) * _bounds.maxY) + 1;
        _bounds.minX = 500 - maxRange;
        _bounds.maxX = 500 + maxRange;
        _bounds.maxY = _bounds.maxY + 2;

        _formations.Add(new[] { new RockCoordinate(_bounds.minX, _bounds.maxY), new RockCoordinate(_bounds.maxX, _bounds.maxY) });

        return this;
    }

    public Structure[,] CreateGrid()
    {
        var (minX, maxX, minY, maxY) = _bounds;
        var groupedFormations = _formations.SelectMany(x => x.Window(2));
        var grid = new Structure[maxY - minY + 1, maxX - minX + 1];
        foreach (var group in groupedFormations)
        {
            foreach (var rock in group[0].GetProgressionTo(group[1]))
            {
                grid[rock.Y - minY, rock.X - minX] ??= new Structure(StructureType.Rock, rock.X, rock.Y);
            }
        }
        for (int Y = 0; Y < grid.GetLength(0); Y++)
        {
            for (int X = 0; X < grid.GetLength(1); X++)
            {
                var curr = grid[Y, X] ??= new Structure(StructureType.Empty, minX + X, minY + Y);
                if (Y > 0)
                {
                    curr.Top = grid[Y - 1, X];
                    curr.Top.Bottom = curr;
                }
                if (X > 0)
                {
                    curr.Left = grid[Y, X - 1];
                    curr.Left.Right = curr;
                }
            }
        }
        return grid;
    }

    private (int minX, int maxX, int minY, int maxY) GetBounds(IEnumerable<RockCoordinate> rocks)
    {
        int minX = rocks.First().X;
        int maxX = rocks.First().X;
        int minY = 0;
        int maxY = rocks.First().Y;
        foreach (var rock in rocks.Skip(1))
        {
            minX = Math.Min(minX, rock.X);
            maxX = Math.Max(maxX, rock.X);
            maxY = Math.Max(maxY, rock.Y);
        }

        return (minX, maxX, minY, maxY);
    }

    private static void Print(Structure[,] grid, int count)
    {
        System.Console.WriteLine($"=================================={count}===================================");
        for (int Y = 0; Y < grid.GetLength(0); Y++)
        {
            for (int X = 0; X < grid.GetLength(1); X++)
            {
                var curr = grid[Y, X];
                var c = curr.Type switch
                {
                    StructureType.Empty => '.',
                    StructureType.Sand => 'o',
                    StructureType.Rock => '#',
                    _ => throw new NotImplementedException(),
                };
                System.Console.Write(c);
            }
            System.Console.Write(Environment.NewLine);
        }
    }
}
