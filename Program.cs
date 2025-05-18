using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 200'000]
        int q = tokens[1]; // [1, 200'000]

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        long[] prefixSums = new long[n];
        prefixSums[0] = sequence[0];
        for (int i = 1; i < n; ++i)
        {
            prefixSums[i] = prefixSums[i - 1] + sequence[i];
        }

        int head = 0;

        StringBuilder sb = new();
        for (int i = 0; i < q; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int command = tokens[0];
            if (command == 1)
            {
                int k = tokens[1];
                head = (n + head - k) % n;
            }
            else if (command == 2)
            {
                int k = tokens[1];
                head = (head + k) % n;
            }
            else // if (command == 3)
            {
                // convert to 0-based
                int a = tokens[1] - 1;
                int b = tokens[2] - 1;

                int s = (head + a) % n;
                int e = (head + b) % n;

                if (s <= e)
                {
                    sb.AppendLine($"{prefixSums[e] - prefixSums[s] + sequence[s]}");
                }
                else
                {
                    sb.AppendLine($"{prefixSums[e] + prefixSums[n - 1] - prefixSums[s] + sequence[s]}");
                }
            }
        }
        Console.Write(sb);
    }
}