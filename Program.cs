internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 100'000]
        int k = tokens[1]; // [2, 100'000]
        int t = tokens[2]; // [0, 1'000'000'000]

        // length = [2, n] = [2, 100'000]
        // element = [0, k) = [0, 100'000)
        int[] baskets = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(baskets);

        int remains = 0;
        for (int i = 0; i < n; ++i) // max tc = 100'000
        {
            remains += baskets[i];
        }

        int moves = 0;
        int l = 0;
        int r = n - 1;
        while (l < r)
        {
            int moved = Math.Min(baskets[l], k - baskets[r]);
            
            moves += moved;

            baskets[l] -= moved;
            if (baskets[l] == 0)
            {
                ++l;
            }

            baskets[r] += moved;
            if (baskets[r] == k)
            {
                remains -= k;
                --r;
            }
        }

        Console.Write((moves > t || remains > 0) ? "NO" : "YES");
    }
}