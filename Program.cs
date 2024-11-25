using System.Text;

internal class Program
{
    private struct ConnectionData
    {
        private int _dst;
        public int Dst => _dst;
        private int _cost;
        public int Cost => _cost;

        public ConnectionData(int dst, int cost)
        {
            _dst = dst;
            _cost = cost;
        }
    }

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int vCount = tokens[0]; // 1 ≤ V ≤ 20,000
        int extendedVCount = vCount + 1;
        int eCount = tokens[1]; // 1 ≤ E ≤ 300,000

        int k = int.Parse(Console.ReadLine()!);

        LinkedList<ConnectionData>[] adjList = new LinkedList<ConnectionData>[extendedVCount];
        for (int i = 0; i < adjList.Length; ++i)
        {
            adjList[i] = new();
        }
        for (int i = 0; i < eCount; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int u = tokens[0];
            int v = tokens[1];
            int w = tokens[2];

            adjList[u].AddLast(new ConnectionData(v, w));
        }

        const int Infinity = -1;
        int[] minCosts = new int[extendedVCount];
        for (int i = 1; i < minCosts.Length; ++i)
        {
            minCosts[i] = (i == k) ? 0 : Infinity;
        }

        int selfCost = 0;
        PriorityQueue<ConnectionData, int> pq = new();
        pq.Enqueue(new(k, selfCost), selfCost);
        while (pq.Count > 0)
        {
            ConnectionData initConnectionData = pq.Dequeue();
            int initDst = initConnectionData.Dst;
            int initCost = initConnectionData.Cost;

            var adjs = adjList[initDst];
            for (var node = adjs.First; node != null; node = node.Next)
            {
                ConnectionData adjConnectionData = node.Value;
                int adjDst = adjConnectionData.Dst;
                int adjCost = adjConnectionData.Cost; // adjCost can't be infinity. If it were, it can't be in adjs.

                int oldCost = minCosts[adjDst];
                int newCost = initCost + adjCost;
                if (oldCost == Infinity || oldCost > newCost)
                {
                    minCosts[adjDst] = newCost;
                    pq.Enqueue(new(adjDst, newCost), newCost);
                }
            }
        }
        StringBuilder output = new();
        for (int i = 1; i < minCosts.Length; ++i)
        {
            int minCost = minCosts[i];
            output.AppendLine((minCost != Infinity) ? $"{minCost}" : "INF");
        }
        Console.Write(output);
    }
}