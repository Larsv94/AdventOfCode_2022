using System.Text.RegularExpressions;

namespace AdventOfCode_2022.Console.Day11;
public partial class Monkey
{
    public List<Monkey> Friends { get; set; }
    public List<long> Items { get; set; }

    private readonly string _action;
    private readonly string _actionAmount;
    private readonly int _divisibleBy;

    private readonly int _throwToIfTrue;
    private readonly int _throwToIfFalse;
    private readonly int monkeyNmbr;

    public int Actions { get; private set; } = 0;

    private Monkey(List<Monkey> friends, List<long> items, string action, string actionAmount, int divisibleBy, int throwToIfTrue, int throwToIfFalse, int monkeyNmbr)
    {
        Friends = friends ?? throw new ArgumentNullException(nameof(friends));
        Items = items ?? throw new ArgumentNullException(nameof(items));
        _action = action ?? throw new ArgumentNullException(nameof(action));
        _actionAmount = actionAmount;
        _divisibleBy = divisibleBy;
        _throwToIfTrue = throwToIfTrue;
        _throwToIfFalse = throwToIfFalse;
        this.monkeyNmbr = monkeyNmbr;
    }

    public void InspectAndThrowItems()
    {
        Actions += Items.Count;
        foreach (var item in Items)
        {
            var newValue = ModifyWorry(item);
            var afterInspection = (long)Math.Floor(newValue / 3m);

            var monkeyNmbrToThrowTo = afterInspection % _divisibleBy == 0 ? _throwToIfTrue : _throwToIfFalse;
            Friends[monkeyNmbrToThrowTo].Items.Add(afterInspection);
        }
        Items.Clear();
    }

    private long ModifyWorry(long worry)
    {
        var actionAmount = _actionAmount switch
        {
            "old" => worry,
            _ => int.Parse(_actionAmount)
        };
        return _action switch
        {
            "+" => actionAmount + worry,
            "*" => actionAmount * worry,
            _ => throw new NotSupportedException()
        }; ;
    }



    private static int monkeyCount = 0;
    public static Monkey Create(List<string> monkeyString, List<Monkey> friends)
    {
        var items = MonkeyItemsRegex().Match(monkeyString[1]).Groups[1].Value.Split(',').Select(long.Parse).ToList();
        var operations = MonkeyOperationRegex().Match(monkeyString[2]).Groups;
        var action = operations[1].Value;
        var actionAmount = operations[2].Value;
        var divisible = int.Parse(MonkeyDivisibleRegex().Match(monkeyString[3]).Groups[1].Value);
        var ifTrue = int.Parse(MonkeyConditionRegex().Match(monkeyString[4]).Groups[1].Value);
        var ifFalse = int.Parse(MonkeyConditionRegex().Match(monkeyString[5]).Groups[1].Value);

        var monkey = new Monkey(friends, items, action, actionAmount, divisible, ifTrue, ifFalse, monkeyCount);
        monkeyCount++;
        friends.Add(monkey);
        return monkey;
    }

    [GeneratedRegex("Starting items:([ \\d,]+)")]
    private static partial Regex MonkeyItemsRegex();
    [GeneratedRegex("Operation: new = old ([+*]) (.*)")]
    private static partial Regex MonkeyOperationRegex();
    [GeneratedRegex("Test: divisible by (\\d*)")]
    private static partial Regex MonkeyDivisibleRegex();
    [GeneratedRegex("throw to monkey (\\d)")]
    private static partial Regex MonkeyConditionRegex();
}
