using Dijkstra.util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra.models
{
    class DijkstraPath
    {
        List<int> _path;

        internal DijkstraPath(List<Node> nodes, Node start, Node destination)
        {
            _path = GetDijkstraPath(nodes, start, destination);
        }
        internal List<int> GetDijkstraPath(List<Node> nodes, Node start, Node destination)
        {
            var path = new Stack<Node>();
            var cur = destination;
            do
            {
                //1. Pop current node onto stack
                path.Push(cur);
                //2. Stop if at start node
                if (cur == start)
                {
                    break;
                }
                //3. Else goto prev node w/ lowest value, repeat from 1.
                cur = GetPrevWithLowestValue(nodes, cur);
            } while (cur != null);

            return path.Select(n => n.Id).ToList();
        }
        internal void Print(Action<string> write)
        {
            _path.ForEach(n => write(n.ToString()));
        }
        static Node GetPrevWithLowestValue(List<Node> nodes, Node fromNode)
        {
            // For ea prev
            Node nodeWithLowestValue = null;
            var edges = fromNode.Edges;
            for (int e = 0; e < edges.Count; e++)
            {
                var connectedNodeId = edges[e].NodeId;
                var connectedNode = NodeUtil.GetNodeWithId(nodes, connectedNodeId);
                var prevNodeValue = connectedNode.LowestDistance;
                if (nodeWithLowestValue == null || (prevNodeValue.HasValue && prevNodeValue.Value < nodeWithLowestValue.LowestDistance))
                {
                    nodeWithLowestValue = connectedNode;
                }
            }

            // Return one with lowest val
            return nodeWithLowestValue;
        }
    }
}
