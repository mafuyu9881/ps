class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [10, 100'000]
        int s = tokens[1]; // [0, 100'000'000]

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        long[] prefixSums = new long[n];
        prefixSums[0] = sequence[0];
        for (int i = 1; i < n; ++i)
        {
            prefixSums[i] = prefixSums[i - 1] + sequence[i];
        }

        int minLength = 100000 + 1;
        {
            long entireSum = prefixSums[n - 1];
            if (entireSum < s)
            {
                minLength = 0;
            }
            else
            {
                long sum = entireSum;
                int lo = 0;
                int hi = n - 1;
                while (lo < hi && sum >= s)
                {
                    if (sequence[lo] < sequence[hi])
                    {
                        sum -= sequence[lo];
                        ++lo;
                    }
                    else
                    {
                        sum -= sequence[hi];
                        --hi;
                    }
                }
                minLength = hi - lo + 2;
            }
        }
        Console.Write(minLength);
    }
}