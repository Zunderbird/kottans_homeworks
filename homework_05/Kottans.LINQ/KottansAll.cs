using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansAll
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();
            foreach (var element in source)
            {
                if (predicate(element) == false) return false;
            }
            return true;
        }
    }
}
