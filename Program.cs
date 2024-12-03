internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // 1 ≤ n ≤ 100,000

        int[] coins = new int[] { 2, 5 };

        const int Invalid = -1;
        int[] dp = new int[n + 1];
        for (int i = 1; i < dp.Length; ++i)
        {
            dp[i] = Invalid;

            for (int j = 0; j < coins.Length; ++j)
            {
                int coin = coins[j];

                if (i - coin < 0)
                    continue;

                if (dp[i - coin] != Invalid)
                {
                    if (dp[i] != Invalid)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                    }
                    else
                    {
                        dp[i] = dp[i - coin] + 1;
                    }
                }
            }
        }

        Console.Write(dp[n]);
    }
}