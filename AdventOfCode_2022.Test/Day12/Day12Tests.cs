using AdventOfCode_2022.Console.Day12;

namespace AdventOfCode_2022.Test.Day12;
public class Day12Tests
{
    [Fact]
    public void Day12_PartOne_Solves()
    {
        var input = """
            Sabqponm
            abcryxxl
            accszExk
            acctuvwj
            abdefghi
            """.Split(Environment.NewLine);

        var sut = new Day12Solution();

        var result = sut.SolvePartOne(input);

        result.Should().Be(31);
    }

    [Fact]
    public void Day12_PartTwo_Solves()
    {
        var input = """
            Sabqponm
            abcryxxl
            accszExk
            acctuvwj
            abdefghi
            """.Split(Environment.NewLine);

        var sut = new Day12Solution();

        var result = sut.SolvePartTwo(input);

        result.Should().Be(29);
    }
}
