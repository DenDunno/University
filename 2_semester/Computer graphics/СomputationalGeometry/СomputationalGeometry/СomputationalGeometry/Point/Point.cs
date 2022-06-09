using Newtonsoft.Json;

public struct Point
{
    public readonly float X;
    public readonly float Y;
    
    [JsonConstructor]
    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }
}