using Dijkstra.models;
using System;
using System.Configuration;
using System.IO;

namespace Dijkstra
{
    static class FileUtil
    {
        static string _graphExamplesDirKey = "GraphExamplesDir";

        public static DirectionalGraph GetExampleGraph(string graphFilenameKey)
        {
            // Get filename from appcommon
            var root = GetRoot();
            var graphExamplesDir = ConfigurationManager.AppSettings[_graphExamplesDirKey];
            var filename = ConfigurationManager.AppSettings[graphFilenameKey];
            var path = Path.Combine(root, graphExamplesDir, filename);
            // If exists
            if (File.Exists(path))
            {
                // Load it
                var json = File.ReadAllText(path);
                // Return graph data in c# data format
                return new DirectionalGraph(json);
            }
            // Endif

            // Return null
            return null;
        }

        static string GetRoot()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        }
    }
}
