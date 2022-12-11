using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day8;

public class Day8Solution : ISolution
{
    public int Day => 8;

    public List<Tree> BuildForest(int[][] grid)
    {
        var ySize = grid.Length;
        var xSize = grid[0].Length;
        var treeGrid = new Tree[ySize, xSize];
        var trees = new List<Tree>();
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                var topTree = y - 1 > -1 ? treeGrid[y - 1, x] : null;
                var leftTree = x - 1 > -1 ? treeGrid[y, x - 1] : null;
                var thisTree = treeGrid[y, x] = new Tree(grid[y][x]);
                trees.Add(thisTree);
                thisTree.TopTree = topTree;
                thisTree.LeftTree = leftTree;
                if (leftTree is not null)
                {
                    leftTree.RightTree = thisTree;
                }
                if (topTree is not null)
                {
                    topTree.BottomTree = thisTree;
                }
            }
        }
        return trees;
    }

    public object SolvePartOne(string[] input)
    {
        var grid = input.Select(x => x.Select(x => int.Parse(x.ToString())).ToArray()).ToArray();

        var forest = BuildForest(grid);

        return forest.Where(tree => tree.IsVisible).Count();
    }

    public object SolvePartTwo(string[] input)
    {
        var grid = input.Select(x => x.Select(x => int.Parse(x.ToString())).ToArray()).ToArray();

        var forest = BuildForest(grid);

        return forest.Max(tree => tree.TotalScenicScore());
    }
}