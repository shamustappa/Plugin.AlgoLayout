using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Rhino.Geometry;

namespace AlgoLayout.Core.Interfaces
{
    public interface IOutdoorView
    {
        // Initialize the outdoor view analysis with necessary Rhino geometry
        void Initialize(List<Point3d> viewpoints, List<Curve> obstacles);

        // Run the outdoor view analysis
        void RunViewAnalysis();

        // Stop the outdoor view analysis
        void StopViewAnalysis();

        // Export the outdoor view analysis as Rhino geometry
        List<GeometryBase> ExportViewAnalysis();

        // Validate the outdoor view analysis (e.g., check if it's feasible)
        bool ValidateViewAnalysis();

        // Event to notify when the outdoor view analysis is completed
        event EventHandler ViewAnalysisCompleted;

        // Property to check if the outdoor view analysis is currently running
        bool IsViewAnalysisRunning { get; }

        // Method to optimize the outdoor view
        void OptimizeView();

        // Method to calculate the view score based on analysis
        double CalculateViewScore();

        // Method to check for view obstructions
        bool CheckViewObstructions();
    }
}
