using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Rhino.Geometry;

namespace AlgoLayout.Core.Interfaces
{
    public interface IMicrosite
    {
        // Initialize the microsite layout with necessary Rhino geometry
        void Initialize(List<Point3d> buildingFootprints, List<Curve> roads, List<Point3d> amenities);

        // Run the microsite algorithm
        void RunMicrosite();

        // Stop the microsite algorithm
        void StopMicrosite();

        // Export the microsite layout as Rhino geometry
        List<GeometryBase> ExportMicrosite();

        // Validate the microsite layout (e.g., check if it's feasible)
        bool ValidateMicrosite();

        // Event to notify when the microsite algorithm is completed
        event EventHandler MicrositeCompleted;

        // Property to check if the microsite algorithm is currently running
        bool IsMicrositeRunning { get; }

        // Method to optimize the microsite layout
        void OptimizeMicrosite();

        // Method to check for zoning regulations
        bool CheckZoningRegulations();

        // Method to calculate the accessibility score of the microsite
        double CalculateAccessibilityScore();
    }
}
