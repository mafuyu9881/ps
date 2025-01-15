internal class Program
{
    const int InvalidValue = -1;

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [3, 200]
        int k = tokens[1]; // [0, n]

        int[,] museum = new int[n, 2];
        for (int i = 0; i < n; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            museum[i, 0] = tokens[0]; // [0, 100]
            museum[i, 1] = tokens[1]; // [0, 100]
        }

        // the element on third dimension means state
        // state consists of these following things
        // 0: left gallery is only available
        // 1: right gallery is only available
        // 2: both galleries in the same row are available
        int firstDimensionLength = n;
        int secondDimensionLength = Math.Max(k + 1, 2);
        int thirdDimensionLength = 3;
        int[,,] dp = new int[firstDimensionLength, secondDimensionLength, thirdDimensionLength]; // max sc = 200 * (200 + 1) * 3
        for (int i = 0; i < firstDimensionLength; ++i)
        {
            for (int j = 0; j < secondDimensionLength; ++j)
            {
                for (int l = 0; l < thirdDimensionLength; ++l)
                {
                    dp[i, j, l] = InvalidValue;
                }
            }
        }
        
        dp[0, 1, 0] = museum[0, 0];
        dp[0, 1, 1] = museum[0, 1];
        dp[0, 0, 2] = museum[0, 0] + museum[0, 1];

        for (int row = 1; row < n; ++row)
        {
            for (int closed = 0; closed <= k; ++closed)
            {
                int leftGalleryValue = museum[row, 0];
                int rightGalleryValue = museum[row, 1];

                if (closed > 0)
                {
                    dp[row, closed, 0] = leftGalleryValue + Max(new int[] { dp[row - 1, closed - 1, 0], dp[row - 1, closed - 1, 2] });
                    dp[row, closed, 1] = rightGalleryValue + Max(new int[] { dp[row - 1, closed - 1, 1], dp[row - 1, closed - 1, 2] });
                }

                if (k < n)
                {
                    dp[row, closed, 2] = leftGalleryValue + rightGalleryValue + Max(new int[] { dp[row - 1, closed, 0], dp[row - 1, closed, 1], dp[row - 1, closed, 2] });
                }
            }
        }

        Console.Write(Max(new int[] { dp[n - 1, k, 0], dp[n - 1, k, 1], dp[n - 1, k, 2] }));
    }
    
    private static int Max(ReadOnlySpan<int> span)
    {
        int output = InvalidValue;

        for (int i = 0; i < span.Length; ++i)
        {
            int element = span[i];

            if (element == InvalidValue)
                continue;

            if (output != InvalidValue && element < output)
                continue;

            output = element;
        }

        return output;
    }
}