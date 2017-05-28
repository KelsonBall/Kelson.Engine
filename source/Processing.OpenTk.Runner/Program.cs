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
                canvas.Run(60f);
            }
        }
        
        static PVector offset = (0, 0);
        static readonly double rotationSpeed = 0.75;
        static readonly double moveSpeed = 0.05;
        static Model cube = Shapes.Cube();

        static void Setup(ICanvas c)
        {
            cube.Scale = (1, 2, 1);
        }

        static void Draw(ICanvas c)
        {
            c.Perspective()
             .IfKey(Key.Up, () => cube.Rotation -= PVector3.î * rotationSpeed)
             .IfKey(Key.Down, () => cube.Rotation += PVector3.î * rotationSpeed)
             .IfKey(Key.Left, () => cube.Rotation -= PVector3.ĵ * rotationSpeed)
             .IfKey(Key.Right, () => cube.Rotation += PVector3.ĵ * rotationSpeed)
             .IfKey(Key.A, () => offset -= PVector.î * moveSpeed)
             .IfKey(Key.D, () => offset += PVector.î * moveSpeed)
             .IfKey(Key.W, () => offset += PVector.ĵ * moveSpeed)
             .IfKey(Key.S, () => offset -= PVector.ĵ * moveSpeed)             
             .Background(Color4.White)
             .Fill(Color4.Gray.WithAlpha(0.3))
             .PushMatrix()             
             .Translate((offset.X, offset.Y, -6))
             .Model(cube)
             .PopMatrix();      

            ///c.Rectangle((0, 0), (.5, .5));
            
        }
    }
}