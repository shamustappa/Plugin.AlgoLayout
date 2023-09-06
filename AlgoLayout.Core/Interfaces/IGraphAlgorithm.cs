using System;
using System.Collections.Generic;
using AlgoLayout.Core.GraphVisualization;
using AlgoLayout.Core.Utilities;  // Assuming Graph is defined in this namespace

namespace AlgoLayout.Core.Interfaces
{
    public interface IGraphAlgorithm : IAlgorithm<Graph, List<Node>>
    {
        // Additional methods specific to graph algorithms
        void SetInitialGraphState(Graph graph);
    }
}
