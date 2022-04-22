
public class CMatrixSortingOrder : IMatrixSortingOrder
{
    private readonly List<int> _sortedElements = new();
    private int _sortedElementIndex = 0;
    
    void IMatrixSortingOrder.Order(Matrix matrix)
    {
        _sortedElements.Clear();
        _sortedElementIndex = 0;
        
        GoAroundMatrix(matrix, AddSpiralElement);
        _sortedElements.Sort();
        GoAroundMatrix(matrix, SetSortedElementToMatrix);
    }

    private void GoAroundMatrix(Matrix matrix, Action<Matrix, int, int> action)
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

    private void AddSpiralElement(Matrix matrix, int i, int j)
    {
        _sortedElements.Add(matrix.Elements[i][j]);
    }
    
    private void SetSortedElementToMatrix(Matrix matrix, int i, int j)
    {
        matrix.Elements[i][j] = _sortedElements[_sortedElementIndex];
        _sortedElementIndex++;
    }
}