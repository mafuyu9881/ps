using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            long n = long.Parse(Console.ReadLine()!);

            long lo = 1 - 1;
            long hi = Math.Min(n + 1, 200000000);
            while (lo < hi - 1)
            {
                long mid = (lo + hi) / 2;

                long prefixSum = mid * (mid + 1) / 2;

                if (prefixSum <= n)
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }
            }
            sb.AppendLine($"{lo}");
        }
        Console.Write(sb);
    }
}