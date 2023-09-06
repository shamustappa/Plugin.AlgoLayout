using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoLayout.Core.GraphVisualization
{
    public static class GraphingAlgorithm
    {
        // Depth-First Search (DFS)
        public static List<Node> DepthFirstSearch(Graph graph, Node startNode)
        {
            List<Node> visitedNodes = new List<Node>();
            Stack<Node> stack = new Stack<Node>();
            stack.Push(startNode);

            while (stack.Count > 0)
            {
                Node currentNode = stack.Pop();
                if (!visitedNodes.Contains(currentNode))
                {
                    visitedNodes.Add(currentNode);
                    List<Node> neighbors = GraphDataPreparation.FindNeighbors(graph, currentNode);
                    foreach (Node neighbor in neighbors)
                    {
                        stack.Push(neighbor);
                    }
                }
            }
            return visitedNodes;
        }

        // Breadth-First Search (BFS)
        public static List<Node> BreadthFirstSearch(Graph graph, Node startNode)
        {
            List<Node> visitedNodes = new List<Node>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();
                if (!visitedNodes.Contains(currentNode))
                {
                    visitedNodes.Add(currentNode);
                    List<Node> neighbors = GraphDataPreparation.FindNeighbors(graph, currentNode);
                    foreach (Node neighbor in neighbors)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return visitedNodes;
        }

        // Dijkstra's Shortest Path Algorithm
        public static List<Node> DijkstraShortestPath(Graph graph, Node startNode, Node endNode)
        {
            Dictionary<Node, double> distances = new Dictionary<Node, double>();
            Dictionary<Node, Node> previousNodes = new Dictionary<Node, Node>();
            List<Node> unvisited = new List<Node>();

            foreach (Node node in graph.Nodes)
            {
                distances[node] = double.MaxValue;
                previousNodes[node] = null;
                unvisited.Add(node);
            }
            distances[startNode] = 0;

            while (unvisited.Count > 0)
            {
                Node currentNode = unvisited.OrderBy(n => distances[n]).First();
                unvisited.Remove(currentNode);

                if (currentNode == endNode)
                {
                    List<Node> path = new List<Node>();
                    while (previousNodes[currentNode] != null)
                    {
                        path.Insert(0, currentNode);
                        currentNode = previousNodes[currentNode];
                    }
                    return path;
                }

                List<Node> neighbors = GraphDataPreparation.FindNeighbors(graph, currentNode);
                foreach (Node neighbor in neighbors)
                {
                    double tentativeDistance = distances[currentNode] + 1; // Assuming edge weight is 1
                    if (tentativeDistance < distances[neighbor])
                    {
                        distances[neighbor] = tentativeDistance;
                        previousNodes[neighbor] = currentNode;
                    }
                }
            }
            return null; // No path found
        }
    }
}
