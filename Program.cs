internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        const int Width = 3;

        int dpWidth = 1 + Width + 1;
        int dpHeight = n + 1;

        const int Infinity = 10;

        int[,] maxDP = new int[dpHeight, dpWidth];
        int[,] minDP = new int[dpHeight, dpWidth];
        for (int row = 1; row < dpHeight; ++row)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int prevRow = row - 1;

            int left = tokens[0];
            int center = tokens[1];
            int right = tokens[2];

            maxDP[row, 1] = left + Math.Max(maxDP[prevRow, 1], maxDP[prevRow, 2]);
            maxDP[row, 2] = center + Math.Max(maxDP[prevRow, 1], Math.Max(maxDP[prevRow, 2], maxDP[prevRow, 3]));
            maxDP[row, 3] = right + Math.Max(maxDP[prevRow, 2], maxDP[prevRow, 3]);

            minDP[row, 1] = left + Math.Min(minDP[prevRow, 1], minDP[prevRow, 2]);
            minDP[row, 2] = center + Math.Min(minDP[prevRow, 1], Math.Min(minDP[prevRow, 2], minDP[prevRow, 3]));
            minDP[row, 3] = right + Math.Min(minDP[prevRow, 2], minDP[prevRow, 3]);
            minDP[row, 0] = Infinity;
            minDP[row, dpWidth - 1] = Infinity;

            // NOTE: minDP의 각 원소는 Infinity보다 큰 값이 될 수 있습니다.
            // 때문에 아래의 코드는 통과할 수 없습니다.
            //for (int col = 1; col <= Width; ++col)
            //{
            //    int token = tokens[col - 1];
            //
            //    int leftUpMaxDP = maxDP[prevRow, col - 1];
            //    int centerUpMaxDP = maxDP[prevRow, col];
            //    int rightUpMaxDP = maxDP[prevRow, col + 1];
            //
            //    maxDP[row, col] = token + Math.Max(leftUpMaxDP, Math.Max(centerUpMaxDP, rightUpMaxDP));
            //
            //    int leftUpMinDP = minDP[prevRow, col - 1];
            //    int centerUpMinDP = minDP[prevRow, col];
            //    int rightUpMinDP = minDP[prevRow, col + 1];
            //
            //    minDP[row, col] = token + Math.Min(leftUpMinDP, Math.Min(centerUpMinDP, rightUpMinDP));
            //    minDP[row, 0] = Infinity;
            //    minDP[row, dpWidth - 1] = Infinity;
            //}
        }

        int max = maxDP[n, 1];
        int min = minDP[n, 1];
        for (int i = 2; i <= Width; ++i)
        {
            max = Math.Max(max, maxDP[n, i]);
            min = Math.Min(min, minDP[n, i]);
        }
        Console.Write($"{max} {min}");
    }
}