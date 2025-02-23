internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 50'000]
        int k = tokens[1]; // [1, 100]

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int longestLength = 0;
        int[][] dp = new int[n][];
        dp[0] = new int[k + 1];
        for (int j = 0; j <= k; ++j) // max tc = 101
        {
            dp[0][j] = sequence[0] % 2 == 0 ? 1 : 0;
        }
        for (int i = 1; i < dp.Length; ++i) // max tc = 49'999
        {
            dp[i] = new int[dp[0].Length];

            for (int j = 0; j <= k; ++j) // max tc = 101
            {
                if (sequence[i] % 2 == 0)
                {
                    dp[i][j] = dp[i - 1][j] + 1;
                }
                else
                {
                    if (j > 0)
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }
                    else
                    {
                        dp[i][j] = 0;
                    }
                }

                longestLength = Math.Max(longestLength, dp[i][j]);
            }
        }
        Console.Write(longestLength);
    }
}