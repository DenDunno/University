
public class BinaryTreeLab : ILab
{
    private readonly BinaryTree _binaryTree = new(15);
    
    void ILab.Start()
    {
        Console.WriteLine("1. Binary tree");
        _binaryTree.FillWithRandom();
        _binaryTree.InorderTraversal();
        _binaryTree.PreorderTraversal();
        _binaryTree.PostorderTraversal();
    }
}