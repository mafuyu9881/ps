internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 300'000]
        int m = tokens[1]; // [0, 300'000]

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int s = tokens[0]; // [1, 300'000]
        int e = tokens[1]; // [1, 300'000]

        LinkedList<int>[] adjList = new LinkedList<int>[n + 1];
        for (int i = 1; i <= n; ++i)
        {
            adjList[i] = new();
        }
        for (int i = 0; i < m; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int x = tokens[0]; // [1, 300'000]
            int y = tokens[1]; // [1, 300'000]
            adjList[x].AddLast(y);
            adjList[y].AddLast(x);
        }
        for (int i = 1; i <= n; ++i)
        {
            int prev = i - 1;
            int next = i + 1;
            if (prev >= 1)
            {
                adjList[i].AddLast(prev);
            }
            if (next <= n)
            {
                adjList[i].AddLast(next);
            }
        }

        const int InvalidCost = -1;

        int[] minCost = new int[n + 1];
        for (int i = 0; i < minCost.Length; ++i)
        {
            minCost[i] = InvalidCost;
        }
        
        Queue<(int v, int cost)> frontier = new();
        
        minCost[s] = 0;
        frontier.Enqueue((s, minCost[s]));
        while (frontier.Count > 0)
        {
            var element = frontier.Dequeue();
            int v = element.v;
            int cost = element.cost;

            var adjs = adjList[v];
            for (var lln = adjs.First; lln != null; lln = lln.Next)
            {
                int adjV = lln.Value;

                int oldMinCost = minCost[adjV];
                int newMinCost = cost + 1;
                if (oldMinCost != InvalidCost && oldMinCost <= newMinCost)
                    continue;

                minCost[adjV] = newMinCost;
                frontier.Enqueue((adjV, minCost[adjV]));
            }
        }
        Console.Write(minCost[e]);
    }
}