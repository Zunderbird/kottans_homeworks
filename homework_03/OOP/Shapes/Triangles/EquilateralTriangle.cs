using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// triangle where all edges are equal
    /// </summary>
    public class EquilateralTriangle : Triangle
    {
        public override string ShapeName { get; }

        public EquilateralTriangle(double edge1)
            : this(new Dictionary<ParamKeys, object>
            {
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge1},
                {ParamKeys.Edge3, edge1},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

        public EquilateralTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            ShapeName = "EquilateralTriangle";
        }

        public override double GetPerimeter()
        {
            return Edge1 * 3;
        }

        protected override double Area()
        {
            return Math.Sqrt(3)/4 * (Edge1* Edge1);
        }
    }
}