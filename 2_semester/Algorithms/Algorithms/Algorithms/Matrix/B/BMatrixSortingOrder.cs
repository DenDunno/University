
public class BMatrixSortingOrder : IMatrixSortingOrder
{
    void IMatrixSortingOrder.Order(Matrix matrix)
    {
        SortColumn(matrix, 0);
        SortColumn(matrix, 1);
        SortColumn(matrix, matrix.Elements.Count - 1);
    }

    private void SortColumn(Matrix matrix, int columnIndex)
    {
        List<int> column = matrix.Elements.Select(raw => raw[columnIndex]).ToList();
        column.Sort();

        for (int i = 0; i < column.Count; ++i)
        {
            matrix.Elements[i][columnIndex] = column[i];
        }
    }
}