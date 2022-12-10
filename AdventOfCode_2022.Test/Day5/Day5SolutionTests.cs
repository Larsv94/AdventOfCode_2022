using AdventOfCode_2022.Console.Day5;

namespace AdventOfCode_2022.Test.Day5;
public class Day5SolutionTests
{
    readonly string[] input = """
                [D]    
            [N] [C]    
            [Z] [M] [P]
             1   2   3 
            
            move 1 from 2 to 1
            move 3 from 1 to 3
            move 2 from 2 to 1
            move 1 from 1 to 2
            """.Split(Environment.NewLine);
    [Fact]
    public void Day5_PartOne_Should_Return_Expected()
    {
        var sut = new Day5Solution();
        var result = sut.SolvePartOne(input);
        result.Should().Be("CMZ");
    }

    [Fact]
    public void Day5_PartTwo_Should_Return_Expected()
    {
        var sut = new Day5Solution();
        var result = sut.SolvePartTwo(input);
        result.Should().Be("MCD");
    }
}
