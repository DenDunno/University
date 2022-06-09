using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class KeyPoint : IUpdatable
{
    private readonly MouseState _mouseState;
    private readonly ScreenToWorldCoordinates _screenToWorldCoordinates = new();
    private readonly float _radius = 0.1f;
    private bool _selected;
    
    public KeyPoint(float x, float y, MouseState mouseState)
    {
        Point = new Point(x, y);
        _mouseState = mouseState;
    }

    public Point Point { get; private set; }

    void IUpdatable.Update(float deltaTime)
    {
        if (_mouseState.IsButtonDown(MouseButton.Button1))
        {
            Point screenToWorldPoint = _screenToWorldCoordinates.Evaluate(_mouseState.X, _mouseState.Y);
            
            if (_selected || CheckSelection(screenToWorldPoint))
            {
                _selected = true;
                Point = screenToWorldPoint;
            }
        }
        else
        {
            _selected = false;
        }
    }

    private bool CheckSelection(Point point)
    {
        var difference = new Vector2(point.X - Point.X, point.Y - Point.Y);
        
        return difference.Length < _radius;
    }
}