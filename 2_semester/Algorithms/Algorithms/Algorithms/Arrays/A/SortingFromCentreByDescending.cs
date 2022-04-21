
public class SortingFromCentreByDescending : SortingFromCentre
{
    protected override int GetOrderedValue(List<int> sortedArray, int i)
    {
        return sortedArray[sortedArray.Count - 1 - i];
    }
}