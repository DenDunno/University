using Advanced.Algorithms.DataStructures;

public class RedBlackTreeLab : ILab
{
    private readonly RedBlackTree<int> _redBlackTree = new();
    private readonly int _size = 15;
    
    void ILab.Start()
    {
        Console.WriteLine("2. Red black tree");
        FillHeap();
        ShowHeap();
        
        Console.WriteLine("Delete first element");
        _redBlackTree.Delete(0);
        ShowHeap();
    }

    private void FillHeap()
    {
        var random = new Random();
        _redBlackTree.Insert(0);
            
        for (var i = 0; i < _size - 1; ++i)
        {
            _redBlackTree.Insert(random.Next(0, 100));
        }
    }
    
    private void ShowHeap()
    {
        foreach (int element in _redBlackTree)
        {
            Console.Write(element + " ");
        }
        
        Console.WriteLine();
        Console.WriteLine();
    }
}