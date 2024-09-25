// 시간 제한: 2초
// 메모리 제한: 256MB
// 1 ≤ M ≤ N ≤ 1,000,000

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int m = int.Parse(tokens[0]);
        int n = int.Parse(tokens[1]);

        StringBuilder output = new();
        for (int i = m; i <= n; ++i)
        {
            if (is_prime(i))
            {
                output.AppendLine(i.ToString());
            }
        }
        Console.Write(output);
    }

    private static bool is_prime(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); ++i)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}