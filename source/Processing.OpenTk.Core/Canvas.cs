using Processing.OpenTk.Core.Rendering;
using System;
using System.Collections.Generic;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Processing.OpenTk.Core.Math;
using Processing.OpenTk.Core.Textures;
using OpenTK;

namespace Processing.OpenTk.Core
{
    public class Canvas : BaseCanvas, IRenderer
    {
        public event Action<Canvas> Draw
        {
            add => renderEvent += e => value.Invoke(this); 
            remove => throw new InvalidOperationException(); 
        }

        public Action<Canvas> Setup { get; set; }

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

        public IRenderer Background(Color4 color)
        {
            GL.ClearColor(color);
            return this;
        }

        public IRenderer Background(float r, float g, float b, float a = 1f)
        {
            GL.ClearColor(r, g, b, a);
            return this;
        }

        public IRenderer Triangle(PVector a, PVector b, PVector c)
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Style.Fill);

            GL.Vertex2(a);
            GL.Vertex2(b);
            GL.Vertex2(c);

            GL.End();
            return this;
        }

        public IRenderer Triangle(PVector3 a, PVector3 b, PVector3 c)
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Style.Fill);

            GL.Vertex3(a);
            GL.Vertex3(b);
            GL.Vertex3(c);

            GL.End();
            return this;
        }

        public IRenderer Rectangle(PVector position, PVector size)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Style.Fill);

            GL.Vertex2(position.X, position.Y);
            GL.Vertex2(position.X + size.X, position.Y);
            GL.Vertex2(position.X + size.X, position.Y + size.Y);
            GL.Vertex2(position.X, position.Y + size.Y);

            GL.End();
            return this;
        }

        public IRenderer Box(PVector3 position, PVector3 size)
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

        public IRenderer Quad(PVector a, PVector b, PVector c, PVector d)
        {
            throw new NotImplementedException();
        }

        public IRenderer Quad(PVector3 a, PVector3 b, PVector3 c, PVector3 d)
        {
            throw new NotImplementedException();
        }

        public IRenderer Ellipse(PVector position, PVector size)
        {
            throw new NotImplementedException();
        }

        public IRenderer Ellipsoid(PVector3 position, PVector3 size)
        {
            throw new NotImplementedException();
        }

        public IRenderer Line(PVector a, PVector b)
        {
            throw new NotImplementedException();
        }

        public IRenderer Arc(PVector position, PVector size, float startAngle, float sweepAngle)
        {
            throw new NotImplementedException();
        }

        public IRenderer Line(PVector3 a, PVector3 b)
        {
            throw new NotImplementedException();
        }

        public IRenderer Image(Texture2d image, PVector position)
        {
            throw new NotImplementedException();
        }

        public IRenderer Image(Texture2d image, PVector3 position, PVector3 normal)
        {
            throw new NotImplementedException();
        }

        public IRenderer Text(string text, PVector position)
        {
            throw new NotImplementedException();
        }

        public IRenderer Text(string text, PVector3 position, PVector3 normal)
        {
            throw new NotImplementedException();
        }

        public IRenderer Shape(PVector position, params PVector[] points)
        {
            throw new NotImplementedException();
        }

        public IRenderer Shape(PVector3 position, params PVector3[] points)
        {
            throw new NotImplementedException();
        }

        public IRenderer Model(PVector3 position, Model model, TextureMap map)
        {
            throw new NotImplementedException();
        }

        public IRenderer Model(PVector3 position, Model model, Color4 color)
        {
            throw new NotImplementedException();
        }

        public IRenderer Model(PVector3 position, Model model, Color4[] vertexColors)
        {
            throw new NotImplementedException();
        }

        public IRenderer Translate(PVector translation)
        {
            GL.Translate(translation.X, translation.Y, 0);
            return this;
        }

        public IRenderer Translate(PVector3 translation)
        {
            GL.Translate(translation);
            return this;
        }

        public IRenderer Rotate(float angle)
        {
            GL.Rotate(angle, Vector3.UnitZ);
            return this;
        }

        public IRenderer RotateX(float angle)
        {
            GL.Rotate(angle, Vector3.UnitX);
            return this;
        }

        public IRenderer RotateZ(float angle)
        {
            return Rotate(angle);
        }

        public IRenderer RotateY(float angle)
        {
            GL.Rotate(angle, Vector3.UnitY);
            return this;
        }

        public IRenderer PushMatrix()
        {
            GL.PushMatrix();
            return this;
        }

        public IRenderer PopMatrix()
        {
            GL.PopMatrix();
            return this;
        }
    }
}
