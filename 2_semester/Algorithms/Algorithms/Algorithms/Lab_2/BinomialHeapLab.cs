using Advanced.Algorithms.DataStructures;

public class BinomialHeapLab : ILab
{
    private readonly BinomialHeap<int> _binomialHeap = new();
    private readonly int _size = 15;
    
    void ILab.Start()
    {
        Console.WriteLine("4. Binomial heap");
        FillHeap();
        ShowHeap();
        
        Console.WriteLine("Pop min");
        _binomialHeap.Extract();
        ShowHeap();
    }

    private void FillHeap()
    {
        var random = new Random();
        
        for (var i = 0; i < _size; ++i)
        {
            _binomialHeap.Insert(random.Next(0, 100));
        }
    }
    
    private void ShowHeap()
    {
        foreach (int element in _binomialHeap)
        {
            Console.Write(element + " ");
        }
        
        Console.WriteLine();
        Console.WriteLine();
    }
}