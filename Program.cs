internal class Program
{
    private static void Main(string[] args)
    {
        const int InvalidDistance = -1;

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100]
        int m = tokens[1]; // [1, 15]
        int r = tokens[2]; // [1, 100]

        // element = [1, 30]
        int[] items = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[,] adjMatrix = new int[n, n];
        for (int row = 0; row < n; ++row) // max tc = 100
        {
            for (int col = 0; col < n; ++col) // max tc = 100
            {
                adjMatrix[row, col] = (row == col) ? 0 : InvalidDistance;
            }
        }

        for (int i = 0; i < r; ++i) // max tc = 100
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int a = tokens[0] - 1;
            int b = tokens[1] - 1;
            int l = tokens[2]; // [1, 15]

            adjMatrix[a, b] = l;
            adjMatrix[b, a] = l;
        }

        for (int transit = 0; transit < n; ++transit) // max tc = 100
        {
            for (int src = 0; src < n; ++src) // max tc = 100
            {
                for (int dst = 0; dst < n; ++dst) // max tc = 100
                {
                    int transitDistance0 = adjMatrix[src, transit];
                    int transitDistance1 = adjMatrix[transit, dst];
                    if (transitDistance0 == InvalidDistance || transitDistance1 == InvalidDistance)
                        continue;

                    int oldDistance = adjMatrix[src, dst];
                    int newDistance = transitDistance0 + transitDistance1;
                    if (oldDistance != InvalidDistance && oldDistance <= newDistance)
                        continue;
                    
                    adjMatrix[src, dst] = newDistance;
                }
            }
        }

        int maxCollectableItems = 0;
        for (int src = 0; src < n; ++src) // max tc = 100
        {
            int collectableItems = 0;
            for (int dst = 0; dst < n; ++dst) // max tc = 100
            {
                int distance = adjMatrix[src, dst];
                if (distance == InvalidDistance)
                    continue;

                if (distance > m)
                    continue;

                collectableItems += items[dst];
            }
            maxCollectableItems = Math.Max(maxCollectableItems, collectableItems);
        }
        Console.Write(maxCollectableItems);
    }
}