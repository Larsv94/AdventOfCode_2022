using System.Linq.Expressions;
using System.Numerics;

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

    public static (U minX, U maxX, U minY, U maxY) Bounds<T, U>(
        this IEnumerable<T> source,
        Expression<Func<T, U>> xExpression,
        Expression<Func<T, U>> yExpression)
        where U : notnull, IMinMaxValue<U>, INumber<U>
    {
        U minX = U.MaxValue;
        U maxX = U.MinValue;
        U minY = U.MaxValue;
        U maxY = U.MinValue;

        var getX = xExpression.Compile();
        var getY = yExpression.Compile();

        foreach (var item in source)
        {
            var x = getX(item);
            var y = getY(item);

            if (x is null || y is null)
            {
                continue;
            }

            minX = U.Min(minX, x);
            maxX = U.Max(maxX, x);
            minY = U.Min(minY, y);
            maxY = U.Max(maxY, y);
        }

        return (minX, maxX, minY, maxY);
    }

    public static (U minX, U maxX, U minY, U maxY) Bounds<T, U>(
        this IEnumerable<T> source,
        Expression<Func<T, U>> xMinExpression,
        Expression<Func<T, U>> xMaxExpression,
        Expression<Func<T, U>> yMinExpression,
        Expression<Func<T, U>> yMaxExpression)
        where U : notnull, IMinMaxValue<U>, INumber<U>
    {
        U minX = U.MinValue;
        U maxX = U.MaxValue;
        U minY = U.MinValue;
        U maxY = U.MaxValue;

        var getMinX = xMinExpression.Compile();
        var getMinY = yMinExpression.Compile();
        var getMaxX = xMaxExpression.Compile();
        var getMaxY = yMaxExpression.Compile();

        foreach (var item in source)
        {

            minX = U.Min(minX, getMinX(item));
            maxX = U.Max(maxX, getMaxX(item));
            minY = U.Min(minY, getMinY(item));
            maxY = U.Max(maxY, getMaxY(item));
        }

        return (minX, maxX, minY, maxY);
    }
}
