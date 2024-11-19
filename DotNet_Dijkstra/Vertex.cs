namespace Vertices;

public class Vertex(string name) : IComparable<Vertex>{
    public string name = name; //public for testing purposes
    public int dist = int.MaxValue;
    public Vertex? prev = null;
    //public bool vistited = false;
    //int index; //not sure if i need this
    public List<Edge> OutEdge = new List<Edge>(); //might need to be public

    public int CompareTo(Vertex vertex){
        return dist.CompareTo(vertex.dist); //"this" might be redundant
    }

    public class Edge{
        Vertex from;
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