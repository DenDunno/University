using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public static class GlHelper
{
    public static void DrawCircle(Point point, float radius, Color4 color)
    {
        GL.Enable(EnableCap.Blend);
        GL.Begin(PrimitiveType.TriangleFan);
        GL.Color4(color);

        GL.Vertex2(point.X, point.Y);
        for (int i = 0; i < 360; i++)
        {
            GL.Vertex2(point.X + Math.Cos(i) * radius, point.Y + Math.Sin(i) * radius);
        }

        GL.End();
        GL.Disable(EnableCap.Blend);
    }
    
    public static void DrawLine(List<Point> points, float width, Color4 color)
    {
        GL.Enable(EnableCap.Blend);
        GL.Color4(color);
        GL.LineWidth(width);
        GL.Begin(PrimitiveType.LineStrip);

        foreach (Point point in points)
        {
            GL.Vertex2(point.X, point.Y);
        }

        GL.End();
        GL.Disable(EnableCap.Blend);
    }
}