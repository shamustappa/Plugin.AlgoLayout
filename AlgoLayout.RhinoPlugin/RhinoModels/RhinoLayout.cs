using Rhino.Geometry;
using AlgoLayout.Core.Models;
public class RhinoLayout
{
    public Layout Layout { get; set; }

    public RhinoLayout(Layout layout)
    {
        Layout = layout;
    }

    public void ToRhinoGeometry(RhinoDoc doc)
    {
        // Convert Rooms to Rhino Geometry
        foreach (var room in Layout.Rooms)
        {
            var rect = new Rectangle3d(Plane.WorldXY, new Point3d(room.X, room.Y, 0), room.Width, room.Height);
            doc.Objects.AddRectangle(rect);
        }

        // Convert other elements like WalkPaths, Entrances, etc.
        // ...

        doc.Views.Redraw();
    }

    public static Layout FromRhinoGeometry(RhinoDoc doc)
    {
        Layout layout = new Layout();

        // Convert Rhino Geometry to Rooms
        // ...

        // Convert other Rhino Geometry to WalkPaths, Entrances, etc.
        // ...

        return layout;
    }
}
}