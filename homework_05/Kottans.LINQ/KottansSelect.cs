using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansSelect
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            return SelectIterator(source, predicate);
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            return SelectIterator(source, predicate);
        }

        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(IEnumerable<TSource> source,
            Func<TSource, TResult> predicate)
        {
            foreach (var elem in source)
            {
                yield return predicate(elem);
            }
        }

        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(IEnumerable<TSource> source,
            Func<TSource, int, TResult> predicate)
        {
            var index = 0;

            foreach (var elem in source)
            {
                yield return predicate(elem, index++);
            }
        }
    }
}
