
public class ArraySortingFromCentreByAscending : ArraySortingFromCentre
{
    protected override int GetOrderedValue(List<int> sortedArray, int i)
    {
        return sortedArray[i];
    }
}