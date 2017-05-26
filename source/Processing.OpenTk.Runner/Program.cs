using System;
using Processing.OpenTk.Core;
using OpenTK.Graphics;
using Processing.OpenTk.Core.Math;

namespace Processing.OpenTk.Runner
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (Canvas canvas = new Canvas(800, 600, "Example"))
            {
                canvas.Draw += Draw;                
                canvas.Run(180f);
            }
        }

        static float a = 0;

        static void Draw(Canvas c)
        {
            c.Background(Color4.CornflowerBlue);

            c.Style.Fill = Color4.Crimson;
            PVector offset = c.ToScalarCoordinate((c.Mouse.X, c.Mouse.Y));
            offset = (offset.X, -offset.Y);

            c.PushMatrix()
                .Translate(offset)
                .Rotate((a += 1.5f))                
                .Triangle((0, .25), (-.1, -.1), (.1, -.1))
             .PopMatrix();

            c.Style.Fill = Color4.LightSalmon;

            c.Rectangle((0, 0), (.5, .5));

            c.Title = $"{c.Mouse.X},{c.Mouse.Y}";
        }
    }
}