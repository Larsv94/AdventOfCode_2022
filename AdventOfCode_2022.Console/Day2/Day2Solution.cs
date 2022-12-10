using AdventOfCode_2022.Console.Helpers;

namespace AdventOfCode_2022.Console.Day2;

public class Day2Solution : ISolution
{
    public int Day => 2;
    public object SolvePartOne(string[] input)
    {
        var game = new RockPaperScissors();
        var rounds = input.Select(i => i.Split(' '));
        var roundsScore = rounds.Select(r => game.GetRoundScore(r[0], r[1]));


        return roundsScore.Sum();
    }

    public object SolvePartTwo(string[] input)
    {
        var game = new RockPaperScissors();
        var rounds = input.Select(i => i.Split(' '));
        var roundsScore = rounds.Select(r => game.PickChoice(r[0], r[1]));


        return roundsScore.Sum();
    }
}