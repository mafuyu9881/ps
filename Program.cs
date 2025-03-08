internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 5'000]

        // element = [1, 1'000'000]
        int[] rocks = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int s = 0;
        int e = n - 1;

        const int InvalidCost = -1;

        int[] cost = new int[n];
        for (int i = 0; i < cost.Length; ++i) // max tc = 5'000
        {
            cost[i] = InvalidCost;
        }

        Queue<(int v, int cost)> frontier = new();

        int sNewCost = 0;
        cost[s] = sNewCost;
        frontier.Enqueue((s, sNewCost));

        while (frontier.Count > 0)
        {
            var element = frontier.Dequeue();
            int v = element.v;
            int vCost = element.cost;

            for (int adjV = 0; adjV < cost.Length; ++adjV)
            {
                if (adjV == v)
                    continue;

                int adjVOldCost = cost[adjV];
                int adjVNewCost = vCost + (Math.Abs(adjV - v) * (1 + Math.Abs(rocks[v] - rocks[adjV])));
                if (adjVOldCost != InvalidCost && adjVOldCost <= adjVNewCost)
                    continue;

                cost[adjV] = adjVNewCost;
                frontier.Enqueue((adjV, adjVNewCost));
            }
        }

        Console.Write(cost[e]);
    }
}