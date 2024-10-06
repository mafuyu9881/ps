// 시간 제한: 2초
// 메모리 제한: 128MB
// 1 ≤ n ≤ 500

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        const int NumberMin = 0;
        
        Func<int, bool> IsValidIndex = (index) =>
        {
            return index > -1 && index < n;
        };

        int[,] triangle = new int[n, n];
        for (int i = 0; i < n; ++i)
        {
            int[] numbers = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int j = 0; j < numbers.Length; ++j)
            {
                triangle[i, j] = numbers[j];
            }
        }

        int[,] dp = new int[n, n];
        dp[0, 0] = triangle[0, 0];
        int maxSum = dp[0, 0];
        for (int row = 1; row < n; ++row)
        {
            int prevRow = row - 1;
            for (int col = 0; col < n; ++col)
            {
                int leftCol = col - 1;
                int leftNumber = NumberMin;
                if (IsValidIndex(leftCol))
                {
                    leftNumber = dp[prevRow, leftCol];
                }

                int rightCol = col;
                int rightNumber = NumberMin;
                if (IsValidIndex(rightCol))
                {
                    rightNumber = dp[prevRow, rightCol];
                }

                int sum = Math.Max(leftNumber, rightNumber) + triangle[row, col];

                if ((row == n - 1) && (sum > maxSum))
                    maxSum = sum;

                dp[row, col] = sum;
            }
        }
        Console.Write(maxSum);
    }
}