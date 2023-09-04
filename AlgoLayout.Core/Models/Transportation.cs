using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum TransportationType
    {
        Stairs,
        Elevator,
        Escalator,
        Dumbwaiter
    }

    public class Transportation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TransportationType Type { get; set; }
        public List<Room> ConnectedRooms { get; set; } // List of rooms connected by this transportation system
        public List<Entrance> AccessibleEntrances { get; set; } // List of entrances accessible from this transportation system
        public List<FireSafety> IntegratedFireSafety { get; set; } // List of integrated fire safety measures
        public List<CarPark> AccessibleCarParks { get; set; } // List of car parks accessible from this transportation system
        public List<MEP> IntegratedMEP { get; set; } // List of integrated MEP systems

        public Transportation(int id, string name, TransportationType type)
        {
            Id = id;
            Name = name;
            Type = type;
            ConnectedRooms = new List<Room>();
            AccessibleEntrances = new List<Entrance>();
            IntegratedFireSafety = new List<FireSafety>();
            AccessibleCarParks = new List<CarPark>();
            IntegratedMEP = new List<MEP>();
        }

        // Methods to add various components
        public void AddConnectedRoom(Room room)
        {
            ConnectedRooms.Add(room);
        }

        public void AddAccessibleEntrance(Entrance entrance)
        {
            AccessibleEntrances.Add(entrance);
        }

        public void AddIntegratedFireSafety(FireSafety fireSafety)
        {
            IntegratedFireSafety.Add(fireSafety);
        }

        public void AddAccessibleCarPark(CarPark carPark)
        {
            AccessibleCarParks.Add(carPark);
        }

        public void AddIntegratedMEP(MEP mep)
        {
            IntegratedMEP.Add(mep);
        }

        // Methods to check relationships and conditions
        public bool ConnectsRoom(Room room)
        {
            return ConnectedRooms.Contains(room);
        }

        public bool IsAccessibleFromEntrance(Entrance entrance)
        {
            return AccessibleEntrances.Contains(entrance);
        }

        public bool HasIntegratedFireSafety(FireSafety fireSafety)
        {
            return IntegratedFireSafety.Contains(fireSafety);
        }

        public bool IsAccessibleFromCarPark(CarPark carPark)
        {
            return AccessibleCarParks.Contains(carPark);
        }

        public bool HasIntegratedMEP(MEP mep)
        {
            return IntegratedMEP.Contains(mep);
        }
    }
}
