internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        // length = [1, 100'000]
        // element = [1, 1'000'000'000]
        int[] resistances = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        // 0: O X
        // 1: X O
        // 2: O O
        // 'X X' can't happen
        long[,] dp = new long[n, 3];
        dp[0, 0] = 0;
        dp[0, 1] = resistances[0];
        dp[0, 2] = resistances[0];
        for (int i = 1; i < n; ++i) // max tc = 100'000
        {
            int resistance = resistances[i];
            dp[i, 0] = Math.Min(dp[i - 1, 1], dp[i - 1, 2]);
            dp[i, 1] = dp[i - 1, 0] + resistance;
            dp[i, 2] = Math.Min(dp[i - 1, 1] + resistance, dp[i - 1, 2] + resistance);
        }

        long energy = Math.Min(dp[n - 1, 0], dp[n - 1, 1]);
        energy = Math.Min(energy, dp[n - 1, 2]);
        Console.Write(energy);
    }
}