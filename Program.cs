internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] dp = new int[Math.Max(2, n)];
        dp[0] = 1;
        dp[1] = 3;
        for (int i = 2; i < dp.Length; ++i)
        {
            dp[i] = (dp[i - 1] + dp[i - 2] * 2) % 10007;
        }
        Console.Write(dp[n - 1]);
    }
}