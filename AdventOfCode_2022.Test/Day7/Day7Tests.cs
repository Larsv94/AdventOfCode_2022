using AdventOfCode_2022.Console.Day7;

namespace AdventOfCode_2022.Test.Day7;
public class Day7Tests
{
    [Fact]
    public void Day7_SolvePartOne_Should_Return_Expected()
    {
        var input = """
            $ cd /
            $ ls
            dir a
            14848514 b.txt
            8504156 c.dat
            dir d
            $ cd a
            $ ls
            dir e
            29116 f
            2557 g
            62596 h.lst
            $ cd e
            $ ls
            584 i
            $ cd ..
            $ cd ..
            $ cd d
            $ ls
            4060174 j
            8033020 d.log
            5626152 d.ext
            7214296 k
            """.Split(Environment.NewLine);

        var sut = new Day7Solution();

        var result = sut.SolvePartOne(input);

        result.Should().Be(95437);
    }

    [Fact]
    public void Day7_SolvePartTwo_Should_Return_Expected()
    {
        var input = """
            $ cd /
            $ ls
            dir a
            14848514 b.txt
            8504156 c.dat
            dir d
            $ cd a
            $ ls
            dir e
            29116 f
            2557 g
            62596 h.lst
            $ cd e
            $ ls
            584 i
            $ cd ..
            $ cd ..
            $ cd d
            $ ls
            4060174 j
            8033020 d.log
            5626152 d.ext
            7214296 k
            """.Split(Environment.NewLine);

        var sut = new Day7Solution();

        var result = sut.SolvePartTwo(input);

        result.Should().Be(24933642);
    }
}
