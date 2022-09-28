using OpenTK.Windowing.GraphicsLibraryFramework;

public class KeyboardInput : IUpdatable
{
    private readonly KeyboardState _keyboardState;
    private readonly Commands _commands;
    private bool _isAnyKeyDown;
    
    public KeyboardInput(KeyboardState keyboardState, Commands commands)
    {
        _keyboardState = keyboardState;
        _commands = commands;
    }
    
    void IUpdatable.Update(float deltaTime)
    {
        if (_isAnyKeyDown == false)
        {
            _commands.TryInvokeCommand(_keyboardState);
        }

        _isAnyKeyDown = _keyboardState.IsAnyKeyDown;
    }
}