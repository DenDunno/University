
public class VisibilityGraph : IDrawable
{
    private readonly Obstacles _obstacles;
    private Graph _graph = new();
    
    public VisibilityGraph(Obstacles obstacles)
    {
        _obstacles = obstacles;
    }

    public Graph Build(Point start, Point destination)
    {
        _graph = new Graph();
        var allPoints = GetAllPoints(start, destination);
        
        foreach (Point point1 in allPoints)
        {
            foreach (Point point2 in allPoints)
            {
                if (GeometricAlgorithms.IsPointEqual(in point1, in point2))
                    continue;
                
                var visibleEdge = new Edge(point1, point2);
                bool isVisible = true;

                for (int i = 0; i < _obstacles.Value.Count && isVisible; ++i)
                {
                    isVisible = !_obstacles.Value[i].IsInside(in visibleEdge);
                    
                    for (int j = 0; j < _obstacles.Value[i].Edges.Count && isVisible; ++j)
                    {
                        isVisible = !GeometricAlgorithms.IsLineIntersect(_obstacles.Value[i].Edges[j], visibleEdge);
                    }
                }

                if (isVisible)
                {
                    _graph.AddEdge(visibleEdge);
                }
            }   
        }

        return _graph;
    }

    private IEnumerable<Point> GetAllPoints(Point start, Point destination)
    {
        var allPoints = new List<Point>();
        foreach (Obstacle obstacle in _obstacles.Value)
        {
            allPoints.AddRange(obstacle.Points);
        }
        allPoints.Add(start);
        allPoints.Add(destination);

        return allPoints;
    }

    void IDrawable.Draw()
    {
        _graph.Draw();
    }
}