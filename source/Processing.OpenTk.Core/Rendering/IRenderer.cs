using OpenTK.Graphics;
using Processing.OpenTk.Core.Math;
using Processing.OpenTk.Core.Textures;

namespace Processing.OpenTk.Core.Rendering
{
    public interface IRenderer
    {
        Style Style { get; }

        IRenderer Background(Color4 color);
        IRenderer Background(float r, float g, float b, float a);

        IRenderer Triangle(PVector a, PVector b, PVector c);
        IRenderer Triangle(PVector3 a, PVector3 b, PVector3 c);

        IRenderer Rectangle(PVector position, PVector size);
        IRenderer Box(PVector3 position, PVector3 size);

        IRenderer Quad(PVector a, PVector b, PVector c, PVector d);
        IRenderer Quad(PVector3 a, PVector3 b, PVector3 c, PVector3 d);

        IRenderer Ellipse(PVector position, PVector size);
        IRenderer Ellipsoid(PVector3 position, PVector3 size);

        IRenderer Line(PVector a, PVector b);
        IRenderer Arc(PVector position, PVector size, float startAngle, float sweepAngle);
        IRenderer Line(PVector3 a, PVector3 b);

        IRenderer Image(Texture2d image, PVector position);
        IRenderer Image(Texture2d image, PVector3 position, PVector3 normal);

        IRenderer Text(string text, PVector position);
        IRenderer Text(string text, PVector3 position, PVector3 normal);

        IRenderer Shape(PVector position, params PVector[] points);
        IRenderer Shape(PVector3 position, params PVector3[] points);

        IRenderer Model(PVector3 position, Model model, TextureMap map);
        IRenderer Model(PVector3 position, Model model, Color4 color);
        IRenderer Model(PVector3 position, Model model, Color4[] vertexColors);

        IRenderer Translate(PVector translation);
        IRenderer Translate(PVector3 translation);

        IRenderer Rotate(float angle);
        IRenderer RotateX(float angle);
        IRenderer RotateY(float angle);
        IRenderer RotateZ(float angle);

        IRenderer PushMatrix();
        IRenderer PopMatrix();
    }
}
