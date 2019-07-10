using System.Collections.Generic;

namespace Dijkstra.models
{
    public class Node
    {
        public int Id;
        public List<DirectedEdge> Edges;
        public int? LowestDistance;
        public bool Visited = false;

        internal Node(int id)
        {
            Id = id;
            Edges = new List<DirectedEdge>();
        }

        internal Node AddEdge(int nodeId, int value)
        {
            Edges.Add(new DirectedEdge(nodeId, value));
            return this;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
