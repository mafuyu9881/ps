using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);
        
        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [1, 10]
            int m = tokens[1]; // [1, 2'000]

            long[][] dp = new long[n + 1][];
            for (int j = 0; j < dp.Length; ++j)
            {
                dp[j] = new long[m + 1];
            }
            for (int j = 1; j < dp[1].Length; ++j)
            {
                dp[1][j] = j;
            }
            for (int j = 2; j < dp.Length; ++j)
            {
                for (int k = ExponentiationBySquaringIteratively(2, j - 1); k < dp[j].Length; ++k)
                {
                    dp[j][k] = dp[j - 1][k / 2] + dp[j][k - 1];
                }
            }
            sb.AppendLine($"{dp[n][m]}");
        }
        Console.Write(sb);
    }

    private static int ExponentiationBySquaringIteratively(int basis, int exponent)
    {
        int output = 1;
        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
            {
                output *= basis;
            }
            basis *= basis;
            exponent >>= 1;
        }
        return output;
    }
}