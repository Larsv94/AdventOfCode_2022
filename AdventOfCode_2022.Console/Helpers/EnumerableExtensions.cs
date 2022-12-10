namespace AdventOfCode_2022.Console.Helpers;
public static class EnumerableExtensions
{
    public static IEnumerable<IList<TSource>> Window<TSource>(this IEnumerable<TSource> source, int size)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));


        using var iter = source.GetEnumerator();

        var window = new TSource[size];
        int i;
        for (i = 0; i < size && iter.MoveNext(); i++)
        {
            window[i] = iter.Current;
        }

        if (i < size) yield break;

        while (iter.MoveNext())
        {
            var newWindow = new TSource[size];
            Array.Copy(window, 1, newWindow, 0, size - 1);
            newWindow[size - 1] = iter.Current;

            yield return window;
            window = newWindow;
        }

        yield return window;

    }
}
