using System;
using System.Collections.Generic;
using System.Linq;

namespace DistinctAssigning
{
    public static class EnumerableExtensions
    {
        public static TResult SelectDistinctOrDefault<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            var distinct = source.Select(selector).Distinct();
            return distinct.Count() == 1 ? distinct.Single() : default;
        }
    }
}
