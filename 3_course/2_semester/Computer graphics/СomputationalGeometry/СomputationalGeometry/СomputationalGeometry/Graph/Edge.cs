
public readonly struct Edge
{
    public readonly Point LeftPoint;
    public readonly Point RightPoint;
    public float Magnitude => MathF.Sqrt(MathF.Pow(LeftPoint.X - RightPoint.X, 2) + MathF.Pow(LeftPoint.Y - RightPoint.Y, 2));
    public Point MiddlePoint => new((LeftPoint.X + RightPoint.X) / 2, (LeftPoint.Y + RightPoint.Y) / 2);

    public Edge(Point leftPoint, Point rightPoint)
    {
        LeftPoint = leftPoint;
        RightPoint = rightPoint;
    }
}