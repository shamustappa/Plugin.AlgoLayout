using System;
using System.Collections.Generic;

namespace AlgoLayout.Core.GraphVisualization
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Edge
    {
        public Node Start { get; set; }
        public Node End { get; set; }
        public double Weight { get; set; }
    }

    public class Graph
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Edge> Edges { get; set; } = new List<Edge>();
    }

    public static class GraphDataPreparation
    {
        // Add a node to the graph
        public static void AddNode(Graph graph, Node node)
        {
            graph.Nodes.Add(node);
        }

        // Add an edge to the graph
        public static void AddEdge(Graph graph, Edge edge)
        {
            graph.Edges.Add(edge);
        }

        // Remove a node from the graph
        public static void RemoveNode(Graph graph, Node node)
        {
            graph.Nodes.Remove(node);
            graph.Edges.RemoveAll(e => e.Start == node || e.End == node);
        }

        // Remove an edge from the graph
        public static void RemoveEdge(Graph graph, Edge edge)
        {
            graph.Edges.Remove(edge);
        }

        // Find neighbors of a node
        public static List<Node> FindNeighbors(Graph graph, Node node)
        {
            List<Node> neighbors = new List<Node>();
            foreach (var edge in graph.Edges)
            {
                if (edge.Start == node)
                {
                    neighbors.Add(edge.End);
                }
                else if (edge.End == node)
                {
                    neighbors.Add(edge.Start);
                }
            }
            return neighbors;
        }

        // Calculate the degree of a node
        public static int CalculateDegree(Graph graph, Node node)
        {
            return FindNeighbors(graph, node).Count;
        }

        // Check if the graph is connected
        public static bool IsConnected(Graph graph)
        {
            // Implementation for checking graph connectivity
            return true; // Placeholder
        }
    }
}
