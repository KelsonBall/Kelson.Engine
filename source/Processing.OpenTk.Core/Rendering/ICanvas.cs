using OpenTK.Graphics;
using OpenTK.Input;
using Processing.OpenTk.Core.Math;
using Processing.OpenTk.Core.Textures;
using System;

namespace Processing.OpenTk.Core.Rendering
{
    public interface ICanvas
    {
        event Action<ICanvas> Draw;
        event Action<ICanvas> Setup;
        event Action<KeyboardKeyEventArgs> KeyDown;
        event Action<KeyboardKeyEventArgs> KeyUp;
        event Action<MouseButtonEventArgs> MouseButtonDown;
        event Action<MouseButtonEventArgs> MouseButtonUp;
        event Action<MouseMoveEventArgs> MouseMoved;

        Style Style { get; }

        ICanvas Background(Color4 color);
        ICanvas Background(float r, float g, float b, float a);

        ICanvas Triangle(PVector a, PVector b, PVector c);
        ICanvas Triangle(PVector3 a, PVector3 b, PVector3 c);

        ICanvas Rectangle(PVector position, PVector size);
        ICanvas Box(PVector3 position, PVector3 size);

        ICanvas Quad(PVector a, PVector b, PVector c, PVector d);
        ICanvas Quad(PVector3 a, PVector3 b, PVector3 c, PVector3 d);

        ICanvas Ellipse(PVector position, PVector size);
        ICanvas Ellipsoid(PVector3 position, PVector3 size);

        ICanvas Line(PVector a, PVector b);
        ICanvas Arc(PVector position, PVector size, float startAngle, float sweepAngle);
        ICanvas Line(PVector3 a, PVector3 b);

        ICanvas Image(Texture2d image, PVector position);
        ICanvas Image(Texture2d image, PVector3 position, PVector3 normal);

        ICanvas Text(string text, PVector position);
        ICanvas Text(string text, PVector3 position, PVector3 normal);

        ICanvas Shape(PVector position, params PVector[] points);
        ICanvas Shape(PVector3 position, params PVector3[] points);

        ICanvas Model(PVector3 position, Model model, TextureMap map);
        ICanvas Model(PVector3 position, Model model, Color4 color);
        ICanvas Model(PVector3 position, Model model, Color4[] vertexColors);

        ICanvas Translate(PVector translation);
        ICanvas Translate(PVector3 translation);

        ICanvas Rotate(float angle);
        ICanvas RotateX(float angle);
        ICanvas RotateY(float angle);
        ICanvas RotateZ(float angle);

        ICanvas PushMatrix();
        ICanvas PopMatrix();
    }
}
