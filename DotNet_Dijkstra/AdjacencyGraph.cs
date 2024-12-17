using System.Security.Cryptography.X509Certificates;
using Vertices;
namespace Classes;

public class AdjacencyGraph{
    List<Vertex> Vertices;
    int lenght;
    public AdjacencyGraph(){
        Vertices = new List<Vertex>();
    }
    public void printVertices(){
        foreach(Vertex vertex in Vertices){
            Console.WriteLine($"vertex: {vertex.name}");
        }
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
                if((to.dist > step.dist + edge.weight) && !to.vistited){     //if the to vertex is greater
                    to.prev = step;
                    to.dist = step.dist + edge.weight;
                    int pos = que.getPositon(to);
                    que.decreaseKey(pos);
                    to.incEdge = edge;
                }
            }
            step.vistited = true;
        } 
    }
    public void PrintGraph(){ //gets the entire graph shows all the vertices and their conctions
        foreach(Vertex vertex in Vertices){ //goes through the vertices
            Console.WriteLine($"vertex {vertex.name} is connected to");
            foreach(Vertex.Edge edge in vertex.OutEdge){ //goes through the Edges of each vertex
                Console.WriteLine($"   vertex {edge.to.name} with dist {edge.weight}");
            }
        }
    }
    public void getMST(){ // prints the MST after generating it with the AdjacencyGraphMST() or debugAdjacencyGraphMST()
        foreach(Vertex vertex in Vertices){
            if (vertex.prev != null){
                Console.WriteLine($"vertex {vertex.name} is connected to {vertex.prev.name}");
            }
            if(vertex.incEdge != null){ // adds all the inc edges together to get the total lenght
                lenght += vertex.incEdge.weight;
            }
        }
        Console.WriteLine($"total distance spanned {lenght}"); //prints the total length
    }


    public void debugAdjacencyGraphMST(){ //makes the MST while printing each step, mainly used for debugging
        MinHeap<Vertex> que = new MinHeap<Vertex>();
        foreach(Vertex vertex in Vertices){
            que.Insert(vertex);
        }
        Vertex startPoint = que.viewMin();
        startPoint.dist = 0;
        Console.WriteLine($"startpoint: {startPoint.dist}");
        Console.WriteLine($"startpoint name: {startPoint.name}");
        while (!que.isEmpty()){
            Vertex step = que.extractMin();
            Console.WriteLine($"step name: {step.name}");
            Console.WriteLine($"step dist: {step.dist}");
            foreach(Vertex.Edge edge in step.OutEdge){
                Vertex to = edge.to;
                Console.WriteLine($"    edge weight: {edge.weight}");
                Console.WriteLine($"    before if name: {to.name}");
                Console.WriteLine($"    before if: {to.dist}");
                if((to.dist > step.dist + edge.weight) && !to.vistited){
                    to.prev = step;
                    to.dist = step.dist + edge.weight;
                    Console.WriteLine($"        to dist: {to.dist}");
                    Console.WriteLine($"        if name: {to.name}");
                    int pos = que.getPositon(to);
                    que.decreaseKey(pos);
                }
            step.vistited = true;
            }
            Console.WriteLine($"final name: {step.name}");
            Console.WriteLine($"final dist: {step.dist}");
        } 
    }
}
