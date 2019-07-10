using Dijkstra.models;
using Dijkstra.util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra.Core
{
    static class DijkstraCore
    {
        public static DijkstraPath GetDijkstraPath(DirectionalGraph graph, int startId, int destinationId)
        {
            var nodes = graph.Nodes;
            var start = NodeUtil.GetNodeWithId(nodes, startId);
            var destination = NodeUtil.GetNodeWithId(nodes, destinationId);
            if (start == null || destination == null)
            {
                return null;
            }

            var accumulativeDistance = 0;
            var cur = start;
            cur.LowestDistance = 0;

            do
            {
                //3. For ea connected
                cur.Edges.ForEach(edge =>
                {
                    // set distanceFromCurrent = accumulative length + length to node
                    var distanceFromCurrent = accumulativeDistance + edge.Value;
                    //4. If node has no distance marked, or distanceFromCurrent<marked node distance...
                    var connectedNode = NodeUtil.GetNodeWithId(nodes, edge.NodeId);
                    if (!connectedNode.LowestDistance.HasValue || distanceFromCurrent < connectedNode.LowestDistance.Value)
                    {
                        // set marked node distance to distanceFromCurrent
                        connectedNode.LowestDistance = distanceFromCurrent;
                    }
                });

                //4. Once all nodes marked, mark current node as visited
                cur.Visited = true;
                //5. Stop if at destination node
                if (cur == destination)
                {
                    break;
                }
                //6. Else goto the unvisited node with lowest value
                cur = GetPrevNodeForPath(nodes);
                //7. Set accumulativeDistance = node value
                if (!cur.LowestDistance.HasValue)
                {
                    throw new ArgumentNullException("Tried to get lowestDistance value for a Node, but there was none");
                }
                accumulativeDistance = cur.LowestDistance.Value;
                //8. repeat from 3.
            } while (cur != null);

            // Get path
            return new DijkstraPath(nodes, start, destination);

            // then make it multi-threaded
        }

        // TODO: this is wrong. You get any unvisited node, even if not connected to current node
        static Node GetPrevNodeForPath(List<Node> nodes)
        {
            Node node = null;
            for (int n = 0; n < nodes.Count; n++)
            {
                var cur = nodes[n];
                var firstUnvisitedNode = (node == null && !cur.Visited);
                var currentNodeHasLowerValue = node != null && cur.LowestDistance.HasValue && node.LowestDistance.HasValue && cur.LowestDistance.Value < node.LowestDistance.Value;
                if (firstUnvisitedNode || currentNodeHasLowerValue)
                {
                    node = cur;
                }
            }
            return node;
        }

    }
}
