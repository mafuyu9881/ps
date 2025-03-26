internal class Program
{
    private static void Main(string[] args)
    {
        // length = 3
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 80]
        int k = tokens[1]; // [1, n] = [1, 80]
        int x = tokens[2]; // [1, 200]

        (int a, int b)[] stats = new (int, int)[n];
        for (int i = 0; i < n; ++i) // max tc = 80
        {
            // length = 2
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0]; // [0, 200]
            int b = tokens[1]; // [0, 200]
            stats[i] = (a, b);
        }
        
        Array.Sort(stats, (x, y) => Math.Abs(y.a - y.b).CompareTo(Math.Abs(x.a - x.b)));

        int dpHeight = stats.Length + 1;
        int dpWidth = k + 1;
        int dpLayers = x * k + 1;
        int[,,] dp = new int[dpHeight, dpWidth, dpLayers];

        int maxStatsSum = 0;
        for (int i = 1; i < dpHeight; ++i) // max tc = 80
        {
            for (int j = 1; j < dpWidth; ++j) // max tc = 80
            {
                for (int l = 1; l < dpLayers; ++l) // max tc = 80 * 200 = 16'000
                {
                    dp[i, j, l] = dp[i - 1, j, l];
                    
                    int a = stats[i - 1].a;
                    if (l - a >= 0)
                    {
                        dp[i, j, l] = Math.Max(dp[i, j, l], dp[i - 1, j - 1, l - a] + a);
                    }

                    maxStatsSum = Math.Max(maxStatsSum, l * (x * k - l));
                }
            }
        }
        Console.Write(maxStatsSum);
    }
}