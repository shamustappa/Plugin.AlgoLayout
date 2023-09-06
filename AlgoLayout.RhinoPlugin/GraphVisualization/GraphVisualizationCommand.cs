using System;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using AlgoLayout.Core.Interfaces;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace AlgoLayout.RhinoPlugin.GraphVisualization
{
    public class GraphVisualizationCommand : Command
    {
        static GraphVisualizationCommand _instance;
        public GraphVisualizationCommand()
        {
            _instance = this;
        }

        ///<summary>The only instance of the GraphVisualizationCommand command.</summary>
        public static GraphVisualizationCommand Instance
        {
            get { return _instance; }
        }

        public override string EnglishName
        {
            get { return "GraphVisualizationCommand"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // Initialize Graph Visualization UI
            GraphVisualizationUI graphUI = new GraphVisualizationUI();
            RhinoApp.WriteLine("Initializing Graph Visualization...");

            // TODO: Fetch nodes and edges from the document or user input
            List<Point3d> nodes = new List<Point3d>();
            List<Line> edges = new List<Line>();

            // Initialize and run the graph visualization
            graphUI.InitializeGraphVisualization(nodes, edges);
            graphUI.RunGraphVisualization();

            // Validate the graph visualization
            if (graphUI.ValidateGraphVisualization())
            {
                RhinoApp.WriteLine("Graph Visualization is valid.");
            }
            else
            {
                RhinoApp.WriteLine("Graph Visualization is invalid.");
            }

            // Export the graph visualization to Rhino geometry
            List<GeometryBase> exportedGeometry = graphUI.ExportGraphVisualization();
            foreach (var geometry in exportedGeometry)
            {
                doc.Objects.Add(geometry);
            }
            doc.Views.Redraw();

            return Result.Success;
        }
    }
}
