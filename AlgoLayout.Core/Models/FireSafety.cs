using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum FireSafetyType
    {
        FireExtinguisher,
        FireAlarm,
        SprinklerSystem,
        EmergencyExit
    }

    public enum DeadEndType
    {
        Permitted,
        NotPermitted
    }

    public class FireSafety
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FireSafetyType Type { get; set; }
        public DeadEndType DeadEndStatus { get; set; }
        public double MinDistanceToExit { get; set; } // in meters
        public List<Room> CoveredRooms { get; set; }
        public List<Entrance> AccessibleEntrances { get; set; }
        public List<CarPark> CoveredCarParks { get; set; }

        public FireSafety(int id, string name, FireSafetyType type, DeadEndType deadEndStatus, double minDistanceToExit)
        {
            Id = id;
            Name = name;
            Type = type;
            DeadEndStatus = deadEndStatus;
            MinDistanceToExit = minDistanceToExit;
            CoveredRooms = new List<Room>();
            AccessibleEntrances = new List<Entrance>();
            CoveredCarParks = new List<CarPark>();
        }

        // Methods to add various components
        public void AddCoveredRoom(Room room) => CoveredRooms.Add(room);
        public void AddAccessibleEntrance(Entrance entrance) => AccessibleEntrances.Add(entrance);
        public void AddCoveredCarPark(CarPark carPark) => CoveredCarParks.Add(carPark);

        // Methods to check relationships and conditions
        public bool CoversRoom(Room room) => CoveredRooms.Contains(room);
        public bool IsAccessibleFromEntrance(Entrance entrance) => AccessibleEntrances.Contains(entrance);
        public bool CoversCarPark(CarPark carPark) => CoveredCarParks.Contains(carPark);
        public bool IsDeadEndPermitted() => DeadEndStatus == DeadEndType.Permitted;
        public bool IsWithinMinDistanceToExit(double distance) => distance <= MinDistanceToExit;
    }
}
