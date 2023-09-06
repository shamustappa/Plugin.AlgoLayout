using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Rhino.Geometry;

namespace AlgoLayout.Core.Interfaces
{
    public interface IWalkPath
    {
        // Initialize the walk path layout with necessary Rhino geometry
        void Initialize(List<Point3d> startPoints, List<Point3d> endPoints, List<Curve> obstacles);

        // Run the walk path layout algorithm
        void RunWalkPathLayout();

        // Stop the walk path layout algorithm
        void StopWalkPathLayout();

        // Export the walk path layout as Rhino geometry
        List<GeometryBase> ExportWalkPathLayout();

        // Validate the walk path layout (e.g., check if it's feasible)
        bool ValidateWalkPathLayout();

        // Event to notify when the walk path layout algorithm is completed
        event EventHandler WalkPathLayoutCompleted;

        // Property to check if the walk path layout algorithm is currently running
        bool IsWalkPathLayoutRunning { get; }

        // Method to optimize the walk path layout
        void OptimizeWalkPathLayout();

        // Method to calculate the walk path's efficiency score
        double CalculateEfficiencyScore();

        // Method to check for walk path layout collisions (e.g., overlapping paths)
        bool CheckCollisions();
    }
}
