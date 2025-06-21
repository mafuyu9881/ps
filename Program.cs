class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 3'000'000]
        int d = tokens[1]; // [2, 3'000]
        int k = tokens[2]; // [2, 3'000]
        int c = tokens[3]; // [1, d] = [1, 3'000]

        int[] dishes = new int[n * 2];
        for (int i = 0; i < n; ++i)
        {
            dishes[i] = int.Parse(Console.ReadLine()!);
        }
        for (int i = 0; i < n; ++i)
        {
            dishes[n + i] = dishes[i];
        }

        int maxKinds = 0;
        {
            int[] occupied = new int[d + 1];
            int lo = 0;
            int hi = 0;
            int kinds = 0;
            while (hi < dishes.Length)
            {
                if (hi < k)
                {
                    while (hi < k)
                    {
                        int newDish = dishes[hi];
                        if (occupied[newDish] == 0)
                        {
                            ++kinds;
                        }
                        ++occupied[newDish];
                        ++hi;
                    }
                }
                else
                {
                    int oldDish = dishes[lo];
                    --occupied[oldDish];
                    if (occupied[oldDish] == 0)
                    {
                        --kinds;
                    }
                    int newDish = dishes[hi];
                    if (occupied[newDish] == 0)
                    {
                        ++kinds;
                    }
                    ++occupied[newDish];
                    ++lo;
                    ++hi;
                }
                maxKinds = Math.Max(maxKinds, (occupied[c] > 0) ? kinds : kinds + 1);
            }
        }
        Console.Write(maxKinds);
    }
}