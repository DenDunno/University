using System.Collections.ObjectModel;

public class Renderer : IUpdatable
{
    private readonly ReadOnlyCollection<IDrawable> _drawables;

    public Renderer(IDrawable[] drawables)
    {
        _drawables = new ReadOnlyCollection<IDrawable>(drawables);
    }

    void IUpdatable.Update(float deltaTime)
    {
        Draw();
    }

    private void Draw()
    {
        _drawables.ForEach(drawable => drawable.Draw());
    }
}