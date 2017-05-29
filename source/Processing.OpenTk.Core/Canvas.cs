using Processing.OpenTk.Core.Rendering;
using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Processing.OpenTk.Core.Vectors;
using Processing.OpenTk.Core.Textures;
using OpenTK;
using OpenTK.Input;
using System.Collections.Generic;

namespace Processing.OpenTk.Core
{
    public class Canvas : BaseCanvas, ICanvas
    {
        public double FrameTimeScalar { get; private set; }
        public new ulong FrameCount { get => base.FrameCount; }

        public event Action<ICanvas> Draw
        {
            add => renderEvent += e =>
            {
                FrameTimeScalar = e.Time / RenderPeriod;
                value.Invoke(this);
            };
            remove => throw new InvalidOperationException(); 
        }

        public event Action<ICanvas> Setup {
            add => loadEvent += e => value.Invoke(this);
            remove => throw new InvalidOperationException();
        }

        public event Action<KeyboardKeyEventArgs> KeyDown { add => throw new NotImplementedException(); remove => throw new NotImplementedException(); }

        public event Action<KeyboardKeyEventArgs> KeyUp { add => throw new NotImplementedException(); remove => throw new NotImplementedException(); }

        public event Action<MouseButtonEventArgs> MouseButtonDown { add => throw new NotImplementedException(); remove => throw new NotImplementedException(); }

        public event Action<MouseButtonEventArgs> MouseButtonUp { add => throw new NotImplementedException(); remove => throw new NotImplementedException(); }

        public event Action<MouseMoveEventArgs> MouseMoved { add => throw new NotImplementedException(); remove => throw new NotImplementedException(); }

        public FrameEventArgs Frame;

        public Canvas(int sizex, int sizey) : this(sizex, sizey, "OpenTk Window")
        {

        }

        public Canvas(int sizex, int sizey, string title) : base(sizex, sizey)
        {
            base.Title = title;
            base.renderEvent -= e => Frame = e;    
            
        }

        public Style Style { get; } = new Style();

        public ICanvas Background(Color4 color)
        {
            GL.ClearColor(color);
            return this;
        }

        public ICanvas Background(double r, double g, double b, double a = 1f)
        {
            GL.ClearColor((float)r, (float)g, (float)b, (float)a);
            return this;
        }

        public ICanvas Triangle(PVector a, PVector b, PVector c)
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Style.Fill);

            GL.Vertex2(a);
            GL.Vertex2(b);
            GL.Vertex2(c);

