using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansSequenceEqual
    {
        public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return IsSequenceEqual(first, second, null);
        }

        public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, 
            IEqualityComparer<TSource> comparer)
        {
            return IsSequenceEqual(first, second, comparer);
        }

        public static bool SequenceEqual<TSource>(this ICollection<TSource> first, ICollection<TSource> second)
        {
            return first.SequenceEqual(second, null);
        }

        public static bool SequenceEqual<TSource>(this ICollection<TSource> first, ICollection<TSource> second, 
            IEqualityComparer<TSource> comparer)
        {
            if (first == null || second == null) throw new ArgumentNullException();
            if (first.Count != second.Count) return false;

            return IsSequenceEqual(first, second, comparer);
        }

        private static bool IsSequenceEqual<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            if (first == null || second == null) throw new ArgumentNullException();
            if (comparer == null) comparer = EqualityComparer<TSource>.Default;

            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (firstEnumerator.MoveNext())
            {
                if (!secondEnumerator.MoveNext() || !comparer.Equals(firstEnumerator.Current, secondEnumerator.Current)) return false;
            }
            if (firstEnumerator.MoveNext() || secondEnumerator.MoveNext()) return false;
            return true;
        }
    }
}
