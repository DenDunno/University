
public abstract class MatrixSortingOrder : IMatrixSortingOrder
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

    private void AddSpiralElement(Matrix matrix, int i, int j)
    {
        _sortedElements.Add(matrix.Elements[i][j]);
    }

    private void SetSortedElementToMatrix(Matrix matrix, int i, int j)
    {
        matrix.Elements[i][j] = _sortedElements[_sortedElementIndex];
        _sortedElementIndex++;
    }

    protected abstract void GoAroundMatrix(Matrix matrix, Action<Matrix, int, int> addSpiralElement);
}