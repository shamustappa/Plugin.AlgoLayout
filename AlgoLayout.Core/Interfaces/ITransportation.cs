using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Rhino.Geometry;

namespace AlgoLayout.Core.Interfaces
{
    public interface ITransportation
    {
        // Initialize the transportation layout with necessary Rhino geometry
        void Initialize(List<Curve> roads, List<Point3d> transitStops, List<Curve> pathways);

        // Run the transportation layout algorithm
        void RunTransportationLayout();

        // Stop the transportation layout algorithm
        void StopTransportationLayout();

        // Export the transportation layout as Rhino geometry
        List<GeometryBase> ExportTransportationLayout();

        // Validate the transportation layout (e.g., check if it's feasible)
        bool ValidateTransportationLayout();

        // Event to notify when the transportation layout algorithm is completed
        event EventHandler TransportationLayoutCompleted;

        // Property to check if the transportation layout algorithm is currently running
        bool IsTransportationLayoutRunning { get; }

        // Method to optimize the transportation layout
        void OptimizeTransportationLayout();

        // Method to calculate the transportation efficiency score
        double CalculateEfficiencyScore();

        // Method to check for transportation layout collisions (e.g., overlapping roads)
        bool CheckCollisions();
    }
}
