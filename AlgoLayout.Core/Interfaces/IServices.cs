using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Rhino.Geometry;

namespace AlgoLayout.Core.Interfaces
{
    public interface IServices
    {
        // Initialize the services layout with necessary Rhino geometry
        void Initialize(List<Point3d> hvacPoints, List<Curve> plumbingLines, List<Point3d> electricalOutlets);

        // Run the services layout algorithm
        void RunServicesLayout();

        // Stop the services layout algorithm
        void StopServicesLayout();

        // Export the services layout as Rhino geometry
        List<GeometryBase> ExportServicesLayout();

        // Validate the services layout (e.g., check if it's feasible)
        bool ValidateServicesLayout();

        // Event to notify when the services layout algorithm is completed
        event EventHandler ServicesLayoutCompleted;

        // Property to check if the services layout algorithm is currently running
        bool IsServicesLayoutRunning { get; }

        // Method to optimize the services layout
        void OptimizeServicesLayout();

        // Method to calculate the services' efficiency score
        double CalculateEfficiencyScore();

        // Method to check for services layout collisions (e.g., overlapping pipes)
        bool CheckCollisions();
    }
}
