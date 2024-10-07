using System.Reflection.Metadata.Ecma335;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);
        
        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int n = int.Parse(Console.ReadLine()!);

            int[,] stickers = new int[4, n + 2];
            for (int j = 1; j <= 2; ++j)
            {
                int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

                for (int k = 0; k < n; ++k)
                {
                    stickers[j, k + 1] = tokens[k];
                }
            }

            int[,] dp = new int[4, n + 2];
            dp[1, 1] = stickers[1, 1];
            dp[2, 1] = stickers[2, 1];
            int maxScore = Math.Max(dp[1, 1], dp[2, 1]);
            for (int j = 2; j <= n; ++j)
            {
                int row1DP = Math.Max(dp[2, j - 1], dp[2, j - 2]) + stickers[1, j];
                int row2DP = Math.Max(dp[1, j - 1], dp[1, j - 2]) + stickers[2, j];

                maxScore = Math.Max(row1DP, row2DP);

                dp[1, j] = row1DP;
                dp[2, j] = row2DP;
            }
            output.AppendLine($"{maxScore}");
        }
        Console.Write(output);
    }
}