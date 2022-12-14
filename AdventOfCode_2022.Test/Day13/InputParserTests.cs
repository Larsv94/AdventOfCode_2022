using AdventOfCode_2022.Console.Day13;

namespace AdventOfCode_2022.Test.Day13;
public class InputParserTests
{
    [Theory]
    [MemberData(nameof(SplitWithList_Should_Return_TestData))]
    public void SplitWithList_Should_Return_Expected(string input, string[] expected)
    {
        var result = input.SplitWithList().ToArray();

        result.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> SplitWithList_Should_Return_TestData()
    {
        yield return new object[]
        {
            "1234",
            new string[] { "1234"}
        };

        yield return new object[]
        {
            "[1234]",
            new string[] { "[1234]"}
        };

        yield return new object[]
        {
            "[1,2],3,4",
            new string[] { "[1,2]","3","4"}
        };

        yield return new object[]
        {
            "[[0],1,2],3,4",
            new string[] { "[[0],1,2]", "3","4"}
        };

        yield return new object[]
        {
            "[[0],1,2],3,4,[5,6]",
            new string[] { "[[0],1,2]", "3","4", "[5,6]" }
        };
    }
}
