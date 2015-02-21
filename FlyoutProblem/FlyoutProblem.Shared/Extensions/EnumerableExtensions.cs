using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyoutProblem.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Node<T>> Hierarchize<T, TKey, TOrderKey>(
            this IEnumerable<T> elements,
            TKey topMostKey,
            Func<T, TKey> keySelector,
            Func<T, TKey> parentKeySelector,
            Func<T, TOrderKey> orderingKeySelector)
        {
            var families = elements.ToLookup(parentKeySelector);
            var childrenFetcher = default(Func<TKey, IEnumerable<Node<T>>>);
            childrenFetcher = parentId => families[parentId]
                .OrderBy(orderingKeySelector)
                .Select(x => new Node<T>(x, childrenFetcher(keySelector(x))));

            return childrenFetcher(topMostKey);
        }

        public static IEnumerable<Node<T>> ByHierarchy<T>(
            this IEnumerable<T> source,
            Func<T, bool> startWith,
            Func<T, T, bool> connectBy,
            Func<T, Object> orderBy)
        {
            return source.ByHierarchy<T>(startWith, connectBy, orderBy, null);
        }


        private static IEnumerable<Node<T>> ByHierarchy<T>(
            this IEnumerable<T> source,
            Func<T, bool> startWith,
            Func<T, T, bool> connectBy,
            Func<T, Object> orderBy,
            Node<T> parent)
        {
            int level = (parent == null ? 0 : parent.Level + 1);

            if (source == null)
                throw new ArgumentNullException("source");

            if (startWith == null)
                throw new ArgumentNullException("startWith");

            if (connectBy == null)
                throw new ArgumentNullException("connectBy");

            source = source.OrderBy(orderBy);

            foreach (T value in from item in source
                                where startWith(item)
                                select item)
            {
                Node<T> newNode = new Node<T> { Level = level, Parent = parent, Value = value };

                yield return newNode;

                foreach (Node<T> subNode in source.ByHierarchy<T>(possibleSub => connectBy(value, possibleSub),
                                                                  connectBy, orderBy, newNode))
                {
                    yield return subNode;
                }
            }
        }
    }

}
