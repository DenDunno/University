
public abstract class SpaceSortingOrder : ISpaceSortingOrder
{
    void ISpaceSortingOrder.Order(Space space)
    {
        for (var z = 0; z < space.Matrices.Count; ++z)
        {
            for (var y = 0; y < space.Matrices.Count; ++y)
            {
                SortSpace(space, z, y);
            }
        }
    }

    private void SortSpace(Space space, int z, int y)
    {
        var sortedElements = new List<int>();

        for (var x = 0; x < space.Matrices.Count; ++x)
        {
            Position position = TransformPosition(z, y, x);
            sortedElements.Add(space.Matrices[position.Z].Elements[position.Y][position.X]);
        }   
                
        sortedElements.Sort();
                
        for (var x = 0; x < space.Matrices.Count; ++x)
        {
            Position position = TransformPosition(z, y, x);
            space.Matrices[position.Z].Elements[position.Y][position.X] = sortedElements[x];
        }
    }

    protected abstract Position TransformPosition(int z, int y, int x);
}