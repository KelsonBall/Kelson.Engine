using OpenTK.Graphics;
using OpenTK.Input;
using Processing.OpenTk.Core.Vectors;
using Processing.OpenTk.Core.Textures;
using System;
using TrueTypeSharp;
using System.Collections.Generic;

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
        ICanvas Background(double r, double g, double b, double a);

        ICanvas Triangle(PVector a, PVector b, PVector c);
        ICanvas Triangle(PVector3 a, PVector3 b, PVector3 c);

        ICanvas Rectangle(PVector position, PVector size);
        ICanvas Box(PVector3 position, double size);

        ICanvas Quad(PVector a, PVector b, PVector c, PVector d);
        ICanvas Quad(PVector3 a, PVector3 b, PVector3 c, PVector3 d);

        ICanvas Ellipse(PVector position, PVector size);
        ICanvas Ellipsoid(PVector3 position, PVector3 size);

        ICanvas Line(PVector a, PVector b);
        ICanvas Arc(PVector position, PVector size, double startAngle, double sweepAngle);
        ICanvas Line(PVector3 a, PVector3 b);

        ICanvas Image(Texture2d image, PVector position);
        ICanvas Image(Texture2d image, PVector3 position, PVector3 normal);

        ICanvas Text(string text, PVector position);
        ICanvas Text(string text, PVector3 position, PVector3 normal);

        ICanvas Shape(PVector position, params PVector[] points);
        ICanvas Shape(PVector3 position, params PVector3[] points);

        ICanvas Model(Model model, TextureMap map);
        ICanvas Model(Model model);
        ICanvas Model(Model model, Color4[] vertexColors);        

        ICanvas PushMatrix();
        ICanvas PopMatrix();

        ICanvas Translate(PVector translation);
        ICanvas Translate(PVector3 translation);

        ICanvas Rotate(double angle);
        ICanvas Rotate(PVector3 angles);
        ICanvas RotateX(double angle);
        ICanvas RotateY(double angle);
        ICanvas RotateZ(double angle);

        ICanvas Scale(double scale);
        ICanvas Scale(PVector3 scale);

        ICanvas Ortho();
        ICanvas Perspective();
        ICanvas LookAt(PVector3 from, PVector3 to, PVector3 up);

        ICanvas Font(Font font);
        ICanvas FontSize(double size);
        ICanvas Fill(Color4 fill);
        ICanvas Stroke(Color4 stroke);
        ICanvas StrokeWeight(double strokeWeight);

        ICanvas Title(string title);

        int MouseX { get; }
        int MouseY { get; }

        int Width { get; }
        int MidWidth { get; }

        int Height { get; }
        int MidHeight { get; }

        ICanvas IfKey(Key k, Action action);
        ICanvas IfButton(MouseButton b, Action action);
        ICanvas ForEachIn<T>(IEnumerable<T> collection, Action<T> action);

        double FrameTimeScalar { get; }
        ulong FrameCount { get; }
    }
}
