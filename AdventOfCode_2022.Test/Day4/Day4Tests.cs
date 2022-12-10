using AdventOfCode_2022.Console.Day4;

namespace AdventOfCode_2022.Test.Day4;
public class Day4Tests
{

    [Fact]
    public void Day4_PartOne_Should_Return_Expected()
    {
        var input = """
            2-4,6-8
            2-3,4-5
            5-7,7-9
            2-8,3-7
            6-6,4-6
            2-6,4-8
            """.Split(Environment.NewLine);

        var sut = new Day4Solution();
        var result = sut.SolvePartOne(input);

        result.Should().Be(2);
    }
}
