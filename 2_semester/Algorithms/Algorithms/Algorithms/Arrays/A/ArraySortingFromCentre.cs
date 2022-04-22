
public abstract class ArraySortingFromCentre : IArraySortingOrder
{
    void IArraySortingOrder.Order(List<int> array)
    {
        var sortedArray = new List<int>(array);
        sortedArray.Sort();

        for (int i = 0, j = array.Count / 2; i < array.Count; ++i, j = GetIndex(j, i))
        {
            array[j] = GetOrderedValue(sortedArray, i);
        }
    }

    private int GetIndex(int j, int i)
    {
        if (i % 2 != 0)
            i = -i;

        return j + i;
    }

    protected abstract int GetOrderedValue(List<int> sortedArray, int i);
}