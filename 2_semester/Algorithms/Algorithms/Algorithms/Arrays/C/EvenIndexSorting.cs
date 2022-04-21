
public class EvenIndexSorting : ISortingOrder
{
    void ISortingOrder.Order(List<int> array)
    {
        FillArrays(array, out List<int> even, out List<int> notEven);
        even.Sort();
        notEven.Sort();

        for (int i = 0; i < even.Count; ++i)
        {
            array[i] = even[even.Count - 1 - i];
        }
        
        for (int i = 0; i < notEven.Count; ++i)
        {
            array[array.Count - 1 - i] = notEven[notEven.Count - 1 - i];
        }
    }

    private void FillArrays(List<int> array, out List<int> even, out List<int> notEven)
    {
        even = new List<int>();
        notEven = new List<int>();
        
        for (int i = 0; i < array.Count; ++i)
        {
            if (i % 2 == 0)
            {
                even.Add(array[i]);
            }
            else
            {
                notEven.Add(array[i]);
            }
        }
    }
}