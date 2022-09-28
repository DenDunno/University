using OpenTK.Windowing.GraphicsLibraryFramework;

public class Command
{
    public readonly Keys Key;
    public readonly Action Action;

    public Command(Keys key, Action action)
    {
        Key = key;
        Action = action;
    }
}