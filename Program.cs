using System.Text;

internal class Program
{
    const int InvalidVertex = -1;

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        Graph graph = new(n + 1);
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            
            graph.Connect(tokens[0], tokens[1]);
        }
        
        graph.ComputeDistances(out int[] distances);

        StringBuilder output = new();
        for (int i = 1; i < distances.Length; ++i)
        {
            output.Append($"{distances[i]} ");
        }
        Console.Write($"{output}");
    }

    private class Graph
    {
        private int _vertexCount;
        private LinkedList<int>[]? _adjList;
        
        public Graph(int n)
        {
            _vertexCount = n;

            _adjList = new LinkedList<int>[_vertexCount];
            for (int i = 0; i < _vertexCount; ++i)
            {
                _adjList[i] = new();
            }
        }

        public void Connect(int a, int b)
        {
            if (_adjList == null)
                return;

            _adjList[a].AddLast(b);
            _adjList[b].AddLast(a);
        }
        
        public void ComputeDistances(out int[] distances)
        {
            distances = new int[_vertexCount];

            if (_adjList == null)
                return;

            const int Infinity = -1;

            bool[] visited = new bool[_vertexCount];
            bool[] cyclic = new bool[_vertexCount];
            DetectCyclicVertices(visited, cyclic, 1, InvalidVertex);

            Queue<int> visitingQueue = new();

            for (int i = 0; i < distances.Length; ++i)
            {
                int distance = Infinity;

                if (cyclic[i])
                {
                    distance = 0;
                    visitingQueue.Enqueue(i);
                }

                distances[i] = distance;
            }

            while (visitingQueue.Count > 0)
            {
                int v = visitingQueue.Dequeue();

                LinkedList<int> adjacencies = _adjList[v];
                for (LinkedListNode<int>? node = adjacencies.First; node != null; node = node.Next)
                {
                    int adjV = node.Value;

                    if (distances[adjV] != Infinity)
                        continue;

                    distances[adjV] = distances[v] + 1;
                    visitingQueue.Enqueue(adjV);
                }
            }
        }
        
        private int DetectCyclicVertices(bool[] visited, bool[] cyclic, int currV, int prevV)
        {
            if (visited[currV])
                return currV;

            visited[currV] = true;
            
            LinkedList<int> adjacencies = _adjList![currV];
            for (LinkedListNode<int>? node = adjacencies.First; node != null; node = node.Next)
            {
                int nextV = node.Value;

                // 현재 컨텍스트를 발생시킨 직전의 정점인지 검사하는 것이 조건의 내용입니다.
                // 때문에 visited[nextV]로 검사해선 안됩니다.
                // 만약 위 조건으로 검사할 경우, 사이클을 감지할 수 없습니다.
                if (nextV == prevV)
                    continue;

                int futureV = DetectCyclicVertices(visited, cyclic, nextV, currV);
                if (futureV == InvalidVertex)
                    continue;

                cyclic[currV] = true;
                return (futureV == currV) ? InvalidVertex : futureV;
            }

            return InvalidVertex;
        }
    }
}