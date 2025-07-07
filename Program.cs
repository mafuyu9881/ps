class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [3, 5'000]

        // length = n
        // element = [-1'000'000'000, 1'000'000'000]
        int[] sols = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(sols);

        long minDiff = long.MaxValue;
        int[] minDiffSols = new int[3];
        for (int i = 0; i < n; ++i) // max tc = 5'000
        {
            int sol0 = sols[i];

            int lo = 0;
            int hi = n - 1;
            while (true)
            {
                if (lo == i)
                {
                    ++lo;
                }

                if (hi == i)
                {
                    --hi;
                }

                if (lo >= hi)
                    break;

                int sol1 = sols[lo];
                int sol2 = sols[hi];

                long sum = (long)sol0 + sol1 + sol2;
                long diff = Math.Abs(sum);

                if (diff < minDiff)
                {
                    minDiff = diff;
                    minDiffSols[0] = sol0;
                    minDiffSols[1] = sol1;
                    minDiffSols[2] = sol2;
                }

                if (sum < 0)
                {
                    ++lo;
                }
                else if (sum > 0)
                {
                    --hi;
                }
                else
                {
                    break;
                }
            }
        }
        Array.Sort(minDiffSols);
        Console.Write($"{minDiffSols[0]} {minDiffSols[1]} {minDiffSols[2]}");
    }
}