using AdventOfCode_2022.Console.Day1;
using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Test.Day1;

public class Day1Test
{
    private readonly string[] challenge1Input =
    {
        "1000",
        "2000",
        "3000",
        "",
        "4000",
        "",
        "5000",
        "6000",
        "",
        "7000",
        "8000",
        "9000",
        "",
        "10000"
    };

    [Fact]
    public void Day1_SolvePartOne_Should_Return_Correct_Calories()
    {
        var sut = new Day1Solution();

        var result = sut.SolvePartOne(challenge1Input);

        result.Should().Be(24000);
    }

    [Fact]
    public void Day1_SolvePartTwo_Should_Return_Correct_Calories()
    {
        ISolution sut = new Day1Solution();

        var result = sut.SolvePartTwo(challenge1Input);

        result.Should().Be(45000);
    }
}
