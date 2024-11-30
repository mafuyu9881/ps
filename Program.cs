using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        BigInteger[] dp = new BigInteger[n + 1]; // 0 <= n <= 10,000
        dp[0] = 0;
        if (dp.Length > 1) dp[1] = 1;
        for (int i = 2; i < dp.Length; ++i) // max tc = 9,998
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        Console.WriteLine(dp[n]);
    }
}