internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 5'000]

        // element = [1, 1'000'000]
        long[] rocks = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);

        const int InvalidCost = -1;

        long[] cost = new long[n];

        for (int i = 0; i < cost.Length; ++i) // max tc = 5'000
        {
            cost[i] = InvalidCost;
        }

        for (int s = 0; s < cost.Length; ++s) // max tc = 5'000
        {
            long sCost = cost[s];

            for (int i = s + 1; i < cost.Length; ++i) // max tc = 4'999
            {
                long iOldCost = cost[i];
                long iNewCost = Math.Max(sCost, (i - s) * (1 + Math.Abs(rocks[i] - rocks[s])));

                if (iOldCost != InvalidCost && iOldCost <= iNewCost)
                    continue;

                cost[i] = iNewCost;
            }
        }

        Console.Write(cost[cost.Length - 1]);
    }
}