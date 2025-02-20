internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [0, 12]

        int[] dp = new int[Math.Max(2, n + 1)];
        dp[0] = 1;
        dp[1] = 1;
        for (int i = 2; i < dp.Length; ++i)
        {
            dp[i] = dp[i - 1] * i;
        }
        
        Console.Write(dp[n]);
    }
}