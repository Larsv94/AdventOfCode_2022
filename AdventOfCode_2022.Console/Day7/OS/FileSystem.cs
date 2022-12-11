namespace AdventOfCode_2022.Console.Day7.OS;
public class FileSystem
{
    private readonly long _diskSize = 70_000_000;
    private IDirectory _current;
    private readonly IDirectory _root;
    private readonly List<IDirectory> _directories;

    public List<IDirectory> Directories => _directories;

    public FileSystem()
    {
        _root = _current = new Directory("/");
        _directories = new List<IDirectory>();
    }

    public void Execute(string dirtyInstruction)
    {
        var instruction = dirtyInstruction.Replace("$ ", "");
        var parts = instruction.Split(' ');
        var cmd = parts[0];
        var arg = parts.Skip(1).FirstOrDefault();
        switch (cmd)
        {
            case "cd":
                if (arg is "..")
                {
                    _current = _current.Parent;
                    break;
                }
                _current = arg is "/" ? _root : _current.Find(arg!);
                break;
            case "dir":
                var dir = new Directory(arg!, _current);
                _directories.Add(dir);
                _current.Add(dir);
                break;
            case "ls":
                break;
            default:
                _current.Add(new File(cmd, arg!));
                break;
        }
    }

    public long GetUnusedSize()
    {
        return _diskSize - _root.Size;
    }
}
