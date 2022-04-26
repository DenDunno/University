
public class SpaceXSortingOrder : SpaceSortingOrder
{
    protected override Position TransformPosition(int z, int y, int x)
    {
        return new Position(z, y, x);
    }
}