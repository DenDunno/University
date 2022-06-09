using Newtonsoft.Json;

public class ObstacleParser
{
    private readonly string _path;

    public ObstacleParser(string path)
    {
        _path = path;
    }

    public List<List<Point>> Parse()
    {
        return JsonConvert.DeserializeObject<List<List<Point>>>(File.ReadAllText(_path))!;
    }
}