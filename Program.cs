using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int Infinity = 499 * 10000 + 1; // (max cost over any path) + 1 = (number of steps) * (max edge cost) + 1

        int t = int.Parse(Console.ReadLine()!); // [1, 5]

        int[] tokens = null!;

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max t = 5
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [1, 500]
            int m = tokens[1]; // [1, 2'500]
            int w = tokens[2]; // [1, 200]

            LinkedList<(int e, int cost)>[] adjList = new LinkedList<(int, int)>[n + 1];
            for (int j = 1; j < adjList.Length; ++j)
            {
                adjList[j] = new();
            }
            
            LinkedList<(int s, int e, int cost)> edges = new LinkedList<(int, int, int)>();

            for (int j = 0; j < m; ++j) // max tc = 2'500
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int s = tokens[0];
                int e = tokens[1];
                int cost = tokens[2]; // [0, 10'000]
                adjList[s].AddLast((e, cost));
                adjList[e].AddLast((s, cost));
                edges.AddLast((s, e, cost));
                edges.AddLast((e, s, cost));
            }

            for (int j = 0; j < w; ++j) // max tc = 200
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int s = tokens[0];
                int e = tokens[1];
                int cost = tokens[2]; // [0, 10'000]
                adjList[s].AddLast((e, -cost));
                edges.AddLast((s, e, -cost));
            }

            bool[] visited = new bool[n + 1];
            Queue<int> frontier = new();
            LinkedList<int> cc = null!;
            LinkedList<LinkedList<int>> ccs = new();
            for (int j = 1; j <= n; ++j) // max tc = 500
            {
                if (frontier.Count < 1)
                {
                    if (visited[j])
                        continue;

                    cc = new();
                    ccs.AddLast(cc);

                    cc.AddLast(j);
                    visited[j] = true;
                    frontier.Enqueue(j);
                }

                int s = frontier.Dequeue();

                var adjs = adjList[s];
                for (var lln = adjs.First; lln != null; lln = lln.Next)
                {
                    int e = lln.Value.e;
                    if (visited[e])
                        continue;

                    cc.AddLast(e);
                    visited[e] = true;
                    frontier.Enqueue(e);
                }
            }
            
            bool negativeWeightCycle = false;
            for (var ccsLLN = ccs.First; ccsLLN != null; ccsLLN = ccsLLN.Next)
            {
                cc = ccsLLN.Value;

                int[] minCost = new int[n + 1];
                for (int j = 1; j < minCost.Length; ++j) // max tc = 200
                {
                    minCost[j] = Infinity;
                }
                minCost[cc.First!.Value] = 0;

                for (int j = 0; j < n; ++j) // max tc = 500
                {
                    for (var lln = edges.First; lln != null; lln = lln.Next) // max tc = 2'500
                    {
                        int s = lln.Value.s;
                        if (minCost[s] == Infinity)
                            continue;

                        int e = lln.Value.e;
                        int eOldMinCost = minCost[e];
                        int eNewMinCost = minCost[s] + lln.Value.cost;
                        if (eOldMinCost != Infinity && eOldMinCost <= eNewMinCost)
                            continue;

                        minCost[e] = eNewMinCost;

                        if (j >= n - 1)
                        {
                            negativeWeightCycle = true;
                            goto Print;
                        }
                    }
                }
            }

Print:
            sb.AppendLine(negativeWeightCycle ? "YES" : "NO");
        }
        Console.Write(sb);
    }
}