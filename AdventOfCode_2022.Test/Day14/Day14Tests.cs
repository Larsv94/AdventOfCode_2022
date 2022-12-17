using AdventOfCode_2022.Console.Day14;

namespace AdventOfCode_2022.Test.Day14;
public class Day14Tests
{
    [Fact]
    public void Day14_PartOne_Solves()
    {
        var input = """
            498,4 -> 498,6 -> 496,6
            503,4 -> 502,4 -> 502,9 -> 494,9
            """.Split(Environment.NewLine);

        var sut = new Day14Solution();
        var result = sut.SolvePartOne(input);

        result.Should().Be(24);
    }

    [Fact]
    public void Day14_PartTwo_Solves()
    {
        var input = """
            498,4 -> 498,6 -> 496,6
            503,4 -> 502,4 -> 502,9 -> 494,9
            """.Split(Environment.NewLine);

        var sut = new Day14Solution();
        var result = sut.SolvePartTwo(input);

        result.Should().Be(93);
    }
}
