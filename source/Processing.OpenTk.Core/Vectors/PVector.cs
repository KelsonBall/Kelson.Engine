using OpenTK;
using static System.Math;

namespace Processing.OpenTk.Core.Vectors
{
    public struct PVector
    {
        public readonly double X;
        public readonly double Y;

        public PVector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static PVector î => (1, 0);

        public static PVector ĵ => (0, 1);

        public static PVector O => (0, 0);

        public static PVector FromAngle(double angle) => (Sin(angle), Cos(angle));
        
        public static PVector operator +(PVector a, PVector b) => a.Add(b);
        
        public static PVector operator -(PVector a, PVector b) =>  a.Add((-b.X, -b.Y));
        
        public static PVector operator *(PVector a, PVector b) => (a.X * b.X, a.Y * b.Y);
        
        public static PVector operator *(PVector a, double b) => a.Scale(b);
        
        public static PVector operator *(PVector a, int b) => a.Scale(b);        

        public static PVector operator *(double a, PVector b) => b.Scale(a);
        
        public static PVector operator *(int a, PVector b) => b.Scale(a);
        
        public static PVector operator /(PVector a, double b) => a.Scale(1 / b);
        
        public PVector Add(PVector to) => (X + to.X, Y + to.Y);
        
        public PVector Scale(double scalar) => (X * scalar, Y * scalar);
        
        public double Dot(PVector by) => X * by.X + Y * by.Y;
        
        public double MagnitudeSquared() => X * X + Y * Y;
        
        public double Magnitude() => Sqrt(MagnitudeSquared());
        
        public double Angle() => Atan2(Y, X);
        
        public PVector Unit() => this / Magnitude();
        
        public PVector Rotate(double angle) => FromAngle(Angle() + angle) * Magnitude();
            
        public override string ToString() => $"{{{X}, {Y}}}";
        
        public static implicit operator Vector2(PVector v) => new Vector2((float)v.X, (float)v.Y);

        public static implicit operator PVector((double, double) v) => new PVector(v.Item1, v.Item2);
    }
}
