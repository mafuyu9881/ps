using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int extendedN = n + 1;

        int m = int.Parse(Console.ReadLine()!);

        int[] tokens;
        LinkedList<(int v, int cost)>[] adjList = new LinkedList<(int, int)>[extendedN];
        for (int i = 0; i < m; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int v0 = tokens[0];
            int v1 = tokens[1];
            int cost = tokens[2];

            var v0Adjs = adjList[v0];
            if (v0Adjs == null)
            {
                v0Adjs = new();
                adjList[v0] = v0Adjs;
            }
            v0Adjs.AddLast((v1, cost));
        }

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int s = tokens[0];
        int e = tokens[1];

        const int Infinity = -1;

        int[] minCosts = new int[extendedN];
        for (int i = 0; i < minCosts.Length; ++i)
        {
            minCosts[i] = (i != s) ? Infinity : 0;
        }

        PriorityQueue<(int v, int cost), int> pq = new();
        pq.Enqueue((s, 0), 0);
        while (pq.Count > 0)
        {
            var element = pq.Dequeue();
            int v = element.v;
            int cost = element.cost;

            var adjs = adjList[v];
            if (adjs != null)
            {
                for (var node = adjs.First; node != null; node = node.Next)
                {
                    int adjV = node.Value.v;
                    int adjCost = node.Value.cost;

                    int oldCost = minCosts[adjV];
                    int newCost = cost + adjCost;
                    if (oldCost == Infinity || oldCost > newCost)
                    {
                        minCosts[adjV] = newCost;
                        pq.Enqueue((adjV, newCost), newCost);
                    }
                }
            }
        }

        StringBuilder output = new();
        output.AppendLine($"{minCosts[e]}");
        Console.Write(output);
    }
}