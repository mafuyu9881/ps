internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int d = tokens[0]; // [7, 100'000]
        int p = tokens[1]; // [1, 350]

        (int length, int capacity)[] pipes = new (int, int)[p];
        for (int i = 0; i < p; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int l = tokens[0]; // [1, 2^23]
            int c = tokens[1]; // [1, 2^23]
            pipes[i] = (l, c);
        }

        int[,] dp = new int[p + 1, d + 1];
        for (int i = 1; i < dp.GetLength(0); ++i)
        {
            var pipe = pipes[i - 1];
            int length = pipe.length;
            int capacity = pipe.capacity;
            
            for (int j = 1; j < dp.GetLength(1); ++j)
            {
                dp[i, j] = dp[i - 1, j];

                if (j == length)
                {
                    dp[i, j] = Math.Max(dp[i, j], capacity);
                }

                if (j >= length && dp[i - 1, j - length] > 0)
                {
                    dp[i, j] = Math.Max(dp[i, j], Math.Min(dp[i - 1, j - length], capacity));
                }
            }
        }
        
        int maxCapacity = 0;
        {
            for (int i = 1; i < dp.GetLength(0); ++i)
            {
                maxCapacity = Math.Max(maxCapacity, dp[i, d]);
            }
        }
        Console.Write(maxCapacity);
    }
}