using System.Collections.Generic;

namespace ArchitecturalLayout.Core.Models
{
    public class Layout
    {
        public List<Room> Rooms { get; set; }
        public List<WalkPath> WalkPaths { get; set; }
        public List<Entrance> Entrances { get; set; }
        public List<Service> Services { get; set; }
        public List<Transportation> Transportations { get; set; }
        public List<FireExit> FireExits { get; set; }
        public List<CarPark> CarParks { get; set; }
        public List<OutdoorView> OutdoorViews { get; set; }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public void RemoveRoom(Room room)
        {
            Rooms.Remove(room);
        }

        public void AddWalkPath(WalkPath walkPath)
        {
            WalkPaths.Add(walkPath);
        }

        public void RemoveWalkPath(WalkPath walkPath)
        {
            WalkPaths.Remove(walkPath);
        }
    }

    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public string Function { get; set; }

        public Room(int id, string name, double area, string function)
        {
            Id = id;
            Name = name;
            Area = area;
            Function = function;
        }
    }

    public class WalkPath
    {
        public int Id { get; set; }
        public List<int> ConnectedRooms { get; set; } = new List<int>();
        public double Length { get; set; }

        public WalkPath(int id, double length)
        {
            Id = id;
            Length = length;
        }

        public void ConnectRoom(int roomId)
        {
            ConnectedRooms.Add(roomId);
        }
    }

    public class Entrance
    {
        public int Id { get; set; }
        public string Type { get; set; } // e.g., "Main", "Emergency"
        public bool IsAccessible { get; set; }

        public Entrance(int id, string type, bool isAccessible)
        {
            Id = id;
            Type = type; 
            IsAccessible = isAccessible;
        }
    }

    public class Service
    {
        public int Id { get; set; }
        public string Type { get; set; } // e.g., "Electricity", "Water
        public string Location { get; set; } // e.g., "Basement", "Roof"

        public Service(int id, string type, string location)
        {
            Id = id;
            Type = type;
            Location = location;
        }
    }

    public class Transportation
    {
        public int Id { get; set; }
        public string Type { get; set; } // e.g., "Elevator", "Escalator"
        public int Capacity { get; set; }

        public Transportation(int id, string type, int capacity)
        {
            Id = id;
            Type = type;
            Capacity = capacity;
        }
    }

    public class FireExit
    {
        public int Id { get; set; }
        public string Type { get; set; } // e.g., "North", "South"
        public bool IsAccessible { get; set; }

        public FireExit(int id, string type, bool isAccessible)
        {
            Id = id;
            Type = type;
            IsAccessible = isAccessible;
        }
    }

    public class CarPark
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; } // e.g., "Open spaces", "High rise"

        public CarPark(int id, string type, int capacity)
        {
            Id = id;
            Type = type;
            Capacity = capacity;
        }
    }

    public class OutdoorView
    {
        public int Id { get; set; }
        public string Scenery { get; set; } // e.g., "Lake", "Park"
        public string Direction { get; set; } // e.g., "North", "West"

        public OutdoorView(int  id, string scenery, string direction)
        {
            Id = id;
            Scenery = scenery;
            Direction = direction;
        }
    }
}
