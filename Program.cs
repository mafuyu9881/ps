internal class Program
{
    const int InvalidV = -1;
    const int InvalidCost = -1;

    private static LinkedList<(int dst, int cost)>[] _adjList = null!;

    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100'000]
        int m = tokens[1]; // [1, 200'000]

        _adjList = new LinkedList<(int, int)>[n + 1];

        for (int i = 1; i < _adjList.Length; ++i) // max tc = n = 100'000
        {
            _adjList[i] = new();
        }
        
        for (int i = 0; i < m; ++i) // max tc = m = 200'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int u = tokens[0]; // [1, n] = [1, 100'000]
            int v = tokens[1]; // [1, n] = [1, 100'000]
            int w = tokens[2]; // [1, 10'000]
            _adjList[u].AddLast((v, w));
        }

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int x = tokens[0];
        int y = tokens[1];
        int z = tokens[2];

        int[] xMinCost = ComputeMinCost(x, InvalidV);
        int[] yMinCost = ComputeMinCost(y, InvalidV);
        int[] xMinCostWithoutY = ComputeMinCost(x, y);

        int case0 = (xMinCost[y] == InvalidCost || yMinCost[z] == InvalidCost) ? InvalidCost : xMinCost[y] + yMinCost[z];
        int case1 = xMinCostWithoutY[z];

        Console.Write($"{case0} {case1}");
    }

    private static int[] ComputeMinCost(int s, int bannedV)
    {
        int[] minCost = new int[_adjList.Length];
        for (int i = 0; i < minCost.Length; ++i)
        {
            minCost[i] = InvalidCost;
        }

        PriorityQueue<(int v, int cost), int> frontier = new();
        
        minCost[s] = 0;
        frontier.Enqueue((s, minCost[s]), minCost[s]);
        while (frontier.Count > 0)
        {
            var element = frontier.Dequeue();
            
            int v = element.v;
            int cost = element.cost;

            var adjs = _adjList[v];
            for (var lln = adjs.First; lln != null; lln = lln.Next)
            {
                int adjV = lln.Value.dst;
                if (adjV == bannedV)
                    continue;

                int adjCost = lln.Value.cost;

                int oldCost = minCost[adjV];
                int newCost = cost + adjCost;
                if (oldCost != InvalidCost && oldCost <= newCost)
                    continue;

                minCost[adjV] = newCost;
                frontier.Enqueue((adjV, minCost[adjV]), minCost[adjV]);
            }
        }

        return minCost;
    }
}