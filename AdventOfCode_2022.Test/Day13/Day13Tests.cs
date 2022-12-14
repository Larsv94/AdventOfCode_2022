using AdventOfCode_2022.Console.Day13;

namespace AdventOfCode_2022.Test.Day13;
public class Day13Tests
{
    [Fact]
    public void Day13_PartOne_Solves()
    {
        var input = """
            [1,1,3,1,1]
            [1,1,5,1,1]

            [[1],[2,3,4]]
            [[1],4]

            [9]
            [[8,7,6]]

            [[4,4],4,4]
            [[4,4],4,4,4]

            [7,7,7,7]
            [7,7,7]

            []
            [3]

            [[[]]]
            [[]]

            [1,[2,[3,[4,[5,6,7]]]],8,9]
            [1,[2,[3,[4,[5,6,0]]]],8,9]
            """.Split(Environment.NewLine);

        var sut = new Day13Solution();

        var result = sut.SolvePartOne(input);

        result.Should().Be(13);
    }
}
