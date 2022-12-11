namespace AdventOfCode_2022.Console.Day8;
public class Tree
{
    public Tree? LeftTree { get; set; }
    public Tree? RightTree { get; set; }
    public Tree? TopTree { get; set; }
    public Tree? BottomTree { get; set; }

    public int Value { get; set; }
    public int MaxLeft => LeftTree is null ? -1 : Math.Max(LeftTree.Value, LeftTree.MaxLeft);
    public int MaxRight => RightTree is null ? -1 : Math.Max(RightTree.Value, RightTree.MaxRight);
    public int MaxTop => TopTree is null ? -1 : Math.Max(TopTree.Value, TopTree.MaxTop);
    public int MaxBottom => BottomTree is null ? -1 : Math.Max(BottomTree.Value, BottomTree.MaxBottom);


    public int TotalScenicScore() => GetLeftScenicScore(Value) * GetRightScenicScore(Value) * GetTopScenicScore(Value) * GetBottomScenicScore(Value);

    public bool IsVisible => Value > MaxRight || Value > MaxLeft || Value > MaxTop || Value > MaxBottom;

    public Tree(int value)
    {
        Value = value;
    }

    public int GetLeftScenicScore(int value)
    {
        if (LeftTree is null)
        {
            return 0;
        }
        return value > LeftTree.Value ? 1 + LeftTree.GetLeftScenicScore(value) : 1;
    }

    public int GetRightScenicScore(int value)
    {
        if (RightTree is null)
        {
            return 0;
        }
        return value > RightTree.Value ? 1 + RightTree.GetRightScenicScore(value) : 1;
    }

    public int GetTopScenicScore(int value)
    {
        if (TopTree is null)
        {
            return 0;
        }
        return value > TopTree.Value ? 1 + TopTree.GetTopScenicScore(value) : 1;
    }

    public int GetBottomScenicScore(int value)
    {
        if (BottomTree is null)
        {
            return 0;
        }
        return value > BottomTree.Value ? 1 + BottomTree.GetBottomScenicScore(value) : 1;
    }

}
