internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        int[] dp = new int[Math.Max(3, n + 1)];
        dp[0] = 0;
        dp[1] = 0;
        dp[2] = 1;
        for (int i = 3; i < dp.Length; ++i)
        {
            if ((i & 1) == 0)
            {
                dp[i] = (i / 2) * (i / 2) + dp[i / 2] + dp[i / 2];
            }
            else
            {
                dp[i] = (i / 2) * (i / 2 + 1) + dp[i / 2] + dp[i / 2 + 1];
            }
        }
        Console.Write(dp[n]);
    }
}