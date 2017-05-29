using System;
using Processing.OpenTk.Core;
using OpenTK.Input;
using OpenTK.Graphics;
using Processing.OpenTk.Core.Rendering;
using Processing.OpenTk.Core.Vectors;
using Processing.OpenTk.Core.Extensions;

namespace Processing.OpenTk.Runner
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (Canvas canvas = new Canvas(800, 600, "Example"))
            {
                canvas.Setup += Setup;
                canvas.Draw += Draw;
                canvas.Run(30f);
            }
        }
        
        static PVector offset = (0, 0);
        static readonly double rotationSpeed = 0.075;
        static readonly double moveSpeed = 0.005;
        static Model cube = Shapes.Cube();

        static void Setup(ICanvas c)
        {
            cube.Scale = (0.5, 2, 0.5);
        }

        static void Draw(ICanvas c)
        {
            c.Perspective()
             .IfKey(Key.Up, () => cube.Rotation -= PVector3.î * rotationSpeed * c.FrameTimeScalar)
             .IfKey(Key.Down, () => cube.Rotation += PVector3.î * rotationSpeed * c.FrameTimeScalar)
             .IfKey(Key.Left, () => cube.Rotation -= PVector3.ĵ * rotationSpeed * c.FrameTimeScalar)
             .IfKey(Key.Right, () => cube.Rotation += PVector3.ĵ * rotationSpeed * c.FrameTimeScalar)
             .IfKey(Key.A, () => offset -= PVector.î * moveSpeed * c.FrameTimeScalar)
             .IfKey(Key.D, () => offset += PVector.î * moveSpeed * c.FrameTimeScalar)
             .IfKey(Key.W, () => offset += PVector.ĵ * moveSpeed * c.FrameTimeScalar)
             .IfKey(Key.S, () => offset -= PVector.ĵ * moveSpeed * c.FrameTimeScalar)
             .Background(Color4.White)
             .Fill(Color4.Gray.WithAlpha(0.3))
             .PushMatrix()
             .Translate((offset.X, offset.Y, -6))
             .Model(cube)
             .PopMatrix();

            if (c.FrameCount % 300 == 0)
            {
                var scalar = $"{c.FrameTimeScalar}.000";
                c.Title(scalar.Substring(0, scalar.IndexOf('.') + 4));
            }
            ///c.Rectangle((0, 0), (.5, .5));
            
        }
    }
}