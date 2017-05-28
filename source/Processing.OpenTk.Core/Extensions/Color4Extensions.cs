using OpenTK.Graphics;

namespace Processing.OpenTk.Core.Extensions
{
    public static class Color4Extensions
    {
        public static int ToRgbaIntegerFormat(this Color4 color)
        {
            byte ToByte(float f) => (byte)(0xFF * f);

            return ToByte(color.R) << 24 | ToByte(color.G) << 16 | ToByte(color.B) << 8 | ToByte(color.A);
        }

        public static Color4 ChangeLightness(this Color4 color, double scalar)
        {
            float s = (float)scalar;
            return new Color4(color.R * s, color.G * s, color.B * s, color.A);
        }

        public static Color4 WithAlpha(this Color4 color, double alpha)
        {
            return new Color4(color.R, color.G, color.B, (float)alpha);
        }
    }
}
