using AdventOfCode_2022.Console.Day5;

namespace AdventOfCode_2022.Test.Day5;
public class InputParserTests
{
    [Fact]
    public void GetCrateSection_should_return_only_crates()
    {
        var input = """
                [D]    
            [N] [C]    
            [Z] [M] [P]
             1   2   3 
            
            move 1 from 2 to 1
            move 3 from 1 to 3
            move 2 from 2 to 1
            move 1 from 1 to 2
            """.Split(Environment.NewLine);

        var sut = new InputParser();

        string[] result = sut.GetCrateSection(input);

        result.Should().HaveCount(3);
    }

    [Fact]
    public void GetStacks_should_return_expected_stacks_v1()
    {
        var input = """
                [D]    
            [N] [C]    
            [Z] [M] [P]
            """.Split(Environment.NewLine);

        var sut = new InputParser();

        Stack<char>[] result = sut.GetStacks(input);

        result.Should().HaveCount(3);
        result[0].Should().BeEquivalentTo(new Stack<char>(new char[] { 'Z', 'N' }.Reverse()));
        result[1].Should().BeEquivalentTo(new Stack<char>(new char[] { 'M', 'C', 'D' }.Reverse()));
        result[2].Should().BeEquivalentTo(new Stack<char>(new char[] { 'P' }.Reverse()));

    }

    [Fact]
    public void GetInstruction_Should_Return_Correct_Instructions()
    {
        var input = """
            move 1 from 2 to 1
            move 3 from 1 to 3
            move 2 from 2 to 1
            move 1 from 1 to 2
            """.Split(Environment.NewLine);

        var sut = new InputParser();
        IEnumerable<Instruction> result = sut.GetInstructions(input);

        result.Should().HaveCount(4);
        var first = result.First();
        first.Amount.Should().Be(1);
        first.From.Should().Be(2);
        first.To.Should().Be(1);

        var last = result.Last();
        last.Amount.Should().Be(1);
        last.From.Should().Be(1);
        last.To.Should().Be(2);
    }
}
