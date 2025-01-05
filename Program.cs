internal class Program
{
    private static void Main(string[] args)
    {
        string s0 = Console.ReadLine()!;
        string s1 = Console.ReadLine()!;

        int output = 0;
        int height = s0.Length + 1; // 0 row is a margin.
        int width = s1.Length + 1; // 0 col is a margin.
        int[,] dp = new int[height, width];
        for (int row = 1; row < height; ++row)
        {
            for (int col = 1; col < width; ++col)
            {
                int lcsLength;
                if (s0[row - 1] == s1[col - 1])
                {
                    lcsLength = dp[row - 1, col - 1] + 1;
                }
                else
                {
                    lcsLength = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                }
                dp[row, col] = lcsLength;
                output = Math.Max(output, lcsLength);
            }
        }
        Console.Write(output);
    }
}