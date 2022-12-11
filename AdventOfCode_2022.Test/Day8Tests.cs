using AdventOfCode_2022.Console.Day8;

namespace AdventOfCode_2022.Test;
public class Day8Tests
{
    [Fact]
    public void Day8_PartOne_SolvesCorrect()
    {
        var input = """
            30373
            25512
            65332
            33549
            35390
            """.Split(Environment.NewLine);
        var sut = new Day8Solution();

        var result = sut.SolvePartOne(input);

        result.Should().Be(21);
    }

    [Fact]
    public void Day8_PartTwo_SolvesCorrect()
    {
        var input = """
            30373
            25512
            65332
            33549
            35390
            """.Split(Environment.NewLine);
        var sut = new Day8Solution();

        var result = sut.SolvePartTwo(input);

        result.Should().Be(8);
    }

    [Fact]
    public void Day8_PartTwo_SolvesCorrect_2()
    {
        var input = """
            1303731
            1255121
            1653321
            1335491
            1353901
            1111111
            """.Split(Environment.NewLine);
        var sut = new Day8Solution();

        var result = sut.SolvePartTwo(input);

        result.Should().Be(32);
    }
}
