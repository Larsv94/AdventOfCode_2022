namespace AdventOfCode_2022.Console.Day7.OS;
public class File : IFile
{
    public string Ext { get; private init; }

    public string Name { get; private init; }


    public int Size { get; private init; }

    public File(string size, string fileName)
    {
        Size = int.Parse(size);

        (Name, Ext) = fileName.Split('.') switch
        {
            [var name] => (name, string.Empty),
            [var name, var ext] => (name, ext),
            _ => throw new NotSupportedException(),
        };
    }
}
