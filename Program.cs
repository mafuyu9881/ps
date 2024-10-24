internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int k = tokens[1];

        int[,] dp = new int[n + 1, k + 1];
        for (int i = 1; i <= n; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int w = tokens[0];
            int v = tokens[1];
            
            for (int j = 1; j <= k; ++j)
            {
                if (j < w)
                {
                    dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - w] + v);
                }
            }
        }
        Console.Write(dp[n, k]);
    }
}