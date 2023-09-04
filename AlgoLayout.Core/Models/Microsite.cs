using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum MicroSiteType
    {
        Courtyard,
        Garden,
        SmallPark,
        Plaza
    }

    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    public enum ZoningType
    {
        Residential,
        Commercial,
        Industrial,
        MixedUse
    }

    public enum TrafficLevel
    {
        Low,
        Medium,
        High
    }

    public class MicroSite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MicroSiteType SiteType { get; set; }
        public Direction SiteDirection { get; set; }
        public ZoningType Zoning { get; set; }
        public string NeighborhoodContext { get; set; }
        public TrafficLevel Traffic { get; set; }
        public List<Room> AdjacentRooms { get; set; }
        public List<WalkPath> MicroSiteRoutes { get; set; }
        public List<Entrance> Entrances { get; set; }
        public List<Road> AccessRoads { get; set; }
        public List<Road> ServiceRoads { get; set; }

        public MicroSite(int id, string name, MicroSiteType siteType, Direction direction, ZoningType zoning, string neighborhoodContext, TrafficLevel traffic)
        {
            Id = id;
            Name = name;
            SiteType = siteType;
            SiteDirection = direction;
            Zoning = zoning;
            NeighborhoodContext = neighborhoodContext;
            Traffic = traffic;
            AdjacentRooms = new List<Room>();
            MicroSiteRoutes = new List<WalkPath>();
            Entrances = new List<Entrance>();
            AccessRoads = new List<Road>();
            ServiceRoads = new List<Road>();
        }

        // Methods to add various components
        public void AddAdjacentRoom(Room room)
        {
            AdjacentRooms.Add(room);
        }

        public void AddMicroSiteRoute(WalkPath walkPath)
        {
            MicroSiteRoutes.Add(walkPath);
        }

        public void AddEntrance(Entrance entrance)
        {
            Entrances.Add(entrance);
        }

        public void AddAccessRoad(Road road)
        {
            AccessRoads.Add(road);
        }

        public void AddServiceRoad(Road road)
        {
            ServiceRoads.Add(road);
        }

        // Methods to check relationships and conditions
        public bool IsAdjacentToRoom(Room room)
        {
            return AdjacentRooms.Contains(room);
        }

        public bool IsPartOfRoute(WalkPath walkPath)
        {
            return MicroSiteRoutes.Contains(walkPath);
        }
    }
}
