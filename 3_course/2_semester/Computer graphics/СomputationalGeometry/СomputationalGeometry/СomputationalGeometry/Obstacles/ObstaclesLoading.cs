
public class ObstaclesLoading
{
    private readonly ObstacleParser _obstacleParser;
    private readonly Obstacles _obstacles;

    public ObstaclesLoading(Obstacles obstacles)
    {
        _obstacleParser = new ObstacleParser("obstacles.json");
        _obstacles = obstacles;
    }

    public void Load()
    {
        _obstacles.SetObstacles(_obstacleParser.Parse());
    }
}