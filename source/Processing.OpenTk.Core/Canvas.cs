using Processing.OpenTk.Core.Rendering;
using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Processing.OpenTk.Core.Math;
using Processing.OpenTk.Core.Textures;
using OpenTK;
using OpenTK.Input;

namespace Processing.OpenTk.Core
{
    public class Canvas : BaseCanvas, ICanvas
    {
        public event Action<ICanvas> Draw
        {
            add => renderEvent += e => value.Invoke(this); 
            remove => throw new InvalidOperationException(); 
        }

        public event Action<ICanvas> Setup { add => throw new NotImplementedException(); remove => throw new NotImplementedException(); }

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
            Title = title;
            base.renderEvent -= e => Frame = e;    
            
        }

        public Style Style { get; } = new Style();

        public ICanvas Background(Color4 color)
        {
            GL.ClearColor(color);
            return this;
        }

        public ICanvas Background(float r, float g, float b, float a = 1f)
        {
            GL.ClearColor(r, g, b, a);
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
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Style.Fill);

            GL.Vertex3(a);
            GL.Vertex3(b);
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

        public ICanvas Box(PVector3 position, PVector3 size)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Style.Fill);

            GL.Vertex3(position.X, position.Y, position.Z);
            GL.Vertex3(position.X - size.X, position.Y, position.Z);
            GL.Vertex3(position.X - size.X, position.Y - size.Y, position.Z);
            GL.Vertex3(position.X, position.Y - size.Y, position.Z);

            GL.Vertex3(position.X, position.Y, position.Z);
            GL.Vertex3(position.X - size.X, position.Y, position.Z);
            GL.Vertex3(position.X - size.X, position.Y - size.Y, position.Z);
            GL.Vertex3(position.X, position.Y - size.Y, position.Z);

            GL.Vertex3(position.X, position.Y, position.Z);
            GL.Vertex3(position.X, position.Y, position.Z - size.Z);
            GL.Vertex3(position.X, position.Y - size.Y, position.Z - size.Z);
            GL.Vertex3(position.X, position.Y - size.Y, position.Z);

            GL.Vertex3(position.X, position.Y, position.Z);
            GL.Vertex3(position.X, position.Y, position.Z - size.Z);
            GL.Vertex3(position.X, position.Y - size.Y, position.Z - size.Z);
            GL.Vertex3(position.X, position.Y - size.Y, position.Z);

            GL.Vertex3(position.X, position.Y, position.Z);
            GL.Vertex3(position.X - size.X, position.Y, position.Z);
            GL.Vertex3(position.X - size.X, position.Y, position.Z - position.Z);
            GL.Vertex3(position.X, position.Y, position.Z - position.Z);

            GL.Vertex3(position.X, position.Y, position.Z);
            GL.Vertex3(position.X - size.X, position.Y, position.Z);
            GL.Vertex3(position.X - size.X, position.Y, position.Z - position.Z);
            GL.Vertex3(position.X, position.Y, position.Z - position.Z);

            GL.End();
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

        public ICanvas Arc(PVector position, PVector size, float startAngle, float sweepAngle)
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

        public ICanvas Model(PVector3 position, Model model, TextureMap map)
        {
            throw new NotImplementedException();
        }

        public ICanvas Model(PVector3 position, Model model, Color4 color)
        {
            throw new NotImplementedException();
        }

        public ICanvas Model(PVector3 position, Model model, Color4[] vertexColors)
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

        public ICanvas Rotate(float angle)
        {
            GL.Rotate(angle, Vector3.UnitZ);
            return this;
        }

        public ICanvas RotateX(float angle)
        {
            GL.Rotate(angle, Vector3.UnitX);
            return this;
        }

        public ICanvas RotateZ(float angle)
        {
            return Rotate(angle);
        }

        public ICanvas RotateY(float angle)
        {
            GL.Rotate(angle, Vector3.UnitY);
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
    }
}
