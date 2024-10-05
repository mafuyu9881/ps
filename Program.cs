using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        Graph graph = new(new LinkedList<int>[n + 1]);
        for (int i = 0; i < n - 1; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            
            int node0 = int.Parse(tokens[0]);
            int node1 = int.Parse(tokens[1]);

            graph.Connect(node0, node1);
        }

        var parentNodes = graph.ComputeParentNodes(1);

        StringBuilder output = new();
        for (int i = 2; i <= n; ++i)
        {
            output.AppendLine($"{parentNodes[i]} ");
        }
        Console.Write(output);
    }

    private class Graph
    {
        private LinkedList<int>[] _adjacencyList;

        public Graph(LinkedList<int>[] adjacencyList)
        {
            _adjacencyList = adjacencyList;
            for (int i = 0; i < _adjacencyList.Length; ++i)
            {
                _adjacencyList[i] = new();
            }
        }

        // _adjacentcyList의 유효성, 중복 간선이 입력되지 않음이 전제됩니다.
        public void Connect(int node0, int node1)
        {
            _adjacencyList[node0].AddLast(node1);
            _adjacencyList[node1].AddLast(node0);
        }

        public int[] ComputeParentNodes(int superParentNode)
        {
            int adjacencyListLength = _adjacencyList.Length;

            int[] parentNodes = new int[adjacencyListLength];

            bool[] visitiedNodes = new bool[adjacencyListLength];
            Queue<int> visitingQueue = new();

            visitiedNodes[superParentNode] = true;
            visitingQueue.Enqueue(superParentNode);

            while (visitingQueue.Count > 0)
            {
                int parentNode = visitingQueue.Dequeue();

                var adjacencies = _adjacencyList[parentNode];
                for (var listNode = adjacencies.First; listNode != null; listNode = listNode.Next)
                {
                    int adjacentNode = listNode.Value;

                    if (visitiedNodes[adjacentNode])
                        continue;

                    parentNodes[adjacentNode] = parentNode;

                    visitiedNodes[adjacentNode] = true;
                    visitingQueue.Enqueue(adjacentNode);
                }
            }
            
            return parentNodes;
        }
    }
}