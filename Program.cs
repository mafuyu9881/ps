using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int n = tokens[0];
        int m = tokens[1];
        int v = tokens[2];

        Graph graph = new(n);
        for (int i = 0; i < m; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            graph.Connect(tokens[0], tokens[1]);
        }

        Console.WriteLine(graph.DFS(v));
        Console.WriteLine(graph.BFS(v));
    }

    private class Graph
    {
        private List<int>[] _adjacencyList;

        public Graph(int vertexCount)
        {
            _adjacencyList = new List<int>[vertexCount + 1];
            for (int i = 0; i < _adjacencyList.Length; ++i)
            {
                _adjacencyList[i] = new();
            }
        }

        public void Connect(int v0, int v1)
        {
            _adjacencyList[v0].Add(v1);
            _adjacencyList[v1].Add(v0);
            _adjacencyList[v0].Sort();
            _adjacencyList[v1].Sort();
        }

        public StringBuilder DFS(int v, bool[]? visited = null)
        {
            if (visited == null)
                visited = new bool[_adjacencyList.Length];

            visited[v] = true;

            StringBuilder output = new();
            output.Append($"{v} ");
            
            var adjacencies = _adjacencyList[v];

            for (int i = 0; i < adjacencies.Count; ++i)
            {
                int adjacentV = adjacencies[i];

                if (visited[adjacentV])
                    continue;

                output.Append(DFS(adjacentV, visited));
            }
            
            return output;
        }

        public StringBuilder BFS(int firstV)
        {
            bool[] visited = new bool[_adjacencyList.Length];
            Queue<int> visitingQueue = new();

            visited[firstV] = true;
            visitingQueue.Enqueue(firstV);

            StringBuilder output = new();
            while (visitingQueue.Count > 0)
            {
                int originV = visitingQueue.Dequeue();

                output.Append($"{originV} ");

                var adjacencies = _adjacencyList[originV];
                for (int i = 0; i < adjacencies.Count; ++i)
                {
                    int adjacentV = adjacencies[i];

                    if (visited[adjacentV])
                        continue;

                    visited[adjacentV] = true;
                    visitingQueue.Enqueue(adjacentV);
                }
            }
            return output;
        }
    }
}