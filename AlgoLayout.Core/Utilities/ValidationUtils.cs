using AlgoLayout.Core.GraphVisualization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoLayout.Core.Utilities
{
    public static class ValidationUtils
    {
        // Validate if a node exists in the graph
        public static bool NodeExists(Graph graph, Node node)
        {
            return graph.Nodes.Contains(node);
        }

        // Validate if an edge exists between two nodes
        public static bool EdgeExists(Graph graph, Node startNode, Node endNode)
        {
            return graph.Edges.Any(e => (e.Start == startNode && e.End == endNode) || (e.Start == endNode && e.End == startNode));
        }

        // Validate if the graph is connected
        public static bool IsGraphConnected(Graph graph)
        {
            if (graph.Nodes.Count == 0)
            {
                return false;
            }

            List<Node> visitedNodes = GraphDataPreparation.DepthFirstSearch(graph, graph.Nodes[0]);
            return visitedNodes.Count == graph.Nodes.Count;
        }

        // Validate if a node has a certain degree or higher
        public static bool NodeHasDegreeOrHigher(Graph graph, Node node, int degree)
        {
            return GraphDataPreparation.CalculateDegree(graph, node) >= degree;
        }
    }
}
