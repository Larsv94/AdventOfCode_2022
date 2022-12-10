using AdventOfCode_2022.Console.Day2;

namespace AdventOfCode_2022.Test.Day2;
public class Day2Tests
{
    private readonly string[] input = { "A Y", "B X", "C Z" };

    [Fact]
    public void Day2_SolvePartOne_Should_Return_Expected()
    {
        var sut = new Day2Solution();

        var result = sut.SolvePartOne(input);

        result.Should().Be(15);
    }

    [Fact]
    public void Day2_SolvePartTwo_Should_Return_Expected()
    {
        var sut = new Day2Solution();

        var result = sut.SolvePartTwo(input);

        result.Should().Be(12);
    }
}
