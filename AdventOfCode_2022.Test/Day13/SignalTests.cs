using AdventOfCode_2022.Console.Day13;

namespace AdventOfCode_2022.Test.Day13;
public class SignalTests
{
    [Theory]
    [InlineData("[1,1,3,1,1]", "[1,1,5,1,1]", true)]
    [InlineData("[[1],[2,3,4]]", "[[1],4]", true)]
    [InlineData("[9]", "[[8,7,6]]", false)]
    [InlineData("[[4,4],4,4]", "[[4,4],4,4,4]", true)]
    [InlineData("[7,7,7,7]", "[7,7,7]", false)]
    [InlineData("[]", "[3]", true)]
    [InlineData("[[[]]] ", "[[]]", false)]
    [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]", false)]

    public void Signal_CompareWithRight_Should_Return_Expected(string leftString, string rightString, bool expected)
    {
        Signal left = leftString;
        Signal right = rightString;

        var result = left.CompareTo(right);

        result.Should().Be(expected ? -1 : 1);
    }
}
