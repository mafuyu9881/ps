using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [?, ?]

        int[,] dp = new int[1001, 1001];
        dp[1, 1] = 1;
        dp[2, 1] = 1;
        dp[2, 2] = 1;
        dp[3, 1] = 1;
        dp[3, 2] = 2;
        dp[3, 3] = 1;
        for (int j = 4; j < 1001; ++j) // tc = 997
        {
            for (int k = 2; k < 1001; ++k) // tc = 999
            {
                dp[j, k] = dp[j - 1, k - 1] + dp[j - 2, k - 1] + dp[j - 3, k - 1];
            }
        }

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [1, 1'000]
            int m = tokens[1]; // [1, n]
            sb.AppendLine($"{dp[n, m]}");
        }
        Console.Write(sb);
    }
}