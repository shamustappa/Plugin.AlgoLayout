using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using System.Collections.Generic;

namespace AlgoLayout.RhinoPlugin.Interfaces
{
    public interface IRhinoCommand
    {
        // Method to run the command
        Result RunCommand(RhinoDoc doc, RunMode mode);

        // Method to undo the command
        Result UndoCommand(RhinoDoc doc);

        // Property to get the English name of the command
        string EnglishName { get; }

        // Method to initialize the command with necessary Rhino geometry or data
        void InitializeCommand(List<GeometryBase> initialGeometry);

        // Method to validate the command (e.g., check if it's feasible)
        bool ValidateCommand();

        // Event to notify when the command is completed
        event System.EventHandler CommandCompleted;

        // Property to check if the command is currently running
        bool IsCommandRunning { get; }

        // Method to optimize the command
        void OptimizeCommand();

        // Method to export the command result as Rhino geometry
        List<GeometryBase> ExportCommandResult();
    }
}
