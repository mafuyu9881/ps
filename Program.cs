using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();
        int t = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int m = tokens[0]; // 1 ≤ m, n ≤ 40,000
            int n = tokens[1];
            int x = tokens[2]; // 1 ≤ x ≤ m
            int y = tokens[3]; // 1 ≤ y ≤ n
            output.AppendLine($"{ComputeYears(m, n, x, y)}");
        }
        Console.Write(output);
    }

    private static int GCD(int a, int b)
    {
        int bigger = Math.Max(a, b);
        int smaller = Math.Min(a, b);
        while (smaller != 0)
        {
            int r = bigger % smaller;
            bigger = smaller;
            smaller = r;
        }
        return bigger;
    }

    private static int LCM(int a, int b)
    {
        return a * b * GCD(a, b);
    }

    private static int ComputeYears(int m, int n, int x, int y)
    {
        if (m <= n)
        {
            int lcm = LCM(m, n);
            int loops = lcm / m;
            for (int i = 0; i < loops; ++i)
            {
                int currX = x;
                int currY = x + m * i - ((x + m * i - 1) / n) * n;
                if (currX == x && currY == y)
                {
                    return x + m * i;
                }
            }
            return -1;
        }
        else
        {
            int lcm = LCM(m, n);
            int loops = lcm / m;
            for (int i = 0; i < loops; ++i)
            {
                int currX = y + n * i - ((y + n * i - 1) / m) * m;
                int currY = y;
                if (currX == x && currY == y)
                {
                    return y + n * i;
                }
            }
            return -1;
        }
    }
}