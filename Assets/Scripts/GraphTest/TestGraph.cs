using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class TestGraph : MonoBehaviour
{
    public int source = 1;
    public int target = 9;
    SparseGraph<GraphNode, GraphEdge> m_Graph = new SparseGraph<GraphNode, GraphEdge>();
    void Start()
    {
        for (int i = 0; i < 11; i++)
        {
            m_Graph.AddNode(new GraphNode(i));
        }
        m_Graph.AddEdge(new GraphEdge(0, 1, 0));
        m_Graph.AddEdge(new GraphEdge(1, 2, 0));
        m_Graph.AddEdge(new GraphEdge(1, 3, 0));
        m_Graph.AddEdge(new GraphEdge(2, 4, 0));
        m_Graph.AddEdge(new GraphEdge(2, 5, 0));
        m_Graph.AddEdge(new GraphEdge(3, 6, 0));
        m_Graph.AddEdge(new GraphEdge(3, 7, 0));
        m_Graph.AddEdge(new GraphEdge(4, 8, 0));
        m_Graph.AddEdge(new GraphEdge(4, 9, 0));
        m_Graph.AddEdge(new GraphEdge(9, 10, 0));

        Search_DFS(m_Graph, source, target);
        Search_BFS(m_Graph, source, target);
    }

    public void Search_DFS(SparseGraph<GraphNode, GraphEdge> _graph, int _source, int target)
    {
        Graph_Search_DFS<GraphNode, GraphEdge> DFSSearcher = new Graph_Search_DFS<GraphNode, GraphEdge>(m_Graph, source, target);
        if (DFSSearcher.IsFound())
        {
            var route = DFSSearcher.GetPathToTarget();
            PrintRoute(route);
        }
    }
    public void Search_BFS(SparseGraph<GraphNode, GraphEdge> _graph, int _source, int target)
    {
        Graph_Search_BFS<GraphNode, GraphEdge> DFSSearcher = new Graph_Search_BFS<GraphNode, GraphEdge>(m_Graph, source, target);
        if (DFSSearcher.IsFound())
        {
            var route = DFSSearcher.GetPathToTarget();
            PrintRoute(route);
        }
    }

    public void PrintRoute(List<int> route)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < route.Count; i++)
        {
            sb.Append(route[i]);
            if (i != route.Count - 1)
            {
                sb.Append("<-");
            }
        }
        Debug.Log(sb.ToString());
    }
}
