using Dijkstra.Core;
using System;

namespace Dijkstra
{
    class Program
    {
        static string _graphFilenameKey = "GraphFilename";

        static void Main(string[] args)
        {
            var graph = FileUtil.GetExampleGraph(_graphFilenameKey);
            if (graph == null)
            {
                Console.WriteLine($"Failed to get graph (does the graph file exist?)");
                Environment.Exit(1);
            }
            DijkstraCore.GetDijkstraPath(graph, 1, 4).Print(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
