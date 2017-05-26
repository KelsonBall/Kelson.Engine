using OpenTK;
using static System.Math;

namespace Processing.OpenTk.Core.Math
{
    public struct PVector3
    {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        public PVector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static PVector3 î => (1, 0, 0);

        public static PVector3 ĵ => (0, 1, 0);

        public static PVector3 k̂ => (0, 0, 1);

        public static PVector3 O => (0, 0, 0);

        public static PVector3 FromAngle(double angle) => (Sin(angle), Cos(angle), 0);

        public static PVector3 operator +(PVector3 a, PVector3 b) => a.Add(b);

        public static PVector3 operator -(PVector3 a, PVector3 b) => a.Add((-b.X, -b.Y, -b.Z));

        public static PVector3 operator *(PVector3 a, PVector3 b) => (a.X * b.X, a.Y * b.Y, a.Z * b.Z);

        public static PVector3 operator *(PVector3 a, double b) => a.Scale(b);

        public static PVector3 operator *(PVector3 a, int b) => a.Scale(b);

        public static PVector3 operator *(double a, PVector3 b) => b.Scale(a);

        public static PVector3 operator *(int a, PVector3 b) => b.Scale(a);

        public static PVector3 operator /(PVector3 a, double b) => a.Scale(1 / b);

        public PVector3 Add(PVector3 to) => (X + to.X, Y + to.Y, Z + to.Z);

        public PVector3 Scale(double scalar) => (X * scalar, Y * scalar, Z * scalar);

        public double Dot(PVector3 by) => X * by.X + Y * by.Y + Z * by.Z;

        public PVector3 Cross(PVector3 b) => (Y * b.Z - Z * b.Y, X * b.Z - Z * b.X, X * b.Y - Y * b.X);

        public double MagnitudeSquared() => X * X + Y * Y + Z * Z;

        public double Magnitude() => Sqrt(MagnitudeSquared());

        public double Angle() => Atan2(Y, X);

        public PVector3 Unit() => this / Magnitude();

        public PVector3 Rotate(double angle) => FromAngle(Angle() + angle) * Magnitude();

        public override string ToString() => $"{{{X}, {Y}}}";        

        public static implicit operator Vector3(PVector3 v) => new Vector3((float)v.X, (float)v.Y, (float)v.Z);

        public static implicit operator PVector3((double, double, double) v) => new PVector3(v.Item1, v.Item2, v.Item3);
    }
}
