
public class ArraysLab : ILab
{
    private readonly IArraySortingOrder _arraySortingOrder;

    public ArraysLab(IArraySortingOrder arraySortingOrder)
    {
        _arraySortingOrder = arraySortingOrder;
    }
    
    public void Start()
    {
        var array = new List<int>(15);
        array.FillWithRandom(10, 100);
        
        array.ShowAll();
        _arraySortingOrder.Order(array);
        array.ShowAll();
        Console.WriteLine();
    }
}