using System;
using System.Collections.Generic;

namespace Graph
{
    /// <summary>Represents a directed unweighted graph structure
    /// </summary>
    public class Graph
    {
        // Contains the child nodes for each vertex of the graph
        // assuming that the vertices are numbered 0 ... Size-1
        private List<int>[] childNodes;
        /// <summary>Constructs an empty graph of given size</summary>
        /// <param name="size">number of vertices</param>
        public Graph(int size)
        {
            this.childNodes = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                // Assing an empty list of adjacents for each vertex
                this.childNodes[i] = new List<int>();
            }
        }
        /// <summary>Constructs a graph by given list of
        /// child nodes (successors) for each vertex</summary>
        /// <param name="childNodes">children for each node</param>
        public Graph(List<int>[] childNodes)
        {
            this.childNodes = childNodes;
        }
        /// <summary>
        /// Returns the size of the graph (number of vertices)
        /// </summary>
        public int Size
        {
            get { return this.childNodes.Length; }
        }
        /// <summary>Adds new edge from u to v</summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        public void AddEdge(int u, int v)
        {
            childNodes[u].Add(v);
        }
        /// <summary>Removes the edge from u to v if such exists
        /// </summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        public void RemoveEdge(int u, int v)
        {
            _ = childNodes[u].Remove(v);
        }
        /// <summary>
        /// Checks whether there is an edge between vertex u and v
        /// </summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        /// <returns>true if there is an edge between
        /// vertex u and vertex v</returns>
        public bool HasEdge(int u, int v)
        {
            bool hasEdge = childNodes[u].Contains(v);
            return hasEdge;
        }
        /// <summary>Returns the successors of a given vertex
        /// </summary>
        /// <param name="v">the vertex</param>
        /// <returns>list of all successors of vertex v</returns>
        public IList<int> GetSuccessors(int v)
        {
            return childNodes[v];
        }

