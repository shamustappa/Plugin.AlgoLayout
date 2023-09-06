using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Rhino.Geometry;

namespace AlgoLayout.Core.Interfaces
{
    public interface IRoom
    {
        // Initialize the room layout with necessary Rhino geometry
        void Initialize(List<Curve> roomBoundaries, List<Point3d> furniturePoints);

        // Run the room layout algorithm
        void RunRoomLayout();

        // Stop the room layout algorithm
        void StopRoomLayout();

        // Export the room layout as Rhino geometry
        List<GeometryBase> ExportRoomLayout();

        // Validate the room layout (e.g., check if it's feasible)
        bool ValidateRoomLayout();

        // Event to notify when the room layout algorithm is completed
        event EventHandler RoomLayoutCompleted;

        // Property to check if the room layout algorithm is currently running
        bool IsRoomLayoutRunning { get; }

        // Method to optimize the room layout
        void OptimizeRoomLayout();

        // Method to calculate the room's usability score
        double CalculateUsabilityScore();

        // Method to check for room layout collisions (e.g., furniture overlap)
        bool CheckCollisions();
    }
}
