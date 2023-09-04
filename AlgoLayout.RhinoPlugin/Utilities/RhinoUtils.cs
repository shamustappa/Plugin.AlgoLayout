using Rhino;
using Rhino.Geometry;
using AlgoLayout.Core;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace AlgoLayout.RhinoPlugin.Utilities
{
    public static class RhinoUtils
    {
        public static void AddLayoutToRhino(Layout layout, RhinoDoc doc)
        {
            // Clear existing layout geometry
            doc.Objects.Clear();

            // Add rooms as rectangles
            foreach (var room in layout.Rooms)
            {
                var rect = new Rectangle3d(Plane.WorldXY, new Point3d(room.X, room.Y, 0), room.Width, room.Height);
                doc.Objects.AddRectangle(rect);
            }

            // Add walk paths, entrances, etc. (if applicable)
            // ...

            // Redraw the Rhino view
            doc.Views.Redraw();
        }

        public static Layout GetLayoutFromRhino(RhinoDoc doc)
        {
            Layout layout = new Layout();

            // Logic to convert Rhino geometry to Layout
            // ...

            return layout;
        }

        public static void RunOptimization(Layout layout, string algorithm)
        {
            // Logic to run the selected optimization algorithm on the layout
            // ...

            // Update the Rhino document with the optimized layout
            var doc = RhinoDoc.ActiveDoc;
            AddLayoutToRhino(layout, doc);
        }
    }
}
