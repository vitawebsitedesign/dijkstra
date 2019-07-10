namespace Dijkstra.models
{
    public class DirectedEdge
    {
        public int NodeId;
        public int Value;

        internal DirectedEdge(int nodeId, int value)
        {
            NodeId = nodeId;
            Value = value;
        }
    }
}
