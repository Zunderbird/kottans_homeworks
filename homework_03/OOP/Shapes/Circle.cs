using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace OOP.Shapes
{
	public class Circle : ShapeBase
	{
        readonly double _radius;

	    public double Radius { get { return _radius*Multiplier; } }

	    public override string ShapeName => "Circle";

        public Circle(double radius)
            : this(new Dictionary<ParamKeys, object>
            { 
                {ParamKeys.Radius, radius},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

		public Circle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _radius = (double) parameters[ParamKeys.Radius];          
        }     

        public override double GetPerimeter()
        {
            return 2 * Radius * Math.PI;
        }

        protected override double Area()
        {
            return Radius * Radius * Math.PI;
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }
    }
}