internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int exN = n + 1;
        int k = tokens[1];
        int exK = k + 1;
        int[,] dp = new int[exN, exK];
        for (int row = 1; row < exN; ++row)
        {
            for (int col = 1; col < exK; ++col)
            {
                if (col == 1 || row == col)
                {
                    dp[row, col] = 1;
                }
                else
                {
                    dp[row, col] = dp[row - 1, col - 1] + dp[row - 1, col];
                }
            }
        }
        Console.Write(dp[n, k]);
    }
}