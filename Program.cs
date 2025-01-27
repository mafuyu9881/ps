internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 100]

        // dp[r, d] = all possible ways to place them in row 'r', at distance 'd'
        int[,] dp = new int[n + 1, n + 1];
        dp[2, 1] = 2;
        for (int r = 3; r <= n; ++r)
        {
            for (int d = 1; d < r; ++d)
            {
                // rhs = down/down + diagonal/diagonal + down/diagonal + diagonal/down
                dp[r, d] = (dp[r - 1, d] + dp[r - 1, d] + dp[r - 1, d - 1] + dp[r - 1, d + 1]) % 10007;
            }
        }

        int output = 0;
        for (int d = 1; d < n; ++d)
        {
            output = (output + dp[n, d]) % 10007;
        }
        Console.Write(output);
    }
}