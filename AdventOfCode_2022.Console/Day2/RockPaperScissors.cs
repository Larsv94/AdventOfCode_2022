namespace AdventOfCode_2022.Console.Day2;
public class RockPaperScissors
{
    public int GetRoundScore(string opponent, string me)
    {
        return (opponent, me) switch
        {
            ("A", "X") => 4,
            ("A", "Y") => 8,
            ("A", "Z") => 3,
            ("B", "X") => 1,
            ("B", "Y") => 5,
            ("B", "Z") => 9,
            ("C", "X") => 7,
            ("C", "Y") => 2,
            ("C", "Z") => 6,
            _ => throw new ArgumentOutOfRangeException(nameof(me), me),
        };
    }

    public int PickChoice(string opponent, string me)
    {
        return (opponent, me) switch
        {
            ("A", "X") => 0 + 3, //rock lose scissors
            ("A", "Y") => 3 + 1, //rock draw rock
            ("A", "Z") => 6 + 2, //rock win paper
            ("B", "X") => 0 + 1, //paper lose Rock
            ("B", "Y") => 3 + 2, //paper draw paper
            ("B", "Z") => 6 + 3, //paper win scissors
            ("C", "X") => 0 + 2, //scissors lose paper
            ("C", "Y") => 3 + 3, //scissors draw scissors
            ("C", "Z") => 6 + 1, //scissors win rock
            _ => throw new ArgumentOutOfRangeException(nameof(me), me),
        };
    }


}
