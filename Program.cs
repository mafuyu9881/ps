class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 200'000]
        int k = tokens[1]; // [1, 1'000'000'000]
        int x = tokens[2]; // [1, 10]

        // length = [2, 200'000]
        // element = [1, 1'000]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[] prefixSums = new int[n + 1];
        for (int i = 0; i < n; ++i)
        {
            prefixSums[i + 1] = prefixSums[i] + tokens[i];
        }

        int entireSum = prefixSums[n];

        int hi = 0;
        int streak = 0;
        for (int lo = 0; lo <= n; ++lo)
        {
            if (hi < lo)
            {
                hi = lo;
            }

            while (hi <= n && k <= (x * prefixSums[lo]) + (entireSum - prefixSums[hi]))
            {
                ++hi;
            }

            streak = Math.Max(streak, (hi - 1) - lo);
        }
        Console.Write(streak != 0 ? streak : -1);
    }
}