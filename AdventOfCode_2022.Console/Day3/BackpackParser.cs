namespace AdventOfCode_2022.Console.Day3;
public class BackpackParser
{
    public char GetDuplicateItem(string backpack)
    {
        var half = backpack.Length / 2;
        return backpack.Take(half).Intersect(backpack.Skip(half)).Single();
    }

    public char GetGroupCode(IEnumerable<IEnumerable<char>> input)
    {
        return input.Aggregate((curr, next) => curr.Intersect(next)).SingleOrDefault();
    }

    public int GetPriority(char item)
    {
        return char.IsUpper(item) ? item - 'A' + 27 : item - 'a' + 1;
    }
}
