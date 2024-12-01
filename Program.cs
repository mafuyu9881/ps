internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        // index of the array 'dp' means the length of longest side
        // or it can be said as amount of tiles.
        // and element of it means the area of corresponded rectangle.
        long[] dp = new long[n + 1];
        dp[1] = 4; // 1 ≤ N ≤ 80
        if (dp.Length > 2) dp[2] = 6;
        for (int i = 3; i < dp.Length; ++i)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        Console.Write(dp[n]);
    }
}