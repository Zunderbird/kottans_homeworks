using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// Triangle with one 90 degrees corner
    /// </summary>
    public class RightTriangle : Triangle
    {
        public override string ShapeName { get; }

        public RightTriangle(double edge1, double edge2)
            : this(new Dictionary<ParamKeys, object>
            {
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.Edge3, Math.Sqrt(edge1*edge1 + edge2*edge2)},
                {ParamKeys.Edge3, edge1},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

        public RightTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            ShapeName = "RightTriangle";
        }

        protected override double Area()
        {
            return 0.5d * Edge1 * Edge2;
        }
    }
}