using AdventOfCode_2022.Console.Day2;

namespace AdventOfCode_2022.Test.Day2;
public class RockPaperScissorsTests
{

    [Theory]
    [InlineData("A", "X", 4)]
    [InlineData("A", "Y", 8)]
    [InlineData("A", "Z", 3)]
    [InlineData("B", "X", 1)]
    [InlineData("B", "Y", 5)]
    [InlineData("B", "Z", 9)]
    [InlineData("C", "X", 7)]
    [InlineData("C", "Y", 2)]
    [InlineData("C", "Z", 6)]
    public void Game_GetRoundScore_Should_Return_Correct_Outcome(string opponent, string me, int score)
    {
        var sut = new RockPaperScissors();

        var result = sut.GetRoundScore(opponent, me);

        result.Should().Be(score);
    }
}
