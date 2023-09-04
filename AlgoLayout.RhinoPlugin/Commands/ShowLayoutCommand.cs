using Rhino;
using Rhino.Commands;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.Algorithms;

namespace AlgoLayout.RhinoPlugin.Commands
{
    public class ShowLayoutCommand : Command
    {
        static ShowLayoutCommand _instance;
        public ShowLayoutCommand()
        {
            _instance = this;
        }

        ///<summary>The only instance of the ShowLayoutCommand command.</summary>
        public static ShowLayoutCommand Instance
        {
            get { return _instance; }
        }

        public override string EnglishName
        {
            get { return "ShowLayout"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // Retrieve the Layout object (this could be stored in the document's user data, for example)
            Layout layout = RetrieveLayoutFromDoc(doc);

            if (layout == null)
            {
                return Result.Failure;
            }

            // Visualize Rooms
            foreach (var room in layout.Rooms)
            {
                // Create Rhino geometry for each room
                // For simplicity, assuming room has properties X, Y, Width, Height
                var rect = new Rectangle3d(Plane.WorldXY, new Point3d(room.X, room.Y, 0), room.Width, room.Height);
                doc.Objects.AddRectangle(rect);
            }

            // Visualize WalkPaths, Entrances, etc.
            // ...

            doc.Views.Redraw();

            return Result.Success;
        }

        private Layout RetrieveLayoutFromDoc(RhinoDoc doc)
        {
            // Retrieve the Layout object from the document's user data
            // This is just a placeholder; actual implementation may vary
            return null;
        }
    }
}