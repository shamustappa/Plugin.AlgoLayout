using ArchitecturalLayout.Core.Models;
using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum EntranceType
    {
        MainEntrance,
        SideEntrance,
        EmergencyExit
    }

    public class Entrance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EntranceType Type { get; set; }
        public double Width { get; set; } // in meters
        public double Height { get; set; } // in meters
        public List<Room> ConnectedRooms { get; set; }
        public List<CarPark> AccessibleCarParks { get; set; }
        public List<FireSafety> FireSafetyMeasures { get; set; }
        public List<MEP> MepSystems { get; set; }
        public List<Service> BuildingServices { get; set; }
        public List<Transportation> BuildingTransport { get; set; }
        public List<WalkPath> WalkPaths { get; set; }
        public List<OutdoorView> OutdoorViews { get; set; }
        public List<Microsite> Microsites { get; set; }

        public Entrance(int id, string name, EntranceType type, double width, double height)
        {
            Id = id;
            Name = name;
            Type = type;
            Width = width;
            Height = height;
            ConnectedRooms = new List<Room>();
            AccessibleCarParks = new List<CarPark>();
            FireSafetyMeasures = new List<FireSafety>();
            MepSystems = new List<MEP>();
            BuildingServices = new List<Service>();
            BuildingTransport = new List<Transportation>();
            WalkPaths = new List<WalkPath>();
            OutdoorViews = new List<OutdoorView>();
            Microsites = new List<Microsite>();
        }

        // Methods to add various components
        public void AddConnectedRoom(Room room) => ConnectedRooms.Add(room);
        public void AddAccessibleCarPark(CarPark carPark) => AccessibleCarParks.Add(carPark);
        public void AddFireSafetyMeasure(FireSafety fireSafety) => FireSafetyMeasures.Add(fireSafety);
        public void AddMepSystem(MEP mep) => MepSystems.Add(mep);
        public void AddBuildingService(Service service) => BuildingServices.Add(service);
        public void AddBuildingTransport(Transportation transport) => BuildingTransport.Add(transport);
        public void AddWalkPath(WalkPath walkPath) => WalkPaths.Add(walkPath);
        public void AddOutdoorView(OutdoorView outdoorView) => OutdoorViews.Add(outdoorView);
        public void AddMicrosite(MicroSite microsite) => Microsites.Add(microsite);

        // Methods to check relationships
        public bool IsConnectedToRoom(Room room) => ConnectedRooms.Contains(room);
        public bool IsAccessibleToCarPark(CarPark carPark) => AccessibleCarParks.Contains(carPark);
        public bool HasFireSafetyMeasure(FireSafety fireSafety) => FireSafetyMeasures.Contains(fireSafety);
        public bool HasMepSystem(MEP mep) => MepSystems.Contains(mep);
        public bool HasBuildingService(Service service) => BuildingServices.Contains(service);
        public bool HasBuildingTransport(Transportation transport) => BuildingTransport.Contains(transport);
        public bool HasWalkPath(WalkPath walkPath) => WalkPaths.Contains(walkPath);
        public bool HasOutdoorView(OutdoorView outdoorView) => OutdoorViews.Contains(outdoorView);
        public bool HasMicrosite(MicroSite microsite) => Microsites.Contains(microsite);
    }
}
