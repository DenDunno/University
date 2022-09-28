
public class EMatrixSortingOrder : IMatrixSortingOrder
{
    void IMatrixSortingOrder.Order(Matrix matrix)
    {
        matrix.Elements[0].Sort();
        matrix.Elements[1] = matrix.Elements[1].OrderByDescending(x => x).ToList();
        matrix.Elements[2].Sort();
        matrix.Elements[3] = matrix.Elements[1].OrderByDescending(x => x).ToList();
    }
}