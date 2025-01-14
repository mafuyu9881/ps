internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [3, 200]
        int k = tokens[1]; // [0, n]

        int[,] galleries = new int[n, 2];
        for (int i = 0; i < n; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            galleries[i, 0] = tokens[0]; // [0, 100]
            galleries[i, 1] = tokens[1]; // [0, 100]
        }

        // the element on third dimension means state
        // state consists of these following things
        // 0: both galleries in the same row are available
        // 1: left gallery is only available
        // 2: right gallery is only available
        int[,,] dp = new int[n, Math.Max(2, k + 1), 3];
        dp[0, 0, 0] = galleries[0, 0] + galleries[0, 1];
        dp[0, 1, 1] = galleries[0, 0];
        dp[0, 1, 2] = galleries[0, 1];
        for (int row = 1; row < n; ++row)
        {
            // in this implementation, row is 0-based
            // so we should add '1' on row
            for (int closed = 0; closed <= Math.Min(k, row + 1); ++closed)
            {
                if (closed > 0)
                {
                    dp[row, closed, 1] = Math.Max(dp[row - 1, closed - 1, 0], dp[row - 1, closed - 1, 1]) + galleries[row, 0];
                    dp[row, closed, 2] = Math.Max(dp[row - 1, closed - 1, 0], dp[row - 1, closed - 1, 2]) + galleries[row, 1];
                }

                if (k < n)
                {
                    dp[row, closed, 0] = Math.Max(Math.Max(dp[row - 1, closed, 0], dp[row - 1, closed, 1]), dp[row - 1, closed, 2]) + galleries[row, 0] + galleries[row, 1];
                }
            }
        }
        Console.Write($"{Math.Max(Math.Max(dp[n - 1, k, 0], dp[n - 1, k, 1]), dp[n - 1, k, 2])}");
    }
}