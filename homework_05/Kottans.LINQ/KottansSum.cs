using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansSum
    {
        public static int Sum(this IEnumerable<int> source)
        {
            if (source == null) throw new ArgumentNullException();

            var sum = 0;
            checked
            {
                foreach (var element in source) { sum += element; }
            }

            return sum;
        }

        public static int? Sum(this IEnumerable<int?> source)
        {
            if (source == null) throw new ArgumentNullException();

            int sum = 0;
            checked
            {
                foreach (var element in source) { sum += element.GetValueOrDefault(); }
            }
            return sum;
        }

        public static long Sum(this IEnumerable<long> source)
        {
            if (source == null) throw new ArgumentNullException();

            long sum = 0;
            checked
            {
                foreach (var element in source) { sum += element; }
            }
            return sum;
        }

        public static long? Sum(this IEnumerable<long?> source)
        {
            if (source == null) throw new ArgumentNullException();

            long sum = 0;
            checked
            {
                foreach (var element in source) { sum += element.GetValueOrDefault(); }
            }
            return sum;
        }

        public static double Sum(this IEnumerable<double> source)
        {
            if (source == null) throw new ArgumentNullException();

            double sum = 0;
            foreach (var element in source) { sum += element; }
            return sum;
        }

        public static double? Sum(this IEnumerable<double?> source)
        {
            if (source == null) throw new ArgumentNullException();

            double sum = 0;
            foreach (var element in source) { sum += element.GetValueOrDefault(); }
            return sum;
        }

        public static float Sum(this IEnumerable<float> source)
        {
            if (source == null) throw new ArgumentNullException();

            double sum = 0;
            foreach (var element in source) { sum += element; }
            return (float)sum;
        }

        public static float? Sum(this IEnumerable<float?> source)
        {
            if (source == null) throw new ArgumentNullException();

            float sum = 0;
            foreach (var element in source) { sum += element.GetValueOrDefault(); }
            return sum;
        }

        public static decimal Sum(this IEnumerable<decimal> source)
        {
            if (source == null) throw new ArgumentNullException();

            decimal sum = 0;
            foreach (var element in source) { sum += element; }
            return sum;
        }

        public static decimal? Sum(this IEnumerable<decimal?> source)
        {
            if (source == null) throw new ArgumentNullException();

            decimal sum = 0;
            foreach (var element in source) { sum += element.GetValueOrDefault(); }
            return sum;
        }

        public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            return Sum(source.Select(predicate));
        }

        public static int? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            return Sum(source.Select(predicate));
        }

        public static long? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            return Sum(source.Select(predicate));
        }

        public static long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            return Sum(source.Select(predicate));
        }

        public static double Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            return Sum(source.Select(predicate));
        }

        public static double? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            return Sum(source.Select(predicate));
        }

        public static float Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            return Sum(source.Select(predicate));
        }

        public static float? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            return Sum(source.Select(predicate));
        }

        public static decimal Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            return Sum(source.Select(predicate));
        }

        public static decimal? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> predicate)
        {
            if (source == null) throw new ArgumentNullException();
            return Sum(source.Select(predicate));
        }
    }
}
