using Processing.OpenTk.Core.Vectors;

namespace Processing.OpenTk.Core.Rendering
{
    public class Model
    {
        public struct TriangleMap
        {
            public readonly ushort A;
            public readonly ushort B;
            public readonly ushort C;            

            public TriangleMap(ushort a, ushort b, ushort c) { A = a; B = b; C = c; }

            public int this[int i] { get => i == 1 ? A : (i == 2 ? B : C); }

            public static implicit operator TriangleMap((int a, int b, int c) v) => new TriangleMap((ushort)v.a, (ushort)v.b, (ushort)v.c);
        }

        public PVector3 Scale { get; set; } = (1, 1, 1);
        public PVector3 Rotation { get; set; } = (0, 0, 0);
        public readonly PVector3[] Verticies;        
        public readonly TriangleMap[] Triangles;

        public Model(
            PVector3[] verticies,         
            TriangleMap[] triangles)
        {
            Verticies = verticies;
            Triangles = triangles;
        }

        public PVector3 this[TriangleMap t, int i]
        {
            get => Verticies[t[i]];
        }
    }
}
