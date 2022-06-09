
public class UpdateCycle
{
    private readonly Window _window;
    private readonly IUpdatable[] _updatables;

    public UpdateCycle(Window window, IUpdatable[] updatables)
    {
        _window = window;
        _updatables = updatables;
    }

    public void Run()
    {
        _window.FrameRendering += Update;
    }

    private void Update(float deltaTime)
    {
        _updatables.ForEach(updatable => updatable.Update(deltaTime));
    }
}