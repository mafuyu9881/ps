using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [1, 100'000]
            int m = tokens[1]; // [1, n] = [1, 100'000]
            int k = tokens[2]; // [1, 1'000'000'000]

            // length = [1, 100'000]
            // element = [1, 10'000]
            int[] town = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int[] prefixSums = new int[n];
            for (int j = 0; j < n; ++j)
            {
                prefixSums[j] = town[j];
            }
            for (int j = 1; j < n; ++j)
            {
                prefixSums[j] += prefixSums[j - 1];
            }

            int cases = 0;
            for (int j = 0; j < n; ++j)
            {
                int s = j;
                int e = (j + m - 1) % n;

                int stolen = 0;
                if (s > e)
                {
                    stolen += prefixSums[n - 1] - prefixSums[s] + town[s];
                    stolen += prefixSums[e] - prefixSums[0] + town[0];
                }
                else
                {
                    stolen += prefixSums[e] - prefixSums[s] + town[s];
                }

                if (stolen < k)
                {
                    ++cases;
                }
            }
            sb.AppendLine($"{cases}");
        }
        Console.Write(sb);
    }
}