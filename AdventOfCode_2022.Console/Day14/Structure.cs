namespace AdventOfCode_2022.Console.Day14;

public enum StructureType
{
    Empty,
    Sand,
    Rock
}
public class Structure
{
    public readonly int x;
    public readonly int y;

    public StructureType Type { get; set; } = StructureType.Empty;
    public Structure? Left { get; set; }
    public Structure? Right { get; set; }
    public Structure? Top { get; set; }
    public Structure? Bottom { get; set; }

    public Structure(StructureType type, int x, int y)
    {
        Type = type;
        this.x = x;
        this.y = y;
    }
    public bool ProcessSand(out Structure next)
    {
        if (Type == StructureType.Empty)
        {
            //ik ben geen zand
            if (Bottom is null)
            {
                //We've reached infinity
                next = this;
                return false;
            }

            var isSuccesful = Bottom.ProcessSand(out next);
            if (isSuccesful && next == this)
            {
                Type = StructureType.Sand;
            }
            return isSuccesful;
        }
        else
        {
            if (Left is null)
            {
                //We've reached infinity
                next = this;
                return false;
            }
            if (Left.Type is StructureType.Empty)
            {
                next = this;
                return Left.ProcessSand(out _);
            }
            if (Right is null)
            {
                //We've reached infinity
                next = this;
                return false;
            }
            if (Right.Type is StructureType.Empty)
            {
                next = this;
                return Right.ProcessSand(out _);
            }
            if (Top is null) throw new NotSupportedException();
            Top.Type = StructureType.Sand;
            next = Top;
            return true;
        }

    }

    public override string? ToString()
    {
        return $"X:{x}, Y:{y}, type:{Type}";
    }
}
