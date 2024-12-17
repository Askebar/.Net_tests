namespace Vertices;

public class Vertex(string name) : IComparable<Vertex>{
    public string name = name; //public for testing purposes
    public int dist = int.MaxValue; //distance from the start vertex
    public Vertex? prev = null; // variable for keeping the previous vertex used to get the route
    public bool vistited = false; //variable to check if the vertex have been through the que to avoid extra checks
    public Edge? incEdge = null; // variable to keep the inc edge, used to get the total lenght of the route

    public List<Edge> OutEdge = new List<Edge>(); //list of all the edges of the vertex

    public int CompareTo(Vertex vertex){ // from the IComparable that lets me use the generic MinHeap with the verteices
        return dist.CompareTo(vertex.dist); 
    }

    public class Edge{
        Vertex from; //havent used since im using a undircedted graph
        public Vertex to;
        public int weight;
        public Edge(Vertex from, Vertex to, int weight){
            this.from = from;
            this.to = to;
            this.weight = weight;
            from.OutEdge.Add(this);
        }
    }
}