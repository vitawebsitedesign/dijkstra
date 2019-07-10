using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra.models
{
    class DirectionalGraph
    {
        internal List<Node> Nodes;

        internal DirectionalGraph(string graphAsJson)
        {
            var graph = JsonConvert.DeserializeObject<DeserializedGraph>(graphAsJson);
            Nodes = GetNodes(graph);
        }
        List<Node> GetNodes(DeserializedGraph graph)
        {
            var nodes = new List<Node>();
            graph.edges.ForEach((edge) =>
            {
                for (int n = 0; n < edge.nodes.Count(); n++)
                {
                    var nodeId = edge.nodes[n];
                    var node = RecordNode(nodes, nodeId);
                    RecordEdge(node, edge, n);
                }
            });
            return nodes;
        }
        Node RecordNode(List<Node> nodes, int nodeId)
        {
            var node = nodes.FirstOrDefault(n => n.Id == nodeId);
            if (node == null)
            {
                node = new Node(nodeId);
                nodes.Add(node);
            }
            return node;
        }
        void RecordEdge(Node node, DeserializedGraphEdge edge, int nodeIndex)
        {
            var otherNodeIndex = 1 - nodeIndex;
            var otherNodeId = edge.nodes[otherNodeIndex];
            node.AddEdge(otherNodeId, edge.value);
        }
    }
}
