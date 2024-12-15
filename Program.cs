internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] cylicNumbers = new int[] { 2, 1 };

        int[] dp = new int[Math.Max(3, n)];
        dp[0] = 1;
        dp[1] = 3;
        dp[2] = 5;
        for (int i = 3; i < dp.Length; ++i)
        {
            for (int j = 0; j < i; ++j)
            {
                dp[i] += dp[j];
            }
            dp[i] += cylicNumbers[(i - 2 - 1) % cylicNumbers.Length];
            dp[i] %= 10007;
        }
        Console.Write(dp[n - 1]);
    }
}