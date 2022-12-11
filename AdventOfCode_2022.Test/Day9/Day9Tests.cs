using AdventOfCode_2022.Console.Day9;

namespace AdventOfCode_2022.Test.Day9;
public class Day9Tests
{
    [Fact]
    public void Day9_SolvePartOne()
    {
        var input = """
            R 4
            U 4
            L 3
            D 1
            R 4
            D 1
            L 5
            R 2
            """.Split(Environment.NewLine);
        var sut = new Day9Solution();
        var result = sut.SolvePartOne(input);
        result.Should().Be(13);
    }

    [Fact]
    public void Day9_SolvePartTwo_SmallSample()
    {
        var input = """
            R 4
            U 4
            L 3
            D 1
            R 4
            D 1
            L 5
            R 2
            """.Split(Environment.NewLine);
        var sut = new Day9Solution();
        var result = sut.SolvePartTwo(input);
        result.Should().Be(1);
    }

    [Fact]
    public void Day9_SolvePartTwo_LargeSample()
    {
        var input = """
            R 5
            U 8
            L 8
            D 3
            R 17
            D 10
            L 25
            U 20
            """.Split(Environment.NewLine);
        var sut = new Day9Solution();
        var result = sut.SolvePartTwo(input);
        result.Should().Be(36);
    }
}
