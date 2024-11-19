using System.Security.Cryptography.X509Certificates;
using Vertices;
namespace Classes;

public class AdjacencyGraph{
    List<Vertex> Vertices;
    int lenght;
    public AdjacencyGraph(){
        Vertices = new List<Vertex>();
    }
    public void addVertex(Vertex vertex){
        Vertices.Add(vertex);
    }
    public void addEdge(Vertex from, Vertex to, int weight){ //adds a edge in one direction
        if(!(Vertices.Contains(from) && Vertices.Contains(to))){
            Console.WriteLine("Vertices are missing from the graph");
            return;
        }
        Vertex.Edge newEdge = new Vertex.Edge(from, to, weight);
    }
    public void addUndirectedEdge(Vertex from, Vertex to, int weight){ //adds a edge in both directions
       if(!(Vertices.Contains(from) && Vertices.Contains(to))){
            Console.WriteLine("Vertices are missing from the graph");
            return;
        }
        Vertex.Edge newEdge1 = new Vertex.Edge(from, to, weight);
        Vertex.Edge newEdge2 = new Vertex.Edge(to, from, weight);
        //Console.WriteLine($"made a Edge between {from.name} and {to.name}");
    }
    public void AdjacencyGraphMST(){
        MinHeap<Vertex> que = new MinHeap<Vertex>();
        foreach(Vertex vertex in Vertices){
            que.Insert(vertex);
        }
        Vertex startPoint = que.viewMin();
        startPoint.dist = 0;
        while (!que.isEmpty()){
            Vertex step = que.extractMin();
            foreach(Vertex.Edge edge in step.OutEdge){
                Vertex to = edge.to;
                int distFromStart = edge.weight + step.dist;
                if( distFromStart < to.dist){     //might not need to make the visited thing
                    to.prev = step;
                    to.dist = distFromStart;
                }
            }
        }
        
    }
    public void PrintGraph(){
        foreach(Vertex vertex in Vertices){
            lenght += vertex.dist;
            if (vertex.prev != null){
                Console.WriteLine($"from {vertex.prev.name} to {vertex.name}");
            }
        }
        Console.WriteLine($"total distance of the thing is {lenght}");
    }

}
