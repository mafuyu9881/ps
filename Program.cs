using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0];
            int m = tokens[1];

            output.AppendLine($"{CombinationByMemoization(m, n)}");
        }
        Console.Write(output);
    }

    private static int CombinationByMemoization(int n, int r)
    {
        int[,] dp = new int[n + 1, r + 1];
        for (int i = 0; i <= n; ++i)
        {
            for (int j = 0; j <= i && j <= r; ++j)
            {
                if (i == j || j == 0)
                {
                    dp[i, j] = 1;
                }
                else
                {
                    dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                }
            }
        }
        return dp[n, r];
    }
}