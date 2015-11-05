using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Empty<TSource>()
        {
            return EmptyClass<TSource>.Instance;
        }

        static class EmptyClass<TSource>
        {
            private static TSource[] _instance;
            public static IEnumerable<TSource> Instance => _instance ?? (_instance = new TSource[0]);
        }
    }
}
