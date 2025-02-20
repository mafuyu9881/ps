using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [1, 10]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 10
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [1, 10]
            int m = tokens[1]; // [1, 2'000]

            int output = 0;
            Solve(ref output, n, m, 1, 1);
            sb.AppendLine($"{output}");
        }
        Console.Write(sb);
    }

    private static void Solve(ref int output, int n, int m, int currBeginNumber, int depth)
    {
        if (depth < n)
        {
            for (int i = currBeginNumber; i <= m; ++i)
            {
                int nextBeginNumber = i * 2;
                if (nextBeginNumber > m)
                    break;

                Solve(ref output, n, m, nextBeginNumber, depth + 1);
            }
        }
        else
        {
            output += m - currBeginNumber + 1;
        }
    }
}