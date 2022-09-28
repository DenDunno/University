
public static class GeometricAlgorithms
{
    public static bool IsLineIntersect(Edge edge1, Edge edge2)
    {
        float x1 = edge1.LeftPoint.X;
        float y1 = edge1.LeftPoint.Y;
        float x2 = edge1.RightPoint.X;
        float y2 = edge1.RightPoint.Y;
        float x3 = edge2.LeftPoint.X;
        float y3 = edge2.LeftPoint.Y;
        float x4 = edge2.RightPoint.X;
        float y4 = edge2.RightPoint.Y;

        float denominator = (y4 - y3) * (x1 - x2) - (x4 - x3) * (y1 - y2);
        
        if (denominator == 0 || IsChain(in edge1, in edge2))
        {
            return false;
        }

        float numeratorA = (x4 - x2) * (y4 - y3) - (x4 - x3) * (y4 - y2);
        float numeratorB = (x1 - x2) * (y4 - y2) - (x4 - x2) * (y1 - y2);
            
        float uA = numeratorA / denominator;
        float uB = numeratorB / denominator;

        return (uA is >= 0 and <= 1) && (uB is >= 0 and <= 1);
    }

    private static bool IsChain(in Edge edge1, in Edge edge2)
    {
        return IsPointEqual(in edge1.LeftPoint, in edge2.LeftPoint) ||
               IsPointEqual(in edge1.LeftPoint, in edge2.RightPoint) ||
               IsPointEqual(in edge1.RightPoint, in edge2.LeftPoint) ||
               IsPointEqual(in edge1.RightPoint, in edge2.RightPoint);
    }

    public static bool IsPointEqual(in Point point1, in Point point2)
    {
        return Math.Abs(point1.X - point2.X) < float.Epsilon && Math.Abs(point1.Y - point2.Y) < float.Epsilon;
    }
    
    public static bool IsEdgeEqual(in Edge edge1, in Edge edge2)
    {
        return IsPointEqual(in edge1.LeftPoint, in edge2.LeftPoint) 
               && IsPointEqual(in edge1.RightPoint, in edge2.RightPoint);
    }
}