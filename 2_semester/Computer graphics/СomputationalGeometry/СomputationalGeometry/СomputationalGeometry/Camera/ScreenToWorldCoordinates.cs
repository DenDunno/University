using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class ScreenToWorldCoordinates
{
    public Point Evaluate(float x, float y)
    {
        int[] viewport = new int[4];
        GL.GetFloat(GetPName.ModelviewMatrix, out Matrix4 modelViewMatrix);
        GL.GetFloat(GetPName.ProjectionMatrix, out Matrix4 projectionMatrix);
        GL.GetInteger(GetPName.Viewport, viewport);
        
        modelViewMatrix[1,3] = -modelViewMatrix[1,3];
        
        var mouse = new Vector2(x, viewport[3] - y);

        return UnProject(ref projectionMatrix, modelViewMatrix, new Size(viewport[2], viewport[3]), mouse);
    }
    
    private Point UnProject(ref Matrix4 projection, Matrix4 view, Size viewport, Vector2 mouse)
    {
        Vector4 vector;

        vector.X = 2.0f * mouse.X / viewport.Width - 1;
        vector.Y = (2.0f * mouse.Y / viewport.Height - 1);
        vector.Z = 0;
        vector.W = 1.0f;

        Matrix4 viewInv = Matrix4.Invert(view);
        Matrix4 projInv = Matrix4.Invert(projection);

        Vector4.TransformRow(in vector, in projInv, out vector);
        Vector4.TransformRow(in vector, in viewInv, out vector);

        if (vector.W > float.Epsilon || vector.W < float.Epsilon)
        {
            vector.X /= vector.W;
            vector.Y /= vector.W;
            vector.Z /= vector.W;
        }

        return new Point(vector.X, vector.Y);
    }
}