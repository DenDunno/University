
public class SortingFromCentreByAscending : SortingFromCentre
{
    protected override int GetOrderedValue(List<int> sortedArray, int i)
    {
        return sortedArray[i];
    }
}