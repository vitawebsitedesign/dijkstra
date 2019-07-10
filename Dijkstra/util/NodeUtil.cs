using Dijkstra.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra.util
{
    static class NodeUtil
    {
        internal static Node GetNodeWithId(List<Node> nodes, int id)
        {
            var node = nodes.FirstOrDefault(n => n.Id == id);
            if (node == null)
            {
                throw new NullReferenceException($"Failed to get node with id: {id}");
            }
            return node;
        }
    }
}
