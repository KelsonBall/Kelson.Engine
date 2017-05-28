using System;
using System.Collections.Generic;
using System.Text;
using Processing.OpenTk.Core.Vectors;

namespace Processing.OpenTk.Core.Rendering
{
    public static class Shapes
    {
        public static Model Cube()
        {
            return new Model
            (
                new PVector3[] 
                      { (0, 0, 0), (1, 0, 0), (1, 0, 1), (0, 0, 1), 
                        (0, 1, 0), (1, 1, 0), (1, 1, 1), (0, 1, 1)},

                new Model.TriangleMap[] 
                      { (0, 1, 2),(0, 3, 2),
                        (0, 1, 5),(0, 4, 5),
                        (0, 3, 7),(0, 4, 7),
                        (1, 2, 6),(1, 5, 6),
                        (4, 5, 6),(4, 7, 5),
                        (2, 3, 7),(2, 6, 7),
                }
            );
        }
    }
}
