
public class AMatrixSortingOrder : IMatrixSortingOrder
{
    void IMatrixSortingOrder.Order(Matrix matrix)
    {
        matrix.Elements.First().Sort();
        matrix.Elements[1].Sort();
        
        matrix.Elements.Last().Sort();
    }
}