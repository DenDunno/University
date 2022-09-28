using System.Drawing;
using OpenTK.Graphics.OpenGL;

public class Obstacle : IDrawable
{
    private readonly List<Point> _points;
    private readonly List<Edge> _edges = new();

    public Obstacle(List<Point> points)
    {
        _points = points;
        ConnectEdges();
    }

    public IReadOnlyList<Point> Points => _points;
    public IReadOnlyList<Edge> Edges => _edges;
    
    private void ConnectEdges()
    {
        for (int i = 0; i < _points.Count - 1; ++i)
        {
            _edges.Add(new Edge(_points[i], _points[i + 1]));
        }
            
        _edges.Add(new Edge(_points.Last(), _points.First()));
    }

    void IDrawable.Draw()
    {
        GL.Begin(PrimitiveType.Polygon);
        GL.Color3(Color.Red);
            
        foreach (Point point in _points)    
        {
            GL.Vertex2(point.X, point.Y);
        }
            
        GL.End();
    }

    public bool IsInside(in Edge visibilityEdge)
    {
        foreach (Edge obstacleEdge in _edges)
        {
            if (GeometricAlgorithms.IsEdgeEqual(obstacleEdge, visibilityEdge))
            {
                return false;
            }
        }

        var midPoint = visibilityEdge.MiddlePoint;
        const float xRaycastOffset = 100;
        const float yRaycastOffset = 1;
        var raycastEdge = new Edge(midPoint, new Point(midPoint.X + xRaycastOffset, midPoint.Y + yRaycastOffset));
        int intersections = 0;
        
        foreach (Edge edge in _edges)
        {
            if (GeometricAlgorithms.IsLineIntersect(edge, raycastEdge))
            {
                intersections++;
            }
        }

        return intersections % 2 != 0;
    }
}