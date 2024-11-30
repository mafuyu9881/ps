internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int[] dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;
        if (dp.Length > 2) dp[2] = 2; // 1 ≤ N ≤ 1000
        for (int i = 3; i < dp.Length; ++i)
        {
            // Min or Max, no need to care about choosing which one
            // But set 0 index's element as 0 and start the loop from 3 is
            // quite important point for automation
            // If we build dp from 1, the loop should be started from 4,
            // then we should set 3 index's element as 1 when we use Min,
            // or 3 when we use Max
            dp[i] = Math.Min(dp[i - 1] + 1, dp[i - 3] + 1);
        }
        Console.Write((dp[n] % 2 != 0) ? "CY" : "SK");
    }
}