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

        bool[] occupied = new bool[3000 + 1];

        int maxDishes = 0;
        {
            int lo = 0;
            int hi = 0;
            while (hi < dishes.Length)
            {
                int newDish = dishes[hi];

                if (occupied[newDish])
                {
                    while (occupied[newDish])
                    {
                        int oldDish = dishes[lo];
                        occupied[oldDish] = false;
                        ++lo;
                    }
                }

                occupied[newDish] = true;
                ++hi;

                while (hi - lo > k)
                {
                    int oldDish = dishes[lo];
                    occupied[oldDish] = false;
                    ++lo;
                }

                if (hi - lo == k)
                {
                    maxDishes = Math.Max(maxDishes, occupied[c] ? k : k + 1);
                }
            }
        }
        Console.Write(maxDishes);
    }
}