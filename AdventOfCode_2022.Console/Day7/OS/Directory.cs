namespace AdventOfCode_2022.Console.Day7.OS;
public class Directory : IDirectory
{
    public string Name { get; }

    public int Size => _content.Sum(c => c.Size);

    private IList<ISystemObject> _content { get; } = new List<ISystemObject>();

    public IDirectory Parent { get; }

    public Directory(string name, IDirectory parent)
    {
        Name = name;
        Parent = parent;
    }
    public Directory(string name)
    {
        Name = name;
        Parent = this;
    }

    public IDirectory Find(string name)
    {
        return _content.OfType<IDirectory>().First(dir => dir.Name == name);
    }

    public void Add(ISystemObject systemObject)
    {
        _content.Add(systemObject);
    }
}
