using OpenTK.Graphics;
using TrueTypeSharp;

namespace Processing.OpenTk.Core.Rendering
{
    public class Style
    {
        public TrueTypeFont Font { get; set; }
        public float FontSize { get; set; } = 12;
        public Color4 Fill { get; set; } = Color4.White;
        public Color4 Stroke { get; set; } = Color4.Black;
        public float StrokeWeight { get; set; } = 1;
        public Orientation NormalOrientation { get; set; } = Orientation.Forward | Orientation.Inverse;
    }
}
