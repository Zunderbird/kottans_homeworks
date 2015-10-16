using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
    // TODO: use Heron's formula for area
    public class Triangle : ShapeBase
    {
        private double _edge1;
        private double _edge2;
        private double _edge3;

        public double Edge1 { get { return _edge1 * Multiplier; } }
        public double Edge2 { get { return _edge2 * Multiplier; } }
        public double Edge3 { get { return _edge3 * Multiplier; } }

        public override string ShapeName { get; }

        public Triangle(double edge1, double edge2, double edge3)
            : this(new Dictionary<ParamKeys, object>
            {
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.Edge3, edge3},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

        public Triangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _edge3 = (double)parameters[ParamKeys.Edge3];
            ShapeName = "Triangle";
        }

        public override double GetPerimeter()
        {
            return Edge1 + Edge2 + Edge3;
        }

        protected override double Area()
        {
            var semiperimeter = GetPerimeter() / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - Edge1) * (semiperimeter - Edge2) * (semiperimeter - Edge3));
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }
    }
}