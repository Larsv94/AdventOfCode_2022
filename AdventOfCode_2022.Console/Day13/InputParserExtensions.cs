using System.Text;

namespace AdventOfCode_2022.Console.Day13;
public static class InputParserExtensions
{
    public static IEnumerable<string> SplitWithList(this string value)
    {
        using var enumerator = value.GetEnumerator();
        var builder = new StringBuilder();
        var depth = 0;
        while (enumerator.MoveNext())
        {
            switch (enumerator.Current)
            {

                case ',' when depth == 0:
                    yield return builder.ToString();
                    builder.Clear();
                    break;
                case '[':
                    depth++;
                    builder.Append(enumerator.Current);
                    break;
                case ']':
                    depth--;
                    builder.Append(enumerator.Current);
                    break;
                default:
                    builder.Append(enumerator.Current);
                    break;
            }
        }
        if (builder.Length > 0)
        {
            yield return builder.ToString();
        }
    }
}
