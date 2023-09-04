using Rhino;
using Rhino.Commands;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.Algorithms;

namespace AlgoLayout.RhinoPlugin.Commands
{
    public class RunLayoutOptimizationCommand : Command
    {
        static RunLayoutOptimizationCommand _instance;
        public RunLayoutOptimizationCommand()
        {
            _instance = this;
        }

        ///<summary>The only instance of the RunLayoutOptimizationCommand command.</summary>
        public static RunLayoutOptimizationCommand Instance
        {
            get { return _instance; }
        }

        public override string EnglishName
        {
            get { return "RunLayoutOptimization"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // Initialize a new Layout object
            Layout layout = new Layout();

            // Add rooms, walk paths, etc. to the layout (this could be read from the Rhino document or user input)
            // ...

            // Run optimization algorithms
            GeneticAlgorithmOptimizer gaOptimizer = new GeneticAlgorithmOptimizer();
            DijkstraOptimizer dijkstraOptimizer = new DijkstraOptimizer();
            GreedyOptimizer greedyOptimizer = new GreedyOptimizer();

            layout = gaOptimizer.Optimize(layout);
            layout = dijkstraOptimizer.Optimize(layout);
            layout = greedyOptimizer.Optimize(layout);

            // Update the Rhino document with the optimized layout
            // ...

            return Result.Success;
        }
    }
}