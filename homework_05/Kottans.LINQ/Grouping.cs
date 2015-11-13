using System.Collections.Generic;

namespace Kottans.LINQ
{
    public interface IGrouping<TKey, TValue> : IEnumerable<TValue>
    {
        TKey Key { get; }
    }

    public class Grouping<TKey, TValue> : List<TValue>, IGrouping<TKey, TValue> 
    {
        public TKey Key { get; }

        public Grouping(TKey key)
        {
            Key = key;
        }
    }
}
