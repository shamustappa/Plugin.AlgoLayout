using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum ServiceType
    {
        SewerageDrainage,
        ElectricalSystem,
        WaterSupply,
        GasSupply,
        Telecommunications
    }

    public class Services
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ServiceType Type { get; set; }
        public List<Room> ServicedRooms { get; set; } // List of rooms serviced by this utility service
        public List<Entrance> AccessibleEntrances { get; set; } // List of entrances accessible from this utility service
        public List<FireSafety> IntegratedFireSafety { get; set; } // List of integrated fire safety measures
        public List<CarPark> ServicedCarParks { get; set; } // List of car parks serviced by this utility service
        public List<Transportation> IntegratedTransportation { get; set; } // List of integrated transportation systems
        public List<MEP> IntegratedMEP { get; set; } // List of integrated MEP systems

        public Services(int id, string name, ServiceType type)
        {
            Id = id;
            Name = name;
            Type = type;
            ServicedRooms = new List<Room>();
            AccessibleEntrances = new List<Entrance>();
            IntegratedFireSafety = new List<FireSafety>();
            ServicedCarParks = new List<CarPark>();
            IntegratedTransportation = new List<Transportation>();
            IntegratedMEP = new List<MEP>();
        }

        // Methods to add various components
        public void AddServicedRoom(Room room)
        {
            ServicedRooms.Add(room);
        }

        public void AddAccessibleEntrance(Entrance entrance)
        {
            AccessibleEntrances.Add(entrance);
        }

        public void AddIntegratedFireSafety(FireSafety fireSafety)
        {
            IntegratedFireSafety.Add(fireSafety);
        }

        public void AddServicedCarPark(CarPark carPark)
        {
            ServicedCarParks.Add(carPark);
        }

        public void AddIntegratedTransportation(Transportation transportation)
        {
            IntegratedTransportation.Add(transportation);
        }

        public void AddIntegratedMEP(MEP mep)
        {
            IntegratedMEP.Add(mep);
        }

        // Methods to check relationships and conditions
        public bool ServicesRoom(Room room)
        {
            return ServicedRooms.Contains(room);
        }

        public bool IsAccessibleFromEntrance(Entrance entrance)
        {
            return AccessibleEntrances.Contains(entrance);
        }

        public bool HasIntegratedFireSafety(FireSafety fireSafety)
        {
            return IntegratedFireSafety.Contains(fireSafety);
        }

        public bool ServicesCarPark(CarPark carPark)
        {
            return ServicedCarParks.Contains(carPark);
        }

        public bool HasIntegratedTransportation(Transportation transportation)
        {
            return IntegratedTransportation.Contains(transportation);
        }

        public bool HasIntegratedMEP(MEP mep)
        {
            return IntegratedMEP.Contains(mep);
        }
    }
}
