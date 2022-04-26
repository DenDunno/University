
public class MinMaxAlgorithm
{
    private readonly List<int> _minimums = new();
    private readonly List<int> _maximums = new();
    
    public MinMax Evaluate(Matrix matrix)
    {
        _minimums.Clear();
        _maximums.Clear();

        foreach (List<int> raw in matrix.Elements)
        {
            var sortedRaw = new List<int>(raw);
            sortedRaw.Sort();
            
            _minimums.Add(sortedRaw.First());
            _maximums.Add(sortedRaw.Last());
        }

        return new MinMax(_minimums.Min(), _maximums.Max());
    }
}