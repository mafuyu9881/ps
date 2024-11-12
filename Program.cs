internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int k = tokens[1];

        int[] volumes = new int[n];
        for (int i = 0; i < n; ++i)
        {
            volumes[i] = int.Parse(Console.ReadLine()!);
        }

        long output = 0;
        if (n > 0)
        {
            long low = 0 - 1;
            long high = int.MaxValue + 1L;
            while (low < high - 1)
            {
                long mid = (low + high) / 2;

                long distributed = 0;
                if (mid == 0)
                {
                    distributed = k; // can distribute always
                }
                else
                {
                    for (int i = 0; i < n; ++i)
                    {
                        distributed += volumes[i] / mid;
                    }
                }

                if (distributed < k)
                {
                    high = mid;
                }
                else
                {
                    low = mid;
                }
            }
            output = low;
        }
        Console.Write(output);
    }
}