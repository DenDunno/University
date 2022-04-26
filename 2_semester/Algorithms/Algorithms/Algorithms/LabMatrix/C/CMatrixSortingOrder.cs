
public class CMatrixSortingOrder : MatrixSortingOrder
{
    protected override void GoAroundMatrix(Matrix matrix, Action<Matrix, int, int> action)
    {
        int matrixSize = matrix.Elements[0].Count;
        
        for (int i = 0; i < matrixSize - 1; ++i)
            action(matrix, 0, i);
        
        for (int i = 0 ; i < matrixSize - 1; ++i)
            action(matrix, i, matrixSize - 1);
        
        for (int i = matrixSize - 1 ; i > 0; --i)
            action(matrix, matrixSize - 1, i);
        
        for (int i = matrixSize - 1 ; i > 1; --i)
            action(matrix, i, 0);
        
        for (int i = 0 ; i < matrixSize - 2; ++i)
            action(matrix, 1, i);
        
        for (int i = 1 ; i < matrixSize - 1; ++i)
            action(matrix, i, matrixSize - 2);
    }
}