using System;
using System.Security.Cryptography;
using Rhino.Geometry;

namespace AlgoLayout.Core.Utilities
{
    public static class CalculationUtils
    {
        // Calculate the area of a rectangle
        public static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }

        // Calculate the area of a circle
        public static double CalculateCircleArea(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        // Calculate the perimeter of a rectangle
        public static double CalculateRectanglePerimeter(double width, double height)
        {
            return 2 * (width + height);
        }

        // Calculate the circumference of a circle
        public static double CalculateCircleCircumference(double radius)
        {
            return 2 * Math.PI * radius;
        }

        // Calculate the distance between two points (x1, y1) and (x2, y2)
        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        // Calculate the midpoint between two points (x1, y1) and (x2, y2)
        public static (double, double) CalculateMidpoint(double x1, double y1, double x2, double y2)
        {
            double midpointX = (x1 + x2) / 2;
            double midpointY = (y1 + y2) / 2;
            return (midpointX, midpointY);
        }

        // Convert a Rhino Point3d to a custom Point type
        public static MyPoint ConvertToPoint3d(Point3d rhinoPoint)
        {
            return new MyPoint(rhinoPoint.X, rhinoPoint.Y, rhinoPoint.Z);
        }

        // Calculate the area of a Rhino Polygon
        public static double CalculatePolygonArea(Polyline polyline)
        {
            // calculation here
        }

    }
}
