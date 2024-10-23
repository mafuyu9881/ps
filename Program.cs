using System.Text;

internal class Program
{
    const int Infinity = -1;

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int e = tokens[1];

        int verticesCount = n + 1;

        LinkedList<ConnectionData>[] adjList = new LinkedList<ConnectionData>[verticesCount];
        for (int i = 0; i < adjList.Length; ++i)
        {
            adjList[i] = new();
        }

        for (int i = 0; i < e; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int aVertex = tokens[0];
            int bVertex = tokens[1];
            int cost = tokens[2];
            
            adjList[aVertex].AddLast(new ConnectionData(bVertex, cost));
            adjList[bVertex].AddLast(new ConnectionData(aVertex, cost));
        }

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int v1Vertex = tokens[0];
        int v2Vertex = tokens[1];
        
        int srcVertex = 1;
        int dstVertex = n;
        
        var fromSrcMinimumCostTable = ComputeMinimumCostTable(verticesCount, adjList, srcVertex);
        var fromV1MinimumCostTable = ComputeMinimumCostTable(verticesCount, adjList, v1Vertex);
        var fromV2MinimumCostTable = ComputeMinimumCostTable(verticesCount, adjList, v2Vertex);

        int v1ToV2Cost = fromV1MinimumCostTable[v2Vertex];
        int srcToDstCost = fromSrcMinimumCostTable[dstVertex];
        int srcToV1Cost = fromSrcMinimumCostTable[v1Vertex];
        int srcToV2Cost = fromSrcMinimumCostTable[v2Vertex];
        int v1ToDstCost = fromV1MinimumCostTable[dstVertex];
        int v2ToDstCost = fromV2MinimumCostTable[dstVertex];
        
        int output;
        if (srcToDstCost == Infinity || v1ToV2Cost == Infinity)
        {
            output = Infinity;
        }
        else
        {
            output = v1ToV2Cost + Math.Min(srcToV1Cost + v2ToDstCost, srcToV2Cost + v1ToDstCost);
        }
        Console.Write(output);
    }
    
    private static int[] ComputeMinimumCostTable(int verticesCount, LinkedList<ConnectionData>[] adjList, int srcVertex)
    {
        int[] minimumCostTable = new int[verticesCount];
        for (int i = 0; i < minimumCostTable.Length; ++i)
        {
            minimumCostTable[i] = (i == srcVertex) ? 0 : Infinity;
        }

        PriorityQueue<ConnectionData, int> visitingQueue = new();
        visitingQueue.Enqueue(new(srcVertex, 0), 0);
        while (visitingQueue.Count > 0)
        {
            ConnectionData nearConnectionData = visitingQueue.Dequeue();
            int nearVertex = nearConnectionData.connectedVertex;
            int nearCost = nearConnectionData.cost;

            if (minimumCostTable[nearVertex] != Infinity &&
                minimumCostTable[nearVertex] < nearCost)
                continue;

            var nearAdjacencies = adjList[nearVertex];
            for (var node = nearAdjacencies.First; node != null; node = node.Next)
            {
                ConnectionData nearAdjConnectionData = node.Value;
                int nearAdjVertex = nearAdjConnectionData.connectedVertex;
                int nearAdjCost = nearAdjConnectionData.cost;

                int newCost = nearCost + nearAdjCost;
                if (minimumCostTable[nearAdjVertex] != Infinity &&
                    minimumCostTable[nearAdjVertex] <= newCost)
                    continue;

                minimumCostTable[nearAdjVertex] = newCost;
                visitingQueue.Enqueue(new(nearAdjVertex, newCost), newCost);
            }
        }

        return minimumCostTable;
    }

    private struct ConnectionData
    {
        public int connectedVertex;
        public int cost;
        
        public ConnectionData(int connectedVertex, int cost)
        {
            this.connectedVertex = connectedVertex;
            this.cost = cost;
        }
    }
}