using AdventOfCode_2022.Console.Day3;

namespace AdventOfCode_2022.Test.Day3;

public class BackpackParserTests
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
    [InlineData("ttgJtRGJQctTZtZT", 't')]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
    public void Backpack_Should_Return_Correct_Duplicate_Item(string backpack, char expected)
    {
        var sut = new BackpackParser();
        char result = sut.GetDuplicateItem(backpack);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('p', 16)]
    [InlineData('L', 38)]
    [InlineData('P', 42)]
    [InlineData('v', 22)]
    [InlineData('t', 20)]
    [InlineData('s', 19)]
    public void Backpack_GetPriority_Should_Return_Correct_Priority(char item, int priority)
    {
        var sut = new BackpackParser();

        int result = sut.GetPriority(item);

        result.Should().Be(priority);
    }


    [Fact]
    public void Backpack_GetGroupCode_Should_Return_Correct_Code_For_Group_One()
    {
        var input = """
            vJrwpWtwJgWrhcsFMMfFFhFp
            jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
            PmmdzqPrVvPwwTWBwg
            """.Split(Environment.NewLine);
        var sut = new BackpackParser();

        char result = sut.GetGroupCode(input);

        result.Should().Be('r');
    }

    [Fact]
    public void Backpack_GetGroupCode_Should_Return_Correct_Code_For_Group_Two()
    {
        var input = """
            wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
            ttgJtRGJQctTZtZT
            CrZsJsPPZsGzwwsLwLmpwMDw
            """.Split(Environment.NewLine);
        var sut = new BackpackParser();

        char result = sut.GetGroupCode(input);

        result.Should().Be('Z');
    }
}