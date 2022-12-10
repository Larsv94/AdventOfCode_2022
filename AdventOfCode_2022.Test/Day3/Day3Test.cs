using AdventOfCode_2022.Console.Day3;

namespace AdventOfCode_2022.Test.Day3;
public class Day3Test
{
    private readonly string[] input = """
        vJrwpWtwJgWrhcsFMMfFFhFp
        jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
        PmmdzqPrVvPwwTWBwg
        wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
        ttgJtRGJQctTZtZT
        CrZsJsPPZsGzwwsLwLmpwMDw
        """.Split(Environment.NewLine);


    [Fact]
    public void Day3_PartOne()
    {
        var sut = new Day3Solution();
        var result = sut.SolvePartOne(input);
        result.Should().Be(157);
    }

    [Fact]
    public void Day3_PartTwo()
    {
        var sut = new Day3Solution();
        var result = sut.SolvePartTwo(input);
        result.Should().Be(70);
    }

}
