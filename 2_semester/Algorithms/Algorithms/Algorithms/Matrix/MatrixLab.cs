
public class MatrixLab : ILab
{
    private readonly IMatrixSortingOrder _matrixSortingOrder;

    public MatrixLab(IMatrixSortingOrder matrixSortingOrder)
    {
        _matrixSortingOrder = matrixSortingOrder;
    }
    
    void ILab.Start()
    {
        var matrix = new Matrix(6);
        var minMaxAlgorithm = new MinMaxAlgorithm(matrix);
        
        matrix.FillWithRandom();
        matrix.ShowAll();
        
        _matrixSortingOrder.Order(matrix);
        MinMax minMax = minMaxAlgorithm.Evaluate();
        
        Console.WriteLine($"{minMax.Min} {minMax.Max}\n");
        matrix.ShowAll();
    }
}