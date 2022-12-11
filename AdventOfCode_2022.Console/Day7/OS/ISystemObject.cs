namespace AdventOfCode_2022.Console.Day7.OS;
public interface ISystemObject
{
    string Name { get; }
    int Size { get; }
}

public interface IDirectory : ISystemObject
{
    IDirectory Parent { get; }
    IDirectory Find(string name);
    void Add(ISystemObject systemObject);
}
public interface IFile : ISystemObject
{
    string Ext { get; }
}
