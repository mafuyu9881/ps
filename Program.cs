internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int k = tokens[1];

        int[,] weightValues = new int[n, 2];
        for (int i = 0; i < n; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            weightValues[i, 0] = tokens[0];
            weightValues[i, 1] = tokens[1];
        }

        int[,] dp = new int[n + 1, k + 1];
        for (int i = 1; i <= n; ++i)
        {
            for (int j = 1; j <= k; ++j)
            {
                int selectedIndex = i - 1;

                int weight = weightValues[selectedIndex, 0];
                int value = weightValues[selectedIndex, 1];

                if (j < weight)
                    dp[i, j] = dp[i - 1, j];
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - weight] + value);
            }
        }

        Console.Write(dp[n, k]);
    }
}