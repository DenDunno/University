
public class BinaryHeap : IRandomFilling
{
    private readonly List<int> _collection;

    public BinaryHeap(int size)
    {
        _collection = new List<int>(size);
    }

    public void FillWithRandom()
    {
        var random = new Random();
        
        for (int i = 0; i < _collection.Capacity; ++i)
        {
            Add(random.Next(0, 100));
        }
    }

    private void Add(int number)
    {
        _collection.Add(number);
        int acceptedNodeIndex = _collection.Count;
        int parent = acceptedNodeIndex / 2;
        
        while (parent != 0 && _collection[parent - 1] > _collection[acceptedNodeIndex - 1])
        {
            Swap(acceptedNodeIndex - 1, parent - 1);
            acceptedNodeIndex /= 2;
            parent /= 2;
        }
    }

    private void Swap(int index1, int index2)
    {
        (_collection[index1], _collection[index2]) = (_collection[index2], _collection[index1]);
    }

    public void Show()
    {
        int rows = (int) Math.Log2(_collection.Capacity) + 1;
        
        for (int i = 0; i < rows; ++i)
        {
            int raw = (int) Math.Pow(2, i);
            
            for (int j = 0; j + raw  - 1 < _collection.Count && j < raw; ++j)
            {
                Console.Write(_collection[raw + j - 1] + " ");
            }
            
            Console.WriteLine();
        }
        
        Console.WriteLine();
    }

    public void PopMin()
    {
        Console.WriteLine("Pop min");
        Swap(0, _collection.Count - 1);
        _collection.RemoveAt(_collection.Count - 1);

        int acceptedNodeIndex = 2;
        int parent = 1;
        
        while (acceptedNodeIndex < _collection.Count)
        {
            if (_collection[parent - 1] > _collection[acceptedNodeIndex - 1])
            {
                Swap(acceptedNodeIndex - 1, parent - 1);
            }
            if (_collection[parent - 1] > _collection[acceptedNodeIndex])
            {
                Swap(acceptedNodeIndex, parent - 1);
            }
            
            acceptedNodeIndex *= 2;
            parent *= 2;
        }
    }
}