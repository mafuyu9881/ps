using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int InvalidCost = -1;

        int t = int.Parse(Console.ReadLine()!); // [1, 5]

        int[] tokens = null!;

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max t = 5
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [1, 500]
            int m = tokens[1]; // [1, 2'500]
            int w = tokens[2]; // [1, 200]

            LinkedList<(int s, int e, int cost)> edges = new();

            for (int j = 0; j < m; ++j) // max tc = 2'500
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int s = tokens[0];
                int e = tokens[1];
                int cost = tokens[2];
                edges.AddLast((s, e, cost));
                edges.AddLast((e, s, cost));
            }

            for (int j = 0; j < w; ++j) // max tc = 200
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int s = tokens[0];
                int e = tokens[1];
                int cost = tokens[2];
                edges.AddLast((s, e, -cost));
            }

            int[] minCost = new int[n + 1];
            for (int j = 1; j < minCost.Length; ++j) // max tc = 200
            {
                minCost[j] = InvalidCost;
            }
            minCost[1] = 0;
            
            for (int j = 0; j < n; ++j) // max tc = 500
            {
                for (var lln = edges.First; lln != null; lln = lln.Next) // max tc = 2'500
                {
                    int s = lln.Value.s;
                    if (minCost[s] == InvalidCost)
                        continue;

                    int e = lln.Value.e;
                    int eOldMinCost = minCost[e];
                    int eNewMinCost = minCost[s] + lln.Value.cost;
                    if (eOldMinCost != InvalidCost && eOldMinCost <= eNewMinCost)
                        continue;

                    minCost[e] = eNewMinCost;
                }
            }

            sb.AppendLine(minCost[1] < 0 ? "YES" : "NO");
        }
        Console.Write(sb);
    }
}