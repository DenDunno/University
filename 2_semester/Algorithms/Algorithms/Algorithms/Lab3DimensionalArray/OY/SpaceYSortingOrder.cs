
public class SpaceYSortingOrder : SpaceSortingOrder
{
    protected override Position TransformPosition(int z, int y, int x)
    {
        return new Position(z, x, y);
    }
}