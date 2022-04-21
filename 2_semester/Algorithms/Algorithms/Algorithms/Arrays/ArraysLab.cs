
public class ArraysLab : ILab
{
    private readonly ISortingOrder _sortingOrder;

    public ArraysLab(ISortingOrder sortingOrder)
    {
        _sortingOrder = sortingOrder;
    }
    
    public void Start()
    {
        var array = new List<int>(15);
        array.FillWithRandom(0, 100);
        
        array.ShowAll();
        _sortingOrder.Order(array);
        array.ShowAll();
    }
}