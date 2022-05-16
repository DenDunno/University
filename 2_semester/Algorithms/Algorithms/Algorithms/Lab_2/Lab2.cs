
public class Lab2 : ILab
{
    private readonly BinaryTree _binaryTree = new(8);
    
    void ILab.Start()
    {
        _binaryTree.FillWithRandom();
        _binaryTree.InorderTraversal();
        _binaryTree.PreorderTraversal();
        _binaryTree.PostorderTraversal();
    }
}