
public class ArraysLab : ILab
{
    private readonly IArraySortingOrder _arraySortingOrder;

    public ArraysLab(IArraySortingOrder arraySortingOrder)
    {
        _arraySortingOrder = arraySortingOrder;
    }
    
    void ILab.Start()
    {
        var array = new List<int>(15);
        array.FillWithRandom();
        
        array.ShowAll();
        _arraySortingOrder.Order(array);
        array.ShowAll();
        Console.WriteLine();
    }
}