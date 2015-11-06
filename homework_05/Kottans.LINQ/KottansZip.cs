using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansZip
    {
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> predicate)
        {
            if (first == null || second == null || predicate == null) throw new ArgumentNullException();
            return ZipIterator(first, second, predicate);
        }

        public static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> predicate)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return predicate(firstEnumerator.Current, secondEnumerator.Current);
            }
        }
    }
}
