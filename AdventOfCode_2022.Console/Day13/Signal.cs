using System.Text.RegularExpressions;

namespace AdventOfCode_2022.Console.Day13;
public partial class Signal : IComparable<Signal>
{
    private readonly bool isArray;

    private readonly int? _numberValue = null;
    private readonly Signal[] _arrayValue = Array.Empty<Signal>();

    private Signal(int? numberValue)
    {
        _numberValue = numberValue;
        isArray = false;
    }

    private Signal(Signal[] arrayValue)
    {
        _arrayValue = arrayValue;
        isArray = true;
    }

    public int CompareTo(Signal? rightSignal)
    {
        if (rightSignal == null) return 1;
        var result = (isArray, rightSignal.isArray) switch
        {
            (false, false) => _numberValue!.Value.CompareTo(rightSignal._numberValue!.Value),
            (false, true) => CompareArrays(ToArray(_numberValue!.Value), rightSignal._arrayValue),
            (true, false) => CompareArrays(_arrayValue, ToArray(rightSignal._numberValue!.Value)),
            (true, true) => CompareArrays(_arrayValue, rightSignal._arrayValue),
        };
        return result;
    }

    private int CompareArrays(Signal[] left, Signal[] right)
    {
        int i = 0;
        while (i < left.Length && i < right.Length)
        {
            var isEqual = left[i].CompareTo(right[i]);
            if (isEqual is not 0)
            {
                return isEqual;
            }
            i++;
        }
        return left.Length.CompareTo(right.Length);
    }

    public static Signal[] ToArray(int val)
    {
        return new Signal[] { new Signal(val) };
    }

    public static implicit operator Signal(string val)
    {
        var innerListMatch = IsSignalListRegex().Match(val);
        if (innerListMatch.Success)
        {
            var signalArray = innerListMatch.Groups[2].Value.SplitWithList().Select(x => (Signal)x).ToArray();
            return new Signal(signalArray);
        }
        return new Signal(int.Parse(val));
    }

    [GeneratedRegex("(\\[)(.*)(\\])")]
    private static partial Regex IsSignalListRegex();

}
