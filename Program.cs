using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [1, 5]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 5
        {
            int[] tokens = null!;

            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 3
            int n = tokens[0]; // [1, 500]
            int m = tokens[1]; // [1, 2'500]
            int w = tokens[2]; // [1, 200]

            LinkedList<(int v, int cost)>[] adjList = new LinkedList<(int, int)>[n + 1];
            for (int j = 1; j < adjList.Length; ++j) // max tc = [1, n] = [1, 500]
            {
                adjList[j] = new();
            }

            for (int j = 0; j < m; ++j) // max tc = 2'500
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 3

                int s = tokens[0]; // [1, n] = [1, 500]
                int e = tokens[1]; // [1, n] = [1, 500]
                int cost = tokens[2]; // [0, 10'000]

                adjList[s].AddLast((e, cost));
                adjList[e].AddLast((s, cost));
            }

            int minMinusCost = 0;
            for (int j = 0; j < w; ++j) // max tc = 200
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 3

                int s = tokens[0]; // [1, n] = [1, 500]
                int e = tokens[1]; // [1, n] = [1, 500]
                int cost = tokens[2]; // [0, 10'000]}
                
                minMinusCost = Math.Min(minMinusCost, cost);
                adjList[s].AddLast((e, cost));
            }

            for (int j = 1; j < adjList.Length; ++j) // max tc (including inner loop) = m + w = 2'500 + 200
            {
                var adjs = adjList[j];
                for (var lln = adjs.First; lln != null; lln = lln.Next)
                {
                    int v = lln.Value.v;
                    int cost = lln.Value.cost;
                    lln.ValueRef = (v, cost + minMinusCost);
                }
            }

            
        }
        Console.Write(sb);
    }
}