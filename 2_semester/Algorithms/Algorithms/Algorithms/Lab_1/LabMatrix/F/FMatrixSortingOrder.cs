
public class FMatrixSortingOrder : MatrixSortingOrder
{
    protected override void GoAroundMatrix(Matrix matrix, Action<Matrix, int, int> action)
    {
        int[] indexes = {0, 1, 1, 0};
        
        for (int i = 0, j = 0; i < matrix.Elements.Count; ++i, j = (j + 2) % 4)
        {
            action(matrix, i, indexes[j]);
            action(matrix, i, indexes[j + 1]);
        }
        
        action(matrix, matrix.Elements.Count - 1, 2);
        action(matrix, matrix.Elements.Count - 1, 3);
        action(matrix, matrix.Elements.Count - 2, 3);
        action(matrix, matrix.Elements.Count - 2, 2);
        action(matrix, matrix.Elements.Count - 2, 2);
        action(matrix, matrix.Elements.Count - 3, 2);
    }
}