using System.Collections.ObjectModel;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class Commands
{
    private readonly ReadOnlyCollection<Command> _commands;

    public Commands(List<Command> commands)
    {
        _commands = new ReadOnlyCollection<Command>(commands);
    }

    public void TryInvokeCommand(KeyboardState keyboardState)
    {
        foreach (Command command in _commands)
        {
            if (keyboardState.IsKeyDown(command.Key))
            {
                command.Action();
            }
        }
    }
}