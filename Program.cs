using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        StringBuilder sb = new();
        while (true)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [1, 10'000]
            int m = tokens[1]; // [1, 100]
            if (n == 0 && m == 0)
                break;

            (int s, int e)[] calls = new (int, int)[n];
            for (int i = 0; i < n; ++i) // max tc = 10'000
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int source = tokens[0]; // [0, 10'000'000]
                int destination = tokens[1]; // [0, 10'000'000]
                int start = tokens[2]; // start + duration = [0, 2^31]
                int duration = tokens[3]; // [1, 10'000]

                calls[i] = (start, start + duration - 1);
            }

            for (int i = 0; i < m; ++i) // max tc = 100
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int start = tokens[0];
                int duration = tokens[1];
                int s = start;
                int e = start + duration - 1;

                int detected = 0;
                for (int j = 0; j < n; ++j)
                {
                    if ((e < calls[j].s || s > calls[j].e) == false)
                    {
                        ++detected;
                    }
                }
                sb.AppendLine($"{detected}");
            }
        }
        Console.Write(sb);
    }
}