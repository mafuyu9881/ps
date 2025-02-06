using System.Text;

internal class Program
{
    // _dp[78] = 14'472'334'024'676'221 > 10 ^ 16
    private static long[] _dp = new long[78]; // so, we don't need to search above 78

    private static void Main(string[] args)
    {
        _dp[0] = 1;
        _dp[1] = 1;
        for (int i = 2; i < _dp.Length; ++i)
        {
            _dp[i] = _dp[i - 1] + _dp[i - 2];
        }

        int t = int.Parse(Console.ReadLine()!); // [1, 100]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
            long k = tokens[0]; // [1, 3]
            long x = tokens[1]; // [1, 10^16]
            sb.AppendLine(Solve(k, x, 0, 0) ? "YES" : "NO");
        }
        Console.Write(sb);
    }

    private static bool Solve(long k, long x, long sum, int depth)
    {
        if (depth == k)
        {
            return sum == x;
        }
        else
        {
            for (int i = 0; i < _dp.Length; ++i) // tc = 78
            {
                if (Solve(k, x, sum + _dp[i], depth + 1))
                {
                    return true;
                }
            }

            return false;
        }
    }
}