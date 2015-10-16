using System;
using System.Collections.Generic;
using NUnit.Framework;
using OOP.Shapes;
using FluentAssertions;
using OOP.Shapes.Triangles;

namespace OOP.Tests
{
	[TestFixture]
    public class GeneralTests
	{
	    private const double RADIUS = 5d;
	    private const double EDGE1 = 3d;
	    private const double EDGE2 = 4d;
	    private const double EDGE3 = 5d;
        private const double HYPOTENUSE = 5d;
        private const int COORD_X = 0;
	    private const int COORD_Y = 0;
	    private const int MULTIPLIER = 3;

        [Test, Sequential]
        public void ShapeShouldBeMoved([Values(
            typeof(Circle)
            // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
            ,typeof(Rectangle)
            ,typeof(Triangle)
            ,typeof(EquilateralTriangle)
            ,typeof(RightTriangle)
            )] Type targetType)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            var coordX = (int)@params[ParamKeys.CoordX];
            var coordY = (int)@params[ParamKeys.CoordY];
            // act 
            target.Move(1, 1);
            // assert
            target.CoordX.Should().Be(coordX + 1);
            target.CoordY.Should().Be(coordY + 1);
        }

        [Test, Sequential]
        public void AreaShouldBeCalculated([Values(
            typeof(Circle)
            // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
            ,typeof(Rectangle)
            ,typeof(Triangle)
            ,typeof(RightTriangle)
            )] Type targetType,
            [Values(RADIUS * RADIUS * Math.PI
            // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
            ,EDGE1 * EDGE2
            ,6d
            ,6d
            )] double area)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            // act 
            var actualArea = target.GetArea();
            // assert
            actualArea.Should().Be(area);
        }

        [Test, Sequential]
        public void PerimeterShouldBeCalculated([Values(
            typeof(Circle)
            // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
            ,typeof(Rectangle)
            ,typeof(Triangle)
            ,typeof(EquilateralTriangle)
            ,typeof(RightTriangle)
            )] Type targetType,
            [Values(2 * RADIUS * Math.PI
            // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
            ,2*(EDGE1 + EDGE2)
            ,EDGE1 + EDGE2 + EDGE3
            ,EDGE1 * 3
            ,EDGE1 + EDGE2 + HYPOTENUSE
            )] double perimeter)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            // act 
            var actualPerimeter = target.GetPerimeter();
            // assert
            actualPerimeter.Should().Be(perimeter);
        }

        [Test, Sequential]
        public void PerimeterShouldBeCalculatedWithMultiplier([Values(
            typeof(Circle)
            // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
            ,typeof(Rectangle)
            ,typeof(Triangle)
            ,typeof(EquilateralTriangle)
            ,typeof(RightTriangle)
            )] Type targetType,
            [Values(2 * RADIUS * Math.PI * MULTIPLIER
            // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
            ,2*(EDGE1 + EDGE2) * MULTIPLIER
            ,(EDGE1 + EDGE2 + EDGE3) * MULTIPLIER
            ,(EDGE1 * 3) * MULTIPLIER
            ,(EDGE1 + EDGE2 + HYPOTENUSE)* MULTIPLIER
            )] double perimeter)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            target.Multiplier = MULTIPLIER;
            // act 
            var actualPerimeter = target.GetPerimeter();
            // assert
            actualPerimeter.Should().Be(perimeter);
        }

        [Test, Sequential]
        public void ShouldReturnValidShapeName([Values(
            typeof(Circle)
            // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
            ,typeof(Rectangle)
            ,typeof(Triangle)
            ,typeof(EquilateralTriangle)
            ,typeof(RightTriangle)
            )] Type targetType,
            [Values("Circle"
            // TODO: UNCOMMENT WHEN IMPLEMENTED ALL SHAPES
            , "Rectangle"
            ,"Triangle"
            ,"EquilateralTriangle"
            ,"RightTriangle"
            )] string shapeName)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            // act 
            var actualShapeName = target.ShapeName;
            // assert
            actualShapeName.Should().Be(shapeName);
        }

        private IShape GetShape(Type shapeActualType, IDictionary<ParamKeys, object> @params)
	    {
	        var instance = Activator.CreateInstance(shapeActualType, @params);
            return  instance as IShape;
	    }

	    private IDictionary<ParamKeys, object> GetParams()
	    {
	        return new Dictionary<ParamKeys, object>
	        {
	            [ParamKeys.CoordX] = COORD_X,
	            [ParamKeys.CoordY] = COORD_Y,
	            [ParamKeys.Edge1] = EDGE1,
	            [ParamKeys.Edge2] = EDGE2,
	            [ParamKeys.Edge3] = EDGE3,
	            [ParamKeys.Radius] = RADIUS,
	        };
	    }
    }
}