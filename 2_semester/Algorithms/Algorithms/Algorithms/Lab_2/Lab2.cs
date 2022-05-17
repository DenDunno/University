
public class Lab2 : ILab
{
    private readonly BinaryTree _binaryTree = new(15);
    private readonly BinaryHeap _binaryHeap = new(15);
    
    void ILab.Start()
    {
        FillCollections();

        Console.WriteLine("Binary tree");
        _binaryTree.InorderTraversal();
        _binaryTree.PreorderTraversal();
        _binaryTree.PostorderTraversal();

        Console.WriteLine("Binary heap");
        _binaryHeap.Show();
        _binaryHeap.PopMin();
        _binaryHeap.Show();
    }

    private void FillCollections()
    {
        IRandomFilling[] collections = {_binaryTree, _binaryHeap};

        foreach (IRandomFilling collection in collections)
        {
            collection.FillWithRandom();
        }
    }
}