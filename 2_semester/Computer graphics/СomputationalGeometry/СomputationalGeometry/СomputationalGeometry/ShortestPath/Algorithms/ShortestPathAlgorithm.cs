
public class ShortestPathAlgorithm
{
    private readonly VisibilityGraph _visibilityGraph;
    private DijkstraAlgorithm _dijkstraAlgorithm = null!;
    
    public ShortestPathAlgorithm(VisibilityGraph visibilityGraph)
    {
        _visibilityGraph = visibilityGraph;
    }
    
    public List<Point> Evaluate(KeyPoint start, KeyPoint destination)
    {
        Graph visibilityGraph = _visibilityGraph.Build(start.Point, destination.Point);
        _dijkstraAlgorithm = new DijkstraAlgorithm(visibilityGraph, start, destination);

        return _dijkstraAlgorithm.Evaluate();
    }
}