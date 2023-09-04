using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum MEPType
    {
        HVAC, // Heating, Ventilation, and Air Conditioning
        Electrical,
        Plumbing,
        FireProtection
    }

    public class MEP
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MEPType Type { get; set; }
        public List<Room> ServicedRooms { get; set; } // List of rooms serviced by this MEP system
        public List<Entrance> AccessibleEntrances { get; set; } // List of entrances accessible from this MEP system
        public List<FireSafety> IntegratedFireSafety { get; set; } // List of integrated fire safety measures
        public List<CarPark> ServicedCarParks { get; set; } // List of car parks serviced by this MEP system

        public MEP(int id, string name, MEPType type)
        {
            Id = id;
            Name = name;
            Type = type;
            ServicedRooms = new List<Room>();
            AccessibleEntrances = new List<Entrance>();
            IntegratedFireSafety = new List<FireSafety>();
            ServicedCarParks = new List<CarPark>();
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
    }
}