        /// <summary>Prints the graph</summary>
        public void Print()
        {
            for (int i = 0; i < childNodes.Length; i++)
            {
                Console.Write("Vertex {0} has successors: ", i);
                foreach (int child in childNodes[i])
                {
                    Console.Write(child + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>Checks whether the graph is acyclic</summary>
        /// <returns>true if the graph is acyclic</returns>
        public bool IsAcyclic()
        {
            bool[] visited = new bool[childNodes.Length];
            bool[] onStack = new bool[childNodes.Length];
            for (int i = 0; i < childNodes.Length; i++)
            {
                if (!visited[i])
                {
                    if (IsCyclic(i, visited, onStack))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>Checks whether the graph is cyclic</summary>
        /// <returns>true if the graph is cyclic</returns>
        private bool IsCyclic(int v, bool[] visited, bool[] onStack)
        {
            visited[v] = true;
            onStack[v] = true;
            foreach (int child in childNodes[v])
            {
                if (!visited[child])
                {
                    if (IsCyclic(child, visited, onStack))
                    {
                        return true;
                    }
                }
                else if (onStack[child])
                {
                    return true;
                }
            }
            onStack[v] = false;
            return false;
        }

        /// <summary>Checks whether the graph is connected</summary>
        /// <returns>true if the graph is connected</returns>
        public bool IsConnected()
        {
            bool[] visited = new bool[childNodes.Length];
            DFS(0, visited);
            for (int i = 0; i < childNodes.Length; i++)
            {
                if (!visited[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>Performs a depth-first search starting from vertex v</summary>
        /// <param name="v">the starting vertex</param>
        /// <param name="visited">array of visited vertices</param>
        private void DFS(int v, bool[] visited)
        {
            visited[v] = true;
            foreach (int child in childNodes[v])
            {
                if (!visited[child])
                {
                    DFS(child, visited);
                }
            }
        }

        /// <summary>Checks whether the graph is strongly connected</summary>
        /// <returns>true if the graph is strongly connected</returns>
        public bool IsStronglyConnected()
        {
            if (!IsConnected())
            {
                return false;
            }
            Graph reversed = GetReversedGraph();
            return reversed.IsConnected();
        }

        /// <summary>Gets the reversed graph</summary>
        /// <returns>the reversed graph</returns>
        private Graph GetReversedGraph()
        {
            List<int>[] reversedChildNodes = new List<int>[childNodes.Length];
            for (int i = 0; i < childNodes.Length; i++)
            {
                reversedChildNodes[i] = new List<int>();
            }
            for (int i = 0; i < childNodes.Length; i++)
            {
                foreach (int child in childNodes[i])
                {
                    reversedChildNodes[child].Add(i);
                }
            }
            Graph reversed = new Graph(reversedChildNodes);
            return reversed;
        }

        /// <summary>Checks whether the graph is tree</summary>
        /// <returns>true if the graph is tree</returns>
        public bool IsTree()
        {
            if (!IsConnected())
            {
                return false;
            }
            if (!IsAcyclic())
            {
                return false;
            }
            return true;
        }

        /// <summary>Checks whether the graph is bipartite</summary>
        /// <returns>true if the graph is bipartite</returns>
        public bool IsBipartite()
        {
            int[] colors = new int[childNodes.Length];
            for (int i = 0; i < childNodes.Length; i++)
            {
                if (colors[i] == 0)
                {
                    if (!IsBipartite(i, colors))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>Checks whether the graph is bipartite</summary>
        /// <returns>true if the graph is bipartite</returns>
        private bool IsBipartite(int v, int[] colors)
        {
            colors[v] = 1;
            foreach (int child in childNodes[v])
            {
                if (colors[child] == 0)
                {
                    colors[child] = -colors[v];
                    if (!IsBipartite(child, colors))
                    {
                        return false;
                    }
                }
                else if (colors[child] == colors[v])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>Gets the number of connected components</summary>
        /// <returns>the number of connected components</returns>
        public int GetNumberOfConnectedComponents()
        {
            bool[] visited = new bool[childNodes.Length];
            int count = 0;
            for (int i = 0; i < childNodes.Length; i++)
            {
                if (!visited[i])
                {
                    DFS(i, visited);
                    count++;
                }
            }
            return count;
        }

        /// <summary>Gets the number of strongly connected components</summary>
        /// <returns>the number of strongly connected components</returns>
        public int GetNumberOfStronglyConnectedComponents()
        {
            Graph reversed = GetReversedGraph();
            bool[] visited = new bool[childNodes.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < childNodes.Length; i++)
            {
                if (!visited[i])
                {
                    reversed.DFS(i, visited, stack);
                }
            }
            visited = new bool[childNodes.Length];
            int count = 0;
            while (stack.Count > 0)
            {
                int v = stack.Pop();
                if (!visited[v])
                {
                    DFS(v, visited);
                    count++;
                }
            }
            return count;
        }

        /// <summary>Performs a depth-first search starting from vertex v</summary>
        /// <param name="v">the starting vertex</param>
        /// <param name="visited">array of visited vertices</param>
        /// <param name="stack">the stack</param>
        private void DFS(int v, bool[] visited, Stack<int> stack)
        {
            visited[v] = true;
            foreach (int child in childNodes[v])
            {
                if (!visited[child])
                {
                    DFS(child, visited, stack);
                }
            }
            stack.Push(v);
        }

        /// <summary>Gets the number of vertices</summary>
        public int NumberOfVertices
        {
            get
            {
                return childNodes.Length;
            }
        }

        /// <summary>Gets the number of edges</summary>
        public int NumberOfEdges
        {
            get
            {
                int count = 0;
                foreach (List<int> children in childNodes)
                {
                    count += children.Count;
                }
                return count;
            }
        }

        /// <summary>Gets the child nodes</summary>
        public List<int>[] ChildNodes
        {
            get
            {
                return childNodes;
            }
        }

        /// <summary>Gets the child nodes</summary>
        public List<int>[] ParentNodes
        {
            get
            {
                List<int>[] parentNodes = new List<int>[childNodes.Length];
                for (int i = 0; i < childNodes.Length; i++)
                {
                    parentNodes[i] = new List<int>();
                }
                for (int i = 0; i < childNodes.Length; i++)
                {
                    foreach (int child in childNodes[i])
                    {
                        parentNodes[child].Add(i);
                    }
                }
                return parentNodes;
            }
        }

        /// <summary>Gets the adjacency matrix</summary>
        public int[,] AdjacencyMatrix
        {
            get
            {
                int[,] matrix = new int[childNodes.Length, childNodes.Length];
                for (int i = 0; i < childNodes.Length; i++)
                {
                    foreach (int child in childNodes[i])
                    {
                        matrix[i, child] = 1;
                    }
                }
                return matrix;
            }
        }

        /// <summary>Gets the adjacency list</summary>
        public List<int>[] AdjacencyList
        {
            get
            {
                return childNodes;
            }
        }

        /// <summary>Gets the incidence matrix</summary>
        public int[,] IncidenceMatrix
        {
            get
            {
                int[,] matrix = new int[childNodes.Length, NumberOfEdges];
                int edge = 0;
                for (int i = 0; i < childNodes.Length; i++)
                {
                    foreach (int child in childNodes[i])
                    {
                        matrix[i, edge] = 1;
                        matrix[child, edge] = -1;
                        edge++;
                    }
                }
                return matrix;
            }
        }

        /// <summary>Gets the shortest path between two vertices</summary>
        /// <param name="start">the starting vertex</param>
        /// <param name="end">the ending vertex</param>
        /// <returns>the shortest path</returns>
        public List<int> GetShortestPath(int start, int end)
        {
            int[] distances = new int[childNodes.Length];
            int[] previous = new int[childNodes.Length];
            for (int i = 0; i < childNodes.Length; i++)
            {
                distances[i] = int.MaxValue;
                previous[i] = -1;
            }
            distances[start] = 0;
            bool[] visited = new bool[childNodes.Length];
            for (int i = 0; i < childNodes.Length; i++)
            {
                int min = int.MaxValue;
                int minIndex = -1;
                for (int j = 0; j < childNodes.Length; j++)
                {
                    if (!visited[j] && distances[j] < min)
                    {
                        min = distances[j];
                        minIndex = j;
                    }
                }
                if (minIndex == -1)
                {
                    break;
                }
                visited[minIndex] = true;
                foreach (int child in childNodes[minIndex])
                {
                    if (distances[child] > distances[minIndex] + 1)
                    {
                        distances[child] = distances[minIndex] + 1;
                        previous[child] = minIndex;
                    }
                }
            }
            List<int> path = new List<int>();
            int current = end;
            while (current != -1)
            {
                path.Add(current);
                current = previous[current];
            }
            path.Reverse();
            return path;
        }
    }
}
