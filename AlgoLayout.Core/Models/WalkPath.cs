using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum WalkPathType
    {
        Corridor,
        Hallway,
        PedestrianPathway
    }

    public class WalkPath
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WalkPathType Type { get; set; }
        public List<Room> ConnectedRooms { get; set; } // List of rooms connected by this walk path
        public List<Entrance> AccessibleEntrances { get; set; } // List of entrances accessible from this walk path
        public List<FireSafety> IntegratedFireSafety { get; set; } // List of integrated fire safety measures
        public List<CarPark> AccessibleCarParks { get; set; } // List of car parks accessible from this walk path
        public List<Transportation> IntegratedTransportation { get; set; } // List of integrated transportation systems
        public List<MEP> IntegratedMEP { get; set; } // List of integrated MEP systems
        public List<Services> IntegratedServices { get; set; } // List of integrated utility services

        public WalkPath(int id, string name, WalkPathType type)
        {
            Id = id;
            Name = name;
            Type = type;
            ConnectedRooms = new List<Room>();
            AccessibleEntrances = new List<Entrance>();
            IntegratedFireSafety = new List<FireSafety>();
            AccessibleCarParks = new List<CarPark>();
            IntegratedTransportation = new List<Transportation>();
            IntegratedMEP = new List<MEP>();
            IntegratedServices = new List<Services>();
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

        public void AddIntegratedTransportation(Transportation transportation)
        {
            IntegratedTransportation.Add(transportation);
        }

        public void AddIntegratedMEP(MEP mep)
        {
            IntegratedMEP.Add(mep);
        }

        public void AddIntegratedServices(Services services)
        {
            IntegratedServices.Add(services);
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

        public bool HasIntegratedTransportation(Transportation transportation)
        {
            return IntegratedTransportation.Contains(transportation);
        }

        public bool HasIntegratedMEP(MEP mep)
        {
            return IntegratedMEP.Contains(mep);
        }

        public bool HasIntegratedServices(Services services)
        {
            return IntegratedServices.Contains(services);
        }
    }
}
