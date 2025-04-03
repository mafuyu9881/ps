internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 500]

        int m = int.Parse(Console.ReadLine()!); // [1, 10'000]

        LinkedList<int>[] adjList = new LinkedList<int>[n + 1];
        for (int i = 1; i < adjList.Length; ++i) // max tc = 500
        {
            adjList[i] = new();
        }

        for (int i = 0; i < m; ++i) // max tc = 10'000
        {
            // length = 2
            // element = [1, n] = [1, 500]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int b = tokens[1];
            adjList[a].AddLast(b);
            adjList[b].AddLast(a);
        }

        const int InvalidCost = -1;

        int[] minCosts = new int[adjList.Length];
        for (int i = 0; i < minCosts.Length; ++i)
        {
            minCosts[i] = InvalidCost;
        }
        
        PriorityQueue<(int v, int cost), int> frontier = new();

        int s = 1;
        int sCost = 0;
        minCosts[s] = sCost;
        frontier.Enqueue((s, sCost), sCost);
        while (frontier.Count > 0)
        {
            var element = frontier.Dequeue();
            int v = element.v;
            int vCost = element.cost;

            if (vCost > minCosts[v])
                continue;

            var adjs = adjList[v];
            for (var lln = adjs.First; lln != null; lln = lln.Next)
            {
                int adjV = lln.Value;

                int oldAdjVMinCost = minCosts[adjV];
                int newAdjVMinCost = vCost + 1;
                if (oldAdjVMinCost != InvalidCost && oldAdjVMinCost <= newAdjVMinCost)
                    continue;

                minCosts[adjV] = newAdjVMinCost;
                frontier.Enqueue((adjV, newAdjVMinCost), newAdjVMinCost);
            }
        }

        int invitables = 0;
        for (int i = 2; i < minCosts.Length; ++i)
        {
            int minCost = minCosts[i];

            if (minCost == InvalidCost)
                continue;

            if (minCost > 2)
                continue;

            ++invitables;
        }
        Console.Write(invitables);
    }
}