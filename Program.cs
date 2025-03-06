using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int vertices = tokens[0]; // [1, 300]
        int edges = tokens[1]; // [1, 25'000]
        int t = tokens[2]; // [1, 40'000]

        const int Infinity = -1;

        int[,] precomputedMaxCosts = new int[vertices, vertices];
        for (int row = 0; row < vertices; ++row) // max tc = 300
        {
            for (int col = 0; col < vertices; ++col) // max tc = 300
            {
                if (row == col)
                {
                    precomputedMaxCosts[row, col] = 0;
                }
                else
                {
                    precomputedMaxCosts[row, col] = Infinity;
                }
            }
        }

        for (int i = 0; i < edges; ++i) // max tc = 25'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            
            // [0, 299]
            int u = tokens[0] - 1;
            int v = tokens[1] - 1;

            int cost = tokens[2]; // [1, 1'000'000]

            precomputedMaxCosts[u, v] = cost;
        }

        for (int transitV = 0; transitV < vertices; ++transitV) // max tc = 300
        {
            for (int srcV = 0; srcV < vertices; ++srcV) // max tc = 300
            {
                for (int dstV = 0; dstV < vertices; ++dstV) // max tc = 300
                {
                    int precomputedMaxCost = precomputedMaxCosts[srcV, dstV];

                    int directCost = precomputedMaxCosts[srcV, dstV];
                    int transitCost0 = precomputedMaxCosts[srcV, transitV];
                    int transitCost1 = precomputedMaxCosts[transitV, dstV];
                    if (transitCost0 != Infinity && transitCost1 != Infinity)
                    {
                        precomputedMaxCost = Math.Max(transitCost0, transitCost1);

                        if (directCost != Infinity)
                        {
                            precomputedMaxCost = Math.Min(directCost, precomputedMaxCost);
                        }
                    }

                    precomputedMaxCosts[srcV, dstV] = precomputedMaxCost;
                }
            }
        }

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 40'000
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            // [0, 299]
            int s = tokens[0] - 1;
            int e = tokens[1] - 1;

            sb.AppendLine($"{precomputedMaxCosts[s, e]}");
        }
        Console.Write(sb);
    }
}