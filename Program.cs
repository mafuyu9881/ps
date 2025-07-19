using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // length = 2
        // element = [1, 100'000]
        int[] integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = integerTokens[0];
        int m = integerTokens[1];

        // length = n
        // element = [1, 10^18]
        long[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        Array.Sort(sequence);

        StringBuilder sb = new();
        for (int l = 0; l < m; ++l) // max tc = 100'000
        {
            long[] longTokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
            long q = longTokens[0]; // [1, 3]

            if (q == 1)
            {
                long k = longTokens[1];
                sb.AppendLine($"{(n - 1) - LowerBound(sequence, k) + 1}");
            }
            else if (q == 2)
            {
                long k = longTokens[1];
                sb.AppendLine($"{(n - 1) - LowerBound(sequence, k + 1) + 1}");
            }
            else // if (q == 3)
            {
                long i = longTokens[1];
                long j = longTokens[2];
                sb.AppendLine($"{(UpperBound(sequence, j) - 1) - LowerBound(sequence, i) + 1}");
            }
        }
        Console.Write(sb);
    }

    static int LowerBound(long[] sequence, long num)
    {
        int lo = 0 - 1;
        int hi = (sequence.Length - 1) + 1;
        while (lo < hi - 1)
        {
            int mid = (lo + hi) / 2;

            if (sequence[mid] < num)
            {
                lo = mid;
            }
            else
            {
                hi = mid;
            }
        }
        return hi;
    }

    static int UpperBound(long[] sequence, long num)
    {
        int lo = 0 - 1;
        int hi = (sequence.Length - 1) + 1;
        while (lo < hi - 1)
        {
            int mid = (lo + hi) / 2;

            if (sequence[mid] <= num)
            {
                lo = mid;
            }
            else
            {
                hi = mid;
            }
        }
        return hi;
    }
}