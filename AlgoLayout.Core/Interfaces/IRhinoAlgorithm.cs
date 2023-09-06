using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Rhino.Geometry;

namespace AlgoLayout.Core.Interfaces
{
    public interface IRhinoAlgorithm : IAlgorithm<List<Point3d>, List<Curve>>
    {
        // Additional methods specific to Rhino
        void ConvertRhinoGeometry(List<Point3d> points, List<Curve> curves);
    }
}
