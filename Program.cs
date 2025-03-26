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
        
        int dpHeight = stats.Length + 1;
        int dpWidth = k + 1;
        int dpLayers = x * k + 1;
        bool[,,] dp = new bool[dpHeight, dpWidth, dpLayers];
        for (int i = 0; i < dpHeight; ++i)
        {
            dp[i, 0, 0] = true;
        }
        for (int i = 0; i < stats.Length; ++i)
        {
            int a = stats[i].a;
            dp[1, 1, a] = true;
            dp[i + 1, 1, a] = true;
        }

        int maxStatsSum = 0;
        for (int i = 1; i < dpHeight; ++i) // max tc = 80
        {
            for (int j = 1; j < dpWidth; ++j) // max tc = 80
            {
                for (int l = 1; l < dpLayers; ++l) // max tc = 80 * 200 = 16'000
                {
                    int a = stats[i - 1].a;

                    dp[i, j, l] = dp[i - 1, j, l] || (l - a >= 0 && dp[i - 1, j - 1, l - a]);
                    
                    if (dp[i, j, l])
                    {
                        maxStatsSum = Math.Max(maxStatsSum, l * (x * k - l));
                    }
                }
            }
        }
        Console.Write(maxStatsSum);
    }
}