using System;
using System.Collections.Generic;

namespace AlgoLayout.Core.Interfaces
{
    public interface IAlgorithm<TInput, TResult>
    {
        // Initialize the algorithm with necessary data
        void Initialize(TInput inputData);

        // Run the algorithm
        void Run();

        // Stop the algorithm
        void Stop();

        // Get the result of the algorithm
        TResult GetResult();

        // Check if the algorithm is running
        bool IsRunning { get; }

        // Event to notify when the algorithm is completed
        event EventHandler AlgorithmCompleted;
    }
}
