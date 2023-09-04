using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum RoomType
    {
        Bedroom,
        Kitchen,
        Office,
        Bathroom,
        Lounge
    }

    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoomType Type { get; set; }
        public List<WalkPath> ConnectedWalkPaths { get; set; } // List of walk paths connected to this room
        public List<Entrance> AccessibleEntrances { get; set; } // List of entrances accessible from this room
        public List<FireSafety> IntegratedFireSafety { get; set; } // List of integrated fire safety measures
        public List<CarPark> NearbyCarParks { get; set; } // List of nearby car parks
        public List<Transportation> IntegratedTransportation { get; set; } // List of integrated transportation systems
        public List<MEP> IntegratedMEP { get; set; } // List of integrated MEP systems
        public List<Services> IntegratedServices { get; set; } // List of integrated utility services

        public Room(int id, string name, RoomType type)
        {
            Id = id;
            Name = name;
            Type = type;
            ConnectedWalkPaths = new List<WalkPath>();
            AccessibleEntrances = new List<Entrance>();
            IntegratedFireSafety = new List<FireSafety>();
            NearbyCarParks = new List<CarPark>();
            IntegratedTransportation = new List<Transportation>();
            IntegratedMEP = new List<MEP>();
            IntegratedServices = new List<Services>();
        }

        // Methods to add various components
        public void AddConnectedWalkPath(WalkPath walkPath)
        {
            ConnectedWalkPaths.Add(walkPath);
        }

        public void AddAccessibleEntrance(Entrance entrance)
        {
            AccessibleEntrances.Add(entrance);
        }

        public void AddIntegratedFireSafety(FireSafety fireSafety)
        {
            IntegratedFireSafety.Add(fireSafety);
        }

        public void AddNearbyCarPark(CarPark carPark)
        {
            NearbyCarParks.Add(carPark);
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
        public bool IsConnectedToWalkPath(WalkPath walkPath)
        {
            return ConnectedWalkPaths.Contains(walkPath);
        }

        public bool IsAccessibleFromEntrance(Entrance entrance)
        {
            return AccessibleEntrances.Contains(entrance);
        }

        public bool HasIntegratedFireSafety(FireSafety fireSafety)
        {
            return IntegratedFireSafety.Contains(fireSafety);
        }

        public bool IsNearCarPark(CarPark carPark)
        {
            return NearbyCarParks.Contains(carPark);
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
