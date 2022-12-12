namespace AdventOfCode_2022.Console.Day12;
public class Node
{
    public readonly List<Node> _neighbours = new List<Node>();

    public int Distance = int.MaxValue;

    public char Elevation { get; }

    public bool Visited = false;
    public bool hasUnvisitedNeighbours => _neighbours.Any(x => !x.Visited);

    public Node(char elevation)
    {
        Elevation = elevation;
    }

    public void VisitNeighbours(Func<int, bool>? testFunc = null)
    {
        testFunc ??= (difference) => difference is <= 1;
        foreach (Node neighbour in _neighbours.Where(n => !n.Visited))
        {
            neighbour.Visit(this, testFunc);
        }
        Visited = true;
    }

    public void Visit(Node fromNode, Func<int, bool> testFunc)
    {
        var edge = GetEdgeWeight(fromNode, testFunc);
        if (edge > 1)
        {
            return;
        }
        var newDistance = fromNode.Distance + edge;
        Distance = Math.Min(Distance, newDistance);
    }

    public void AddNeighbour(Node neighbour)
    {
        _neighbours.Add(neighbour);
        neighbour._neighbours.Add(this);
    }

    private int GetEdgeWeight(Node node, Func<int, bool> testFunc)
    {
        var elevationDifference = Elevation - node.Elevation;
        if (testFunc(elevationDifference))
        {
            return 1;
        }
        return int.MaxValue;
    }

    public static implicit operator Node(char c) => new(c);

}