            GL.End();
            return this;
        }

        public ICanvas Triangle(PVector3 a, PVector3 b, PVector3 c)
        {
            GL.Color4(Style.Fill);
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(a);
            GL.Vertex3(b);
            GL.Vertex3(c);            
            GL.End();
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(b);
            GL.Vertex3(a);
            GL.Vertex3(c);
            GL.End();
            return this;
        }

        public ICanvas Rectangle(PVector position, PVector size)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Style.Fill);

            GL.Vertex2(position.X, position.Y);
            GL.Vertex2(position.X + size.X, position.Y);
            GL.Vertex2(position.X + size.X, position.Y - size.Y);
            GL.Vertex2(position.X, position.Y - size.Y);

            GL.End();
            return this;
        }

        public ICanvas Box(PVector3 p, double size)
        {
            Color4 color = Style.Fill;

            var s = size / 2;
            float i = (float)size;
            float o = 0;

            PushMatrix()
                .Translate((p.X - s, p.Y - s, p.Z - s))
                .Fill(Color4.Black)
                    .Triangle((o, o, o), (i, o, o), (i, o, i))
                    .Triangle((o, o, o), (o, o, i), (i, o, i))
                .Fill(Color4.Green)
                    .Triangle((o, o, o), (o, i, o), (o, i, i))
                    .Triangle((o, o, o), (o, o, i), (o, i, i))
                .Fill(Color4.Red)
                    .Triangle((o, o, o), (i, o, o), (i, i, o))
                    .Triangle((o, o, o), (o, i, o), (i, i, o))
                .Fill(Color4.Blue)
                    .Triangle((i, o, i), (i, o, o), (i, i, o))
                    .Triangle((i, o, i), (i, i, i), (i, i, o))            
                .Fill(Color4.Orange)
                    .Triangle((i, o, i), (o, o, i), (o, i, i))
                    .Triangle((i, o, i), (o, i, i), (i, i, i))
                .Fill(Color4.Yellow)
                    .Triangle((i, i, i), (o, i, i), (o, i, o))
                    .Triangle((i, i, i), (i, i, o), (o, i, o))
                .PopMatrix();

            Fill(color);
            return this;
        }

        public ICanvas Quad(PVector a, PVector b, PVector c, PVector d)
        {
            throw new NotImplementedException();
        }

        public ICanvas Quad(PVector3 a, PVector3 b, PVector3 c, PVector3 d)
        {
            throw new NotImplementedException();
        }

        public ICanvas Ellipse(PVector position, PVector size)
        {
            throw new NotImplementedException();
        }

        public ICanvas Ellipsoid(PVector3 position, PVector3 size)
        {
            throw new NotImplementedException();
        }

        public ICanvas Line(PVector a, PVector b)
        {
            throw new NotImplementedException();
        }

        public ICanvas Arc(PVector position, PVector size, double startAngle, double sweepAngle)
        {
            throw new NotImplementedException();
        }

        public ICanvas Line(PVector3 a, PVector3 b)
        {
            throw new NotImplementedException();
        }

        public ICanvas Image(Texture2d image, PVector position)
        {
            throw new NotImplementedException();
        }

        public ICanvas Image(Texture2d image, PVector3 position, PVector3 normal)
        {
            throw new NotImplementedException();
        }

        public ICanvas Text(string text, PVector position)
        {
            throw new NotImplementedException();
        }

        public ICanvas Text(string text, PVector3 position, PVector3 normal)
        {
            throw new NotImplementedException();
        }

        public ICanvas Shape(PVector position, params PVector[] points)
        {
            throw new NotImplementedException();
        }

        public ICanvas Shape(PVector3 position, params PVector3[] points)
        {
            throw new NotImplementedException();
        }

        public ICanvas Model(Model model, TextureMap map)
        {
            throw new NotImplementedException();
        }

        public ICanvas Model(Model model)
        {
            var s = model.Scale / -2;
            return PushMatrix()                    
                    .Rotate(model.Rotation)
                    .Translate(s)
                    .Scale(model.Scale)
                    .ForEachIn(model.Triangles,
                        t => Triangle(model[t,0], model[t,1], model[t,2]))
                    .PopMatrix();
        }

        public ICanvas Model(Model model, Color4[] vertexColors)
        {
            throw new NotImplementedException();
        }

        public ICanvas Translate(PVector translation)
        {
            GL.Translate(translation.X, translation.Y, 0);
            return this;
        }

        public ICanvas Translate(PVector3 translation)
        {
            GL.Translate(translation);
            return this;
        }

        public ICanvas Rotate(double angle)
        {
            GL.Rotate((float)angle, Vector3.UnitZ);
            return this;
        }

        public ICanvas Rotate(PVector3 angles)
        {
            return RotateX(angles.X)
                  .RotateY(angles.Y)
                  .RotateZ(angles.Z);
        }

        public ICanvas RotateX(double angle)
        {
            GL.Rotate((float)angle, Vector3.UnitX);
            return this;
        }

        public ICanvas RotateZ(double angle)
        {
            return Rotate(angle);
        }

        public ICanvas RotateY(double angle)
        {
            GL.Rotate((float)angle, Vector3.UnitY);
            return this;
        }

        public ICanvas PushMatrix()
        {
            GL.PushMatrix();
            return this;
        }

        public ICanvas PopMatrix()
        {
            GL.PopMatrix();
            return this;
        }

        public ICanvas Ortho()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            return this;
        }

        public ICanvas Perspective()
        {
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);            
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            return this;
        }

        public ICanvas LookAt(PVector3 from, PVector3 to, PVector3 up)
        {
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            projection *= Matrix4.LookAt(from, to, up);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            return this;
        }

        public ICanvas Font(Font font)
        {
            throw new NotImplementedException();
        }

        public ICanvas FontSize(double size)
        {
            throw new NotImplementedException();
        }

        public ICanvas Fill(Color4 fill)
        {
            Style.Fill = fill;
            return this;
        }

        public ICanvas Stroke(Color4 stroke)
        {
            Style.Stroke = stroke;
            return this;
        }

        public ICanvas StrokeWeight(double strokeWeight)
        {
            throw new NotImplementedException();
        }

        public new ICanvas Title(string title)
        {
            base.Title = title;
            return this;
        }

        public ICanvas IfKey(Key k, Action action)
        {
            if (Keyboard[k])
                action();
            return this;
        }

        public ICanvas IfButton(MouseButton b, Action action)
        {
            if (Mouse[b])
                action();
            return this;
        }

        public ICanvas ForEachIn<T>(IEnumerable<T> collection, Action<T> action)
        {
            foreach (var t in collection)
                action(t);
            return this;
        }

        public ICanvas Scale(double scale)
        {
            GL.Scale(new PVector3(scale, scale, scale));
            return this;
        }

        public ICanvas Scale(PVector3 scale)
        {
            GL.Scale(scale);
            return this;
        }

        public int MouseX { get => Mouse.X; }
        public int MouseY { get => Mouse.Y; }

        public new int Width { get => base.Width; }
        public new int MidWidth { get => base.MidWidth; }

        public new int Height { get => base.Height; }
        public new int MidHeight { get => base.MidHeight; }
    }
}
