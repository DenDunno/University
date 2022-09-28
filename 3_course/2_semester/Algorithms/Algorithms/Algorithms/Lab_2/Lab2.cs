
public class Lab2 : ILab
{
    private readonly ILab[] _labs = 
    {
        new BinaryTreeLab(),
        new RedBlackTreeLab(),
        new BinaryHeapLab(),
        new BinomialHeapLab(),
        new MinElementsLab(15, 5)
    };
    
    void ILab.Start()
    {
        foreach (ILab lab in _labs)
        {
            lab.Start();
        }
    }
}