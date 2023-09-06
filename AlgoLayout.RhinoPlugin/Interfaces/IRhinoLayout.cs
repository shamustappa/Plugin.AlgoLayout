using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Geometry;

namespace AlgoLayout.RhinoPlugin.Interfaces
{
    public interface IRhinoLayout
    {
        // Method to initialize the layout with necessary Rhino geometry or data
        void InitializeLayout(List<GeometryBase> initialGeometry);

        // Method to run the layout algorithm
        void RunLayoutAlgorithm();

        // Method to stop the layout algorithm
        void StopLayoutAlgorithm();

        // Method to export the layout as Rhino geometry
        List<GeometryBase> ExportLayout();

        // Method to validate the layout (e.g., check if it's feasible)
        bool ValidateLayout();

        // Event to notify when the layout algorithm is completed
        event EventHandler LayoutAlgorithmCompleted;

        // Property to check if the layout algorithm is currently running
        bool IsLayoutAlgorithmRunning { get; }

        // Method to optimize the layout
        void OptimizeLayout();

        // Method to calculate the layout's efficiency score
        double CalculateEfficiencyScore();

        // Method to check for layout collisions (e.g., overlapping geometries)
        bool CheckCollisions();
    }
}
