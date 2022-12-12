namespace AdventOfCode_2022.Console.Day12;
public class TerrainMap
{
    private readonly Node[,] _nodeGrid;
    private readonly List<Node> _nodes = new List<Node>();
    private readonly Node startNode = null!;
    private readonly Node endNode = null!;

    public TerrainMap(char[][] input)
    {
        var height = input.Length;
        var width = input[0].Length;
        _nodeGrid = new Node[height, width];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var terrain = input[y][x];
                Node currentNode = terrain switch
                {
                    'E' => (endNode = 'z'),
                    'S' => (startNode = 'a'),
                    _ => terrain
                };

                if (y > 0)
                {
                    currentNode.AddNeighbour(_nodeGrid[y - 1, x]);
                }
                if (x > 0)
                {
                    currentNode.AddNeighbour(_nodeGrid[y, x - 1]);
                }
                _nodeGrid[y, x] = currentNode;
                _nodes.Add(currentNode);

            }
        }

    }

    public int GetShortestPathToEnd()
    {
        startNode.Distance = 0;
        var currentNode = startNode;
        while (currentNode != null)
        {
            currentNode.VisitNeighbours();
            currentNode = _nodes.Where(x => !x.Visited)
                .OrderBy(n => n.Distance).FirstOrDefault();
        }

        return endNode.Distance;
    }

    public int GetScenicRoute()
    {
        endNode.Distance = 0;
        var currentNode = endNode;
        while (currentNode != null)
        {
            currentNode.VisitNeighbours((difference) => difference is >= -1);
            var temp = _nodes.Where(x => !x.Visited && x.Distance != int.MaxValue)
                .OrderBy(n => n.Distance).ToArray();
            currentNode = _nodes.Where(x => !x.Visited)
                .OrderBy(n => n.Distance).FirstOrDefault();
        }

        var allStartingOptions = _nodes.Where(n => n.Elevation == 'a' && n.Distance > 0 && n.Distance != int.MaxValue).OrderBy(n => n.Distance).ToList();

        return allStartingOptions.First().Distance;

    }


}
