
public class BinaryTreeTraversal
{
    public void InorderTraversal(Node node)
    {
        if (node.Left != null)
            InorderTraversal(node.Left);
        
        Console.Write(node.Data + " ");
        
        if (node.Right != null)
            InorderTraversal(node.Right);
    }
    
    public void PreorderTraversal(Node node)
    {
        Console.Write(node.Data + " ");
        
        if (node.Left != null)
            PreorderTraversal(node.Left);

        if (node.Right != null)
            PreorderTraversal(node.Right);
    }
    
    public void PostorderTraversal(Node node)
    {
        if (node.Left != null)
            PostorderTraversal(node.Left);

        if (node.Right != null)
            PostorderTraversal(node.Right);
        
        Console.Write(node.Data + " ");
    }
}