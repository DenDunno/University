using OpenTK.Mathematics;

public class ShortestPath : IDrawable, IUpdatable
{
    private readonly KeyPoint _start;
    private readonly KeyPoint _destination;
    private readonly ShortestPathAlgorithm _shortestPathAlgorithm;
    private List<Point> _pathPoints = new();

    public ShortestPath(KeyPoint startPoint, KeyPoint destinationPoint, VisibilityGraph visibilityGraph)
    {
        _start = startPoint;
        _destination = destinationPoint;
        _shortestPathAlgorithm = new ShortestPathAlgorithm(visibilityGraph);
    }

    void IUpdatable.Update(float deltaTime)
    {
        _pathPoints = _shortestPathAlgorithm.Evaluate(_start, _destination);
    }
    
    void IDrawable.Draw()
    {
        DrawPathLine(_pathPoints);
        DrawKeyCircles();
    }

    private void DrawKeyCircles()
    {
        GlHelper.DrawCircle(_start.Point, 0.1f, Color4.Lime);
        GlHelper.DrawCircle(_destination.Point, 0.1f, Color4.Lime);
    }

    private void DrawPathLine(List<Point> pathPoints)
    {
        var path = new List<Point>(pathPoints);
        path.Insert(0, _start.Point);
        path.Add(_destination.Point);
        
        GlHelper.DrawLine(path, 3f, Color4.Aqua);
    }
}