using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansJoin
    {
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            if (outer == null ||
                inner == null ||
                outerKeySelector == null ||
                innerKeySelector == null ||
                resultSelector == null)
                throw new ArgumentNullException();

            if (comparer == null) comparer = EqualityComparer<TKey>.Default;

            return  JoinIterator(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        private static IEnumerable<TResult> JoinIterator<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            var innerGroups = inner.GroupBy(innerKeySelector);

            foreach (var outerElement in outer)
            {
                var outerKey = outerKeySelector(outerElement);
                if (outerKey == null) continue;

                foreach (var group in innerGroups)
                {
                    if (comparer.Equals(outerKey, group.Key))
                        foreach (var element in group)
                        {
                            yield return resultSelector(outerElement, element);
                        }
                }
            }
        }
    }
}
