using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Processing.OpenTk.Core.Math;

namespace Processing.OpenTk.Core
{
    public class BaseCanvas : GameWindow
    {
        public int MidWidth => Width / 2;
        public int MidHeight => Height / 2;

        public BaseCanvas(int sizex, int sizey) : base(sizex, sizey, new GraphicsMode(32, 0, 0, 16))
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.CornflowerBlue);
            GL.Enable(EnableCap.DepthTest);            
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);            

            if (Keyboard[Key.Escape])
                Exit();
        }
        
        protected Action<FrameEventArgs> renderEvent;
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);                                              
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();            

            renderEvent?.Invoke(e);

            GL.Flush();
            SwapBuffers();
        }

        public PVector ToPixelCoordinate(PVector v) => (v.X * Width / 2, v.Y * Height / 2);

        public PVector ToScalarCoordinate(PVector v) => ((v.X - MidWidth) / MidWidth, -(v.Y - MidHeight) / MidHeight);
    }
}
