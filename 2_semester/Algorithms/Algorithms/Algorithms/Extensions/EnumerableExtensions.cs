
public static class EnumerableExtensions
{
    public static void FillWithRandom(this List<int> collection, int rangeFrom, int rangeTo)
    {
        var random = new Random();

        for (int i = 0; i < collection.Capacity; ++i)
        {
            collection.Add(random.Next(rangeFrom, rangeTo));
        }
    }

    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (T element in collection)
        {
            action(element);
        }
    }

    public static void ShowAll<T>(this IEnumerable<T> collection)
    {
        foreach (T element in collection)
        {
            Console.Write(element + " ");
        }
        
        Console.WriteLine();
    }
}