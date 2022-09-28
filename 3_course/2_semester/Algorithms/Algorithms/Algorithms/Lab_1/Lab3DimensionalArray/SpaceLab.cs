
public class SpaceLab : ILab
{
    private readonly ISpaceSortingOrder _spaceSortingOrder;

    public SpaceLab(ISpaceSortingOrder spaceSortingOrder)
    {
        _spaceSortingOrder = spaceSortingOrder;
    }
    
    void ILab.Start()
    {
        var space = new Space(3);
        space.FillWithRandom();
        space.Show();

        MinMax minMax = EvaluateMinMax(space);
        Console.WriteLine($"{minMax.Min} {minMax.Max}\n");
        
        _spaceSortingOrder.Order(space);
        space.Show();
    }

    private MinMax EvaluateMinMax(Space space)
    {
        var minMaxes = new List<MinMax>();
        var minMaxAlgorithm = new MinMaxAlgorithm();
        
        foreach (Matrix matrix in space.Matrices)
        {
            minMaxes.Add(minMaxAlgorithm.Evaluate(matrix));
        }
        
        int min = minMaxes.Select(minMax => minMax.Min).Min();
        int max = minMaxes.Select(minMax => minMax.Max).Max();

        return new MinMax(min, max);
    }
}