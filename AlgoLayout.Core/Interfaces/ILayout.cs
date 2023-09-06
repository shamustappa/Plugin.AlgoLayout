using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Rhino.Geometry;

namespace AlgoLayout.Core.Interfaces
{
    public interface ILayout
    {
        // Initialize the layout with necessary Rhino geometry
        void Initialize(List<Point3d> points, List<Curve> curves);

        // Run the layout algorithm
        void RunLayout();

        // Stop the layout algorithm
        void StopLayout();

        // Export the layout as Rhino geometry
        List<GeometryBase> ExportLayout();

        // Validate the layout (e.g., check if it's feasible)
        bool ValidateLayout();

        // Event to notify when the layout algorithm is completed
        event EventHandler LayoutCompleted;

        // Property to check if the layout algorithm is currently running
        bool IsLayoutRunning { get; }
    }
}
