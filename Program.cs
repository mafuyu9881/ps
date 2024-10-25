using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int nodeCount = tokens[0];
        int distanceComputingCount = tokens[1];
        
        Graph graph = new(nodeCount + 1);
        for (int i = 0; i < nodeCount - 1; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            graph.Connect(tokens[0], tokens[1], tokens[2]);
        }

        StringBuilder output = new();
        for (int i = 0; i < distanceComputingCount; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            output.AppendLine($"{graph.ComputeDistance(tokens[0], tokens[1])}");
        }
        Console.Write(output);
    }
    
    private struct DistanceAccumulator
    {
        public int dstNode;
        public int accumuldatedDistance;

        public DistanceAccumulator(int dstNode, int accumuldatedDistance)
        {
            this.dstNode = dstNode;
            this.accumuldatedDistance = accumuldatedDistance;
        }
    }
    
    private class Graph
    {
        private LinkedList<int>[]? _adjList = null;
        private int[,]? _costMap = null;

        public Graph(int nodeCount)
        {
            _adjList = new LinkedList<int>[nodeCount];
            for (int i = 0; i < _adjList.Length; ++i)
            {
                _adjList[i] = new();
            }

            _costMap = new int[nodeCount, nodeCount];
        }

        public void Connect(int node0, int node1, int cost)
        {
            if (_adjList == null || _costMap == null)
                return;

            _adjList[node0].AddLast(node1);
            _adjList[node1].AddLast(node0);

            _costMap[node0, node1] = cost;
            _costMap[node1, node0] = cost;
        }
        
        public int ComputeDistance(int node0, int node1)
        {
            if (_adjList == null || _costMap == null)
                return -1;

            int adjListLength = _adjList.Length;

            bool[] visitedTable = new bool[adjListLength];

            Queue<DistanceAccumulator> visitingQueue = new();
            visitedTable[node0] = true;
            visitingQueue.Enqueue(new(node0, 0));
            while (visitingQueue.Count > 0)
            {
                DistanceAccumulator dstDA = visitingQueue.Dequeue();
                int dstNode = dstDA.dstNode;
                int dstAccumulatedDistance = dstDA.accumuldatedDistance;

                var adjacencies = _adjList[dstNode];
                for (var listNode = adjacencies.First; listNode != null; listNode = listNode.Next)
                {
                    int dstAdjNode = listNode.Value;

                    if (visitedTable[dstAdjNode])
                        continue;

                    int newAccumulatedDistance = dstAccumulatedDistance + _costMap[dstNode, dstAdjNode];
                    if (dstAdjNode == node1)
                        return newAccumulatedDistance;

                    visitedTable[dstAdjNode] = true;
                    visitingQueue.Enqueue(new(dstAdjNode, newAccumulatedDistance));
                }
            }

            return -1;
        }
    }
}