internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 5'000]

        // element = [1, 1'000'000]
        int[] rocks = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        const int InvalidCost = -1;

        int[] cost = new int[n];

        for (int i = 0; i < cost.Length; ++i) // max tc = 5'000
        {
            cost[i] = InvalidCost;
        }

        for (int s = 0; s < cost.Length; ++s) // max tc = 5'000
        {
            int sCost = cost[s];

            for (int i = s + 1; i < cost.Length; ++i) // max tc = 4'999
            {
                int iOldCost = cost[i];
                int iNewCost = Math.Max(sCost, (i - s) * (1 + Math.Abs(rocks[i] - rocks[s])));

                if (iOldCost != InvalidCost && iOldCost <= iNewCost)
                    continue;

                cost[i] = iNewCost;
            }
        }

        Console.Write(cost[cost.Length - 1]);
    }
}