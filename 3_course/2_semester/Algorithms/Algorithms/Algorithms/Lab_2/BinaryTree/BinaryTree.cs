
public class BinaryTree : IRandomFilling
{
    private readonly BinaryTreeTraversal _binaryTreeTraversal = new BinaryTreeTraversal();
    private readonly int _size;
    private Node? _root;

    public BinaryTree(int size)
    {
        _size = size;
    }
 
    public void FillWithRandom()
    {
        var random = new Random();
        int size = 0;

        while (size < _size)
        {
            if (Add(random.Next(10, 100)))
            {
                ++size;
            }
        }
    }

    private bool Add(int number)
    {
        if (_root == null)
        {
            _root = new Node(number);
            return true;
        }

        if (Search(number) == false)
        {
            Add(_root, number);
            return true;
        }

        return false;
    }

    private bool Search(int number)
    {
        if (_root == null)
        {
            return false;
        }

        if (_root.Data == number)
        {
            return true;
        }

        return Search(_root, number);
    }

    private bool Search(Node node, int number)
    {
        ref Node? acceptedNode = ref number < node.Data ? ref node.Left : ref node.Right;

        if (acceptedNode == null)
        {
            return false;
        }

        return acceptedNode.Data == number || Search(acceptedNode, number);
    }

    private void Add(Node node, int number)
    {
        ref Node? acceptedNode = ref number < node.Data ? ref node.Left : ref node.Right;

        if (acceptedNode != null)
        {
            Add(acceptedNode, number);
        }

        else
        {
            acceptedNode = new Node(number);
        }
    }

    public void InorderTraversal()
    {
        Console.WriteLine("Inorder traversal");
        _binaryTreeTraversal.InorderTraversal(_root!);
        Console.WriteLine('\n');
    }
    
    public void PreorderTraversal()
    {
        Console.WriteLine("Preorder traversal");
        _binaryTreeTraversal.PreorderTraversal(_root!);
        Console.WriteLine('\n');
    }
    
    public void PostorderTraversal()
    {
        Console.WriteLine("Postorder traversal");
        _binaryTreeTraversal.PostorderTraversal(_root!);
        Console.WriteLine('\n');
    }
}