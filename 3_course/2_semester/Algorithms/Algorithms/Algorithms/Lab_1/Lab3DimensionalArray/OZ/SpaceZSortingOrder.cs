
public class SpaceZSortingOrder : SpaceSortingOrder
{
    protected override Position TransformPosition(int z, int y, int x)
    {
        return new Position(x, y, z);
    }
}