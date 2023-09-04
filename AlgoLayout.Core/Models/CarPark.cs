using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum CarParkType
    {
        OpenSpace,
        HighRise
    }

    public class CarPark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CarParkType Type { get; set; }
        public int TotalSpaces { get; set; }
        public double Area { get; set; } // in square meters
        public List<Room> AdjacentRooms { get; set; } // List of adjacent rooms
        public List<Entrance> AccessibleEntrances { get; set; } // List of accessible entrances

        public CarPark(int id, string name, CarParkType type, int totalSpaces, double area)
        {
            Id = id;
            Name = name;
            Type = type;
            TotalSpaces = totalSpaces;
            Area = area;
            AdjacentRooms = new List<Room>();
            AccessibleEntrances = new List<Entrance>();
        }

        public void AddAdjacentRoom(Room room)
        {
            AdjacentRooms.Add(room);
        }

        public void AddAccessibleEntrance(Entrance entrance)
        {
            AccessibleEntrances.Add(entrance);
        }

        public bool IsAdjacentToRoom(Room room)
        {
            return AdjacentRooms.Contains(room);
        }

        public bool IsAccessibleFromEntrance(Entrance entrance)
        {
            return AccessibleEntrances.Contains(entrance);
        }
    }
}
