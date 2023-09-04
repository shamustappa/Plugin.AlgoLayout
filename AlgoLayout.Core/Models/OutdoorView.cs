using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum SceneryType
    {
        Scenic,
        Cityscape,
        Garden,
        Waterfront
    }

    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    public class OutdoorView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SceneryType Scenery { get; set; }
        public Direction ViewDirection { get; set; }
        public List<Room> VisibleFromRooms { get; set; } // List of rooms from which this view is visible
        public List<WalkPath> AccessibleWalkPaths { get; set; } // List of walk paths from which this view is accessible

        public OutdoorView(int id, string name, SceneryType scenery, Direction direction)
        {
            Id = id;
            Name = name;
            Scenery = scenery;
            ViewDirection = direction;
            VisibleFromRooms = new List<Room>();
            AccessibleWalkPaths = new List<WalkPath>();
        }

        // Methods to add various components
        public void AddVisibleFromRoom(Room room)
        {
            VisibleFromRooms.Add(room);
        }

        public void AddAccessibleWalkPath(WalkPath walkPath)
        {
            AccessibleWalkPaths.Add(walkPath);
        }

        // Methods to check relationships and conditions
        public bool IsVisibleFromRoom(Room room)
        {
            return VisibleFromRooms.Contains(room);
        }

        public bool IsAccessibleFromWalkPath(WalkPath walkPath)
        {
            return AccessibleWalkPaths.Contains(walkPath);
        }
    }
}
