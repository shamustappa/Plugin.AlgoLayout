using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Rhino.Geometry;

namespace AlgoLayout.Core.Interfaces
{
    public interface IMep
    {
        // Initialize the MEP layout with necessary Rhino geometry
        void Initialize(List<Point3d> points, List<Curve> ducts, List<Curve> pipes);

        // Run the MEP algorithm
        void RunMep();

        // Stop the MEP algorithm
        void StopMep();

        // Export the MEP layout as Rhino geometry
        List<GeometryBase> ExportMep();

        // Validate the MEP layout (e.g., check if it's feasible)
        bool ValidateMep();

        // Event to notify when the MEP algorithm is completed
        event EventHandler MepCompleted;

        // Property to check if the MEP algorithm is currently running
        bool IsMepRunning { get; }

        // Method to optimize the MEP layout
        void OptimizeMep();

        // Method to check for MEP layout collisions
        bool CheckCollisions();
    }
}
