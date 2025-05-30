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

        int earned = 0;
        int lo = 0 - 1;
        int hi = (n - 1) + 1;
        while (lo < hi - 1 && earned < k)
        {
            int loEarned = tokens[lo + 1] * x;
            int hiEarned = tokens[hi - 1] * x;
            if (loEarned < hiEarned)
            {
                earned += hiEarned;
                --hi;
            }
            else
            {
                earned += loEarned;
                ++lo;
            }
        }

        int streak = hi - lo - 1;
        if (streak < 1)
        {
            streak = -1;
        }
        Console.Write(streak);
    }
}