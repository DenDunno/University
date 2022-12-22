using System;
using System.Collections.Generic;

public static class EnumerableExtensions
{
    public static void Remove<T>(this List<T> collection, Predicate<T> predicate)
    {
        T element = collection.Find(predicate);
        collection.Remove(element);
    }

    public static bool InRange<T>(this ICollection<T> collection, int index)
    {
        return index >= 0 && index < collection.Count;
    }
}