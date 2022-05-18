
public class MinElementsLab : ILab
{
    private readonly List<int> _elements;
    private readonly int _minElements;

    public MinElementsLab(int size, int minElements)
    {
        _elements = new List<int>(size);
        _minElements = minElements;
    }
    
    void ILab.Start()
    {
        Console.WriteLine("5. Min elements");
        _elements.FillWithRandom();
        
        var sortedElements = new List<int>(_elements);
        sortedElements.Sort();
        sortedElements = sortedElements.GetRange(0, _minElements);
        
        _elements.ShowAll();
        sortedElements.ShowAll();
    }
}