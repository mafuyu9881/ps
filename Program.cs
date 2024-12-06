internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int h = tokens[0]; // 10,000 ≤ H ≤ 100,000
        int y = tokens[1]; // 0 ≤ Y ≤ 10

        int[] dp = new int[y + 1];
        dp[0] = h;
        for (int currIndex = 1; currIndex < dp.Length; ++currIndex)
        {
            dp[currIndex] = (int)(dp[currIndex - 1] * 1.05);

            if (currIndex >= 3)
            {
                dp[currIndex] = Math.Max(dp[currIndex], (int)(dp[currIndex - 3] * 1.2));
            }

            if (currIndex >= 5)
            {
                dp[currIndex] = Math.Max(dp[currIndex], (int)(dp[currIndex - 5] * 1.35));
            }
        }
        Console.Write(dp[y]);
    }
}