using System.Text;

internal class Program
{
    const long InvalidCost = -1;

    private static int _n; // [2, 200'000]
    private static LinkedList<(int v, int cost)>[] _adjList = null!;

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        _n = tokens[0];
        int m = tokens[1]; // [1, 300'000]
        int a = tokens[2] - 1; // [1, 200'000]
        int b = tokens[3] - 1; // [1, 200'000]

        _adjList = new LinkedList<(int v, int cost)>[_n];
        for (int i = 0; i < m; ++i) // max tc = 300'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int v0 = tokens[0] - 1; // [1, 200'000]
            int v1 = tokens[1] - 1; // [1, 200'000]
            int cost = tokens[2]; // [1, 1'000'000'000]

            if (_adjList[v0] == null)
                _adjList[v0] = new();
            
            if (_adjList[v1] == null)
                _adjList[v1] = new();

            _adjList[v0].AddLast((v1, cost));
            _adjList[v1].AddLast((v0, cost));
        }

        long[] aMinCost = ComputeMinCost(a);
        long[] bMinCost = ComputeMinCost(b);

        LinkedList<int> designatables = new();
        for (int i = 0; i < _n; ++i) // max tc = 200'000
        {
            if (aMinCost[i] + bMinCost[i] == aMinCost[b])
            {
                designatables.AddLast(i);
            }
        }

        StringBuilder sb = new();
        sb.AppendLine($"{designatables.Count}");
        for (var lln = designatables.First; lln != null; lln = lln.Next) // max tc = 200'000
        {
            sb.Append($"{lln.Value + 1} ");
        }
        Console.Write(sb);
    }

    private static long[] ComputeMinCost(int s)
    {
        long[] minCost = new long[_n];
        for (int i = 0; i < _n; ++i) // max tc = 200'000
        {
            minCost[i] = InvalidCost;
        }
        PriorityQueue<(int dst, long cost), long> pq = new();

        minCost[s] = 0;
        pq.Enqueue((s, 0), 0); // tc = 1

        while (pq.Count > 0) // max tc = 200'000 * log2(300'000) = 200'000 * 18.xxx
        {
            var e = pq.Dequeue();
            int dst = e.dst;
            long srcDstCost = e.cost;

            if (minCost[dst] != InvalidCost && minCost[dst] < srcDstCost)
                continue;

            var adjs = _adjList[dst];
            for (var lln = adjs.First; lln != null; lln = lln.Next)
            {
                int adj = lln.Value.v;
                long dstAdjCost = lln.Value.cost;

                long oldSrcDstAdjCost = minCost[adj];
                long newSrcDstAdjCost = srcDstCost + dstAdjCost;
                if (oldSrcDstAdjCost != InvalidCost && oldSrcDstAdjCost <= newSrcDstAdjCost)
                    continue;

                minCost[adj] = newSrcDstAdjCost;
                pq.Enqueue((adj, newSrcDstAdjCost), newSrcDstAdjCost);
            }
        }

        return minCost;
    }
}