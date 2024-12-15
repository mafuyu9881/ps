using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int[] baseDP = new int[] { 1, 1, 1, 2, 2 };
            
            int n = int.Parse(Console.ReadLine()!); // 1 ≤ n ≤ 100

            long[] dp = new long[Math.Max(baseDP.Length, n)];
            for (int j = 0; j < baseDP.Length; ++j)
            {
                dp[j] = baseDP[j];
            }

            for (int j = baseDP.Length; j < dp.Length; ++j)
            {
                dp[j] = dp[j - 1] + dp[j - 5];
            }

            output.AppendLine($"{dp[n - 1]}");
        }
        Console.Write(output);
    }
}