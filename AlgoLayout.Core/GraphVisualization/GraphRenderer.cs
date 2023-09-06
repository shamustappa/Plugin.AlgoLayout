using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace AlgoLayout.Core.GraphVisualization
{
    public class GraphRenderer
    {
        // Render nodes on a canvas
        public static void RenderNodes(Canvas canvas, Graph graph)
        {
            foreach (Node node in graph.Nodes)
            {
                Ellipse ellipse = new Ellipse
                {
                    Width = 20,
                    Height = 20,
                    Fill = Brushes.Blue
                };

                Canvas.SetLeft(ellipse, node.Id * 50); // Assuming node.Id can be used for positioning
                Canvas.SetTop(ellipse, node.Id * 50); // Assuming node.Id can be used for positioning

                canvas.Children.Add(ellipse);
            }
        }

        // Render edges on a canvas
        public static void RenderEdges(Canvas canvas, Graph graph)
        {
            foreach (Edge edge in graph.Edges)
            {
                Line line = new Line
                {
                    X1 = edge.Start.Id * 50, // Assuming node.Id can be used for positioning
                    Y1 = edge.Start.Id * 50, // Assuming node.Id can be used for positioning
                    X2 = edge.End.Id * 50,   // Assuming node.Id can be used for positioning
                    Y2 = edge.End.Id * 50,   // Assuming node.Id can be used for positioning
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                canvas.Children.Add(line);
            }
        }

        // Update the canvas
        public static void UpdateCanvas(Canvas canvas, Graph graph)
        {
            canvas.Children.Clear();
            RenderNodes(canvas, graph);
            RenderEdges(canvas, graph);
        }
    }
}
