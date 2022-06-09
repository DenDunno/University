using OpenTK.Mathematics;

public class Graph : IDrawable
{
    private readonly List<Edge> _edges = new();
    private readonly List<Point> _vertices = new();

    public IReadOnlyList<Edge> Edges => _edges;
    public IReadOnlyList<Point> Vertices => _vertices;
    
    public void AddEdge(Edge edge)
    {
        TryAddVertex(edge.LeftPoint);
        TryAddVertex(edge.RightPoint);
        
        if (!_edges.Contains(edge) && !_edges.Contains(new Edge(edge.RightPoint, edge.LeftPoint)))
            _edges.Add(edge);
    }

    private void TryAddVertex(Point point)
    {
        if (_vertices.Contains(point) == false)
        {
            _vertices.Add(point);
        }
    }

    public void Draw()
    {
        foreach (Edge edge in _edges)
        {
            GlHelper.DrawLine(new List<Point>(){edge.LeftPoint, edge.RightPoint}, 0.01f, Color4.Yellow);
        }
    }
}