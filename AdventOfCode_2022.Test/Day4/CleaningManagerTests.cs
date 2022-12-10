using AdventOfCode_2022.Console.Day4;

namespace AdventOfCode_2022.Test.Day4;
public class CleaningManagerTests
{
    [Theory]
    [InlineData(2, 4, 6, 8, false)]
    [InlineData(2, 3, 4, 5, false)]
    [InlineData(2, 8, 3, 7, true)]
    [InlineData(3, 7, 2, 8, true)]
    [InlineData(6, 6, 4, 6, true)]
    [InlineData(2, 6, 4, 8, false)]
    [InlineData(5, 9, 4, 8, false)]
    [InlineData(4, 9, 4, 9, true)]
    [InlineData(8, 9, 4, 9, true)]
    [InlineData(8, 8, 4, 9, true)]
    [InlineData(4, 8, 4, 9, true)]
    public void CleaningManager_IsPairFullyOverlapping_Should_Return_Expected(int beginOne, int endOne, int beginTwo, int endTwo, bool expected)
    {
        var sut = new CleaningManager();
        bool result = sut.IsPairFullyOverlapping(new[] { beginOne, endOne }, new[] { beginTwo, endTwo });
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(2, 4, 6, 8, false)]
    [InlineData(2, 3, 4, 5, false)]
    [InlineData(2, 8, 3, 7, true)]
    [InlineData(3, 7, 2, 8, true)]
    [InlineData(6, 6, 4, 6, true)]
    [InlineData(2, 6, 4, 8, true)]
    [InlineData(5, 9, 4, 8, true)]
    [InlineData(4, 9, 4, 9, true)]
    [InlineData(8, 9, 4, 9, true)]
    [InlineData(8, 8, 4, 9, true)]
    [InlineData(4, 8, 4, 9, true)]
    public void CleaningManager_IsPairPartiallyOverlapping_Should_Return_Expected(int beginOne, int endOne, int beginTwo, int endTwo, bool expected)
    {
        var sut = new CleaningManager();
        bool result = sut.IsPartiallyOverlapping(new[] { beginOne, endOne }, new[] { beginTwo, endTwo });
        result.Should().Be(expected);
    }
}
