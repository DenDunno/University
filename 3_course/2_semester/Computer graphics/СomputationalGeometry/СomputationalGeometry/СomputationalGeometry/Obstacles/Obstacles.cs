
public class Obstacles : IDrawable
{
    private readonly List<Obstacle> _obstacles = new();
    public IReadOnlyList<Obstacle> Value => _obstacles;

    public void SetObstacles(List<List<Point>> obstacles)
    {
        _obstacles.Clear();

        foreach (List<Point> obstaclePoints in obstacles)
        {
            _obstacles.Add(new Obstacle(obstaclePoints));
        }
    }

    void IDrawable.Draw()
    {
        foreach (IDrawable obstacle in _obstacles)
        {
            obstacle.Draw();
        }
    }
}