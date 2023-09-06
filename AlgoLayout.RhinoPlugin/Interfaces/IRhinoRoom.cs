using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Media.Media3D;
using Rhino.Geometry;

namespace AlgoLayout.RhinoPlugin.Interfaces
{
    public interface IRhinoRoom
    {
        // Initialize the room layout with necessary Rhino geometry
        void Initialize(List<Point3d> roomCorners, List<Curve> walls, List<Curve> doors);

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

        // Method to calculate the room's efficiency score
        double CalculateEfficiencyScore();

        // Method to check for room layout collisions (e.g., overlapping furniture)
        bool CheckCollisions();
    }
}
