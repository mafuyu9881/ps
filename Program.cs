using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 1'000]

        int m = int.Parse(Console.ReadLine()!); // [1, 100'000]

        int[] tokens = null!;
        LinkedList<(int dstV, int cost)>[] adjList = new LinkedList<(int, int)>[n + 1];
        for (int i = 0; i < m; ++i) // max tc = 100'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int v0 = tokens[0]; // [1, 1'000]
            int v1 = tokens[1]; // [1, 1'000]
            int cost = tokens[2]; // [0, 100'000]

            if (adjList[v0] == null)
                adjList[v0] = new();

            adjList[v0].AddLast((v1, cost));
        }

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // tc = 2
        int departureV = tokens[0];
        int arrivalV = tokens[1];

        PriorityQueue<int, int> frontier = new();
        
        const int InvalidCost = -1;
        int[] minCosts = new int[n + 1];
        for (int i = 0; i < minCosts.Length; ++i) // max tc = 1'001
        {
            minCosts[i] = InvalidCost;
        }

        frontier.Enqueue(departureV, 0);
        minCosts[departureV] = 0;
        
        int[] path = new int[n + 1];
        while (frontier.Count > 0) // max tc = 1'000 * (1'000 - 1) / 2 = 499'500
        {
            int v = frontier.Dequeue();
            if (v == arrivalV)
                break;

            var adjs = adjList[v];
            if (adjs == null)
                continue;

            for (var lln = adjs.First; lln != null; lln = lln.Next)
            {
                var adj = lln.Value;
                int adjV = adj.dstV;
                int adjCost = adj.cost;

                int oldCost = minCosts[adjV];
                int newCost = minCosts[v] + adjCost;
                if (oldCost != InvalidCost && oldCost <= newCost)
                    continue;

                minCosts[adjV] = newCost;
                frontier.Enqueue(adjV, newCost);
                path[adjV] = v;
            }
        }

        int backtrackingV = arrivalV;
        LinkedList<int> arrivalPath = new();
        while (true) // max tc = 1'000
        {
            arrivalPath.AddFirst(backtrackingV);

            if (backtrackingV == departureV)
                break;

            backtrackingV = path[backtrackingV];
        }
        
        StringBuilder sb = new();
        sb.AppendLine($"{minCosts[arrivalV]}");
        sb.AppendLine($"{arrivalPath.Count}");
        for (var lln = arrivalPath.First; lln != null; lln = lln.Next) // max tc = 1'000
        {
            sb.Append($"{lln.Value} ");
        }
        Console.Write(sb);
    }
}