using System.Collections.Generic;

namespace AlgoLayout.Core.Models
{
    public enum RoadType
    {
        AccessRoad,
        ServiceRoad
    }

    public enum TrafficLevel
    {
        Low,
        Medium,
        High
    }

    public class Road
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoadType Type { get; set; }
        public TrafficLevel Traffic { get; set; }
        public List<MicroSite> ConnectedMicroSites { get; set; }
        public List<Entrance> ConnectedEntrances { get; set; }
        public List<WalkPath> AdjacentWalkPaths { get; set; }

        public Road(int id, string name, RoadType type, TrafficLevel traffic)
        {
            Id = id;
            Name = name;
            Type = type;
            Traffic = traffic;
            ConnectedMicroSites = new List<MicroSite>();
            ConnectedEntrances = new List<Entrance>();
            AdjacentWalkPaths = new List<WalkPath>();
        }

        // Methods to add various components
        public void AddConnectedMicroSite(MicroSite microSite)
        {
            ConnectedMicroSites.Add(microSite);
        }

        public void AddConnectedEntrance(Entrance entrance)
        {
            ConnectedEntrances.Add(entrance);
        }

        public void AddAdjacentWalkPath(WalkPath walkPath)
        {
            AdjacentWalkPaths.Add(walkPath);
        }

        // Methods to check relationships and conditions
        public bool IsConnectedToMicroSite(MicroSite microSite)
        {
            return ConnectedMicroSites.Contains(microSite);
        }

        public bool IsConnectedToEntrance(Entrance entrance)
        {
            return ConnectedEntrances.Contains(entrance);
        }

        public bool IsAdjacentToWalkPath(WalkPath walkPath)
        {
            return AdjacentWalkPaths.Contains(walkPath);
        }
    }
}
