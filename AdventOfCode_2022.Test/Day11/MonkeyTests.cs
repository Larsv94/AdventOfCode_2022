using AdventOfCode_2022.Console.Day11;

namespace AdventOfCode_2022.Test.Day11;
public class MonkeyTests
{
    [Fact]
    public void CreateMonkey_Returns_Expected()
    {
        var result = Monkey.Create("""
            Monkey 0:
              Starting items: 79, 98
              Operation: new = old * 19
              Test: divisible by 23
                If true: throw to monkey 2
                If false: throw to monkey 3
            """.Split(Environment.NewLine).ToList(), new List<Monkey>());
        result.Items.Should().ContainInOrder(79, 98);
    }

    [Fact]
    public void CreateMonkey_Each_Monkey_Should_Know_Friends_When_Creating_Multiple()
    {
        var monkeys = new List<Monkey>();
        var monkey1 = Monkey.Create("""
            Monkey 0:
              Starting items: 79, 98
              Operation: new = old * 19
              Test: divisible by 23
                If true: throw to monkey 2
                If false: throw to monkey 3
            """.Split(Environment.NewLine).ToList(), monkeys);

        var monkey2 = Monkey.Create("""
            Monkey 1:
              Starting items: 54, 65, 75, 74
              Operation: new = old + 6
              Test: divisible by 19
                If true: throw to monkey 2
                If false: throw to monkey 0
            """.Split(Environment.NewLine).ToList(), monkeys);

        monkey1.Items.Should().ContainInOrder(79, 98);
        monkey1.Friends.Should().ContainInOrder(monkey1, monkey2);

        monkey2.Items.Should().ContainInOrder(54, 65, 75, 74);
        monkey2.Friends.Should().ContainInOrder(monkey1, monkey2);
    }
}
