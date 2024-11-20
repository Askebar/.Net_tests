using Classes;
using Vertices;


AdjacencyGraph graph = new AdjacencyGraph();


Vertex start = new Vertex("start");
start.dist = 0;

Vertex seven = new Vertex("7");
Vertex nine = new Vertex("9");
Vertex eleven = new Vertex("11");
Vertex twenty1 = new Vertex("20 top");
Vertex twenty2 = new Vertex("20 bot");

graph.addVertex(start);
graph.addVertex(seven);
graph.addVertex(nine);
graph.addVertex(eleven);
graph.addVertex(twenty1);
graph.addVertex(twenty2);

graph.addUndirectedEdge(start, nine, 9);
graph.addUndirectedEdge(start, seven, 7);
graph.addUndirectedEdge(start, eleven, 14);
graph.addUndirectedEdge(seven, nine, 10);
graph.addUndirectedEdge(seven, twenty2, 15);
graph.addUndirectedEdge(nine, twenty2, 11);
graph.addUndirectedEdge(nine, eleven, 2);
graph.addUndirectedEdge(eleven, twenty1, 9);
graph.addUndirectedEdge(twenty1, twenty2, 9);
/*
Vertex Eskildstrup = new Vertex("Eskildstrup");
Vertex Haslev=new Vertex("Haslev");
Vertex Holbæk=new Vertex("Holbæk");
Vertex Jærgerspris=new Vertex("Jærgerspris");
Vertex Kalundborg=new Vertex("Kalundborg");
Vertex Korsør=new Vertex("Korsør");
Vertex Køge=new Vertex("Køge");
Vertex Maribo=new Vertex("Maribo");
Vertex Næstved=new Vertex("Næstved");
Vertex Ringsted=new Vertex("Ringsted");
Vertex Slagelse=new Vertex("Slagelse");
Vertex NykøbingF=new Vertex("Nykøbing F");
Vertex Vordingborg=new Vertex("Vordingborg");
Vertex Roskilde=new Vertex("Roskilde");
Vertex Sorø=new Vertex("Sorø");
Vertex Nakskov=new Vertex("Nakskov");

graph.addVertex(Eskildstrup);
graph.addVertex(Haslev);
graph.addVertex(Holbæk);
graph.addVertex(Jærgerspris);
graph.addVertex(Kalundborg);
graph.addVertex(Korsør);
graph.addVertex(Køge);
graph.addVertex(Maribo);
graph.addVertex(Næstved);
graph.addVertex(Ringsted);
graph.addVertex(Slagelse);
graph.addVertex(NykøbingF);
graph.addVertex(Vordingborg);
graph.addVertex(Roskilde);
graph.addVertex(Sorø);
graph.addVertex(Nakskov);


graph.addUndirectedEdge(Eskildstrup, Maribo, 28);
graph.addUndirectedEdge(Eskildstrup, NykøbingF, 13);
graph.addUndirectedEdge(Eskildstrup, Vordingborg, 24);
graph.addUndirectedEdge(Haslev, Korsør, 60);
graph.addUndirectedEdge(Haslev, Køge, 24);
graph.addUndirectedEdge(Haslev, Næstved, 25);
graph.addUndirectedEdge(Haslev, Ringsted, 19);
graph.addUndirectedEdge(Haslev, Roskilde, 47);
graph.addUndirectedEdge(Haslev, Slagelse, 48);
graph.addUndirectedEdge(Haslev, Sorø, 34);
graph.addUndirectedEdge(Haslev, Vordingborg, 40);
graph.addUndirectedEdge(Holbæk, Jærgerspris, 34);
graph.addUndirectedEdge(Holbæk, Kalundborg, 44);
graph.addUndirectedEdge(Holbæk, Korsør, 66);
graph.addUndirectedEdge(Holbæk, Ringsted, 36);
graph.addUndirectedEdge(Holbæk, Roskilde, 32);
graph.addUndirectedEdge(Holbæk, Slagelse, 46);
graph.addUndirectedEdge(Holbæk, Sorø, 34);
graph.addUndirectedEdge(Jærgerspris, Korsør, 95);
graph.addUndirectedEdge(Jærgerspris, Køge, 58);
graph.addUndirectedEdge(Jærgerspris, Ringsted, 56);
graph.addUndirectedEdge(Jærgerspris, Roskilde, 33);
graph.addUndirectedEdge(Jærgerspris, Slagelse, 74);
graph.addUndirectedEdge(Jærgerspris, Sorø, 63);
graph.addUndirectedEdge(Kalundborg, Ringsted, 62);
graph.addUndirectedEdge(Kalundborg, Roskilde, 70);
graph.addUndirectedEdge(Kalundborg, Slagelse, 39);
graph.addUndirectedEdge(Kalundborg, Sorø, 51);
graph.addUndirectedEdge(Korsør, Næstved, 45);
graph.addUndirectedEdge(Korsør, Slagelse, 20);
graph.addUndirectedEdge(Køge, Næstved, 45);
graph.addUndirectedEdge(Køge, Ringsted, 28);
graph.addUndirectedEdge(Køge, Roskilde, 25);
graph.addUndirectedEdge(Køge, Vordingborg, 60);
graph.addUndirectedEdge(Maribo, Nakskov, 27);
graph.addUndirectedEdge(Maribo, NykøbingF, 26);
graph.addUndirectedEdge(Næstved, Roskilde, 57);
graph.addUndirectedEdge(Næstved, Ringsted, 26);
graph.addUndirectedEdge(Næstved, Slagelse, 37);
graph.addUndirectedEdge(Næstved, Sorø, 32);
graph.addUndirectedEdge(Næstved, Vordingborg, 28);
graph.addUndirectedEdge(Ringsted, Roskilde, 31);
graph.addUndirectedEdge(Ringsted, Sorø, 15);
graph.addUndirectedEdge(Ringsted, Vordingborg, 58);
graph.addUndirectedEdge(Slagelse, Sorø, 14);

*/ 
graph.AdjacencyGraphMST();
//graph.PrintGraph();
graph.getMST();


//Console.WriteLine($"{otherPlace.CompareTo(otherPlace)}");