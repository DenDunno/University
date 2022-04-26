
public class DMatrixSortingOrder : MatrixSortingOrder
{
    protected override void GoAroundMatrix(Matrix matrix, Action<Matrix, int, int> action)
    {
        action(matrix, 2, matrix.Elements.Count / 2);
        action(matrix, 1, matrix.Elements.Count / 2);
        action(matrix, 1, matrix.Elements.Count / 2 + 1);
        action(matrix, 2, matrix.Elements.Count / 2 + 1);
        action(matrix, 3, matrix.Elements.Count / 2 + 1);
        action(matrix, 3, matrix.Elements.Count / 2);
        action(matrix, 3, matrix.Elements.Count / 2 - 1);
        action(matrix, 2, matrix.Elements.Count / 2 - 1);
        action(matrix, 1, matrix.Elements.Count / 2 - 1);

        for (int i = matrix.Elements.Count / 2 - 1; i < matrix.Elements.Count; ++i)
            action(matrix, 0, i);
    }
}