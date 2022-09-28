
public class Matrix
{
    public readonly List<List<int>> Elements = new();

    public Matrix(int size)
    {
        for (int i = 0; i < size; ++i)
        {
            Elements.Add(new List<int>(size));
        }
    }
    
    public void FillWithRandom()
    {
        foreach (List<int> raw in Elements)
        {
            raw.FillWithRandom();
        }
    }

    public void ShowAll()
    {
        foreach (List<int> raw in Elements)
        {
            raw.ShowAll();
        }
        
        Console.WriteLine();
    }
}