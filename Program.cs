class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 2'000]

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int goods = 0;
        {
            SortedSet<int> ss = new();
            for (int i = 0; i < n; ++i)
            {
                ss.Add(sequence[i]);
            }

            for (int lo = 0; lo < n; ++lo)
            {
                for (int hi = lo + 1; hi < n; ++hi)
                {
                    int sum = sequence[lo] + sequence[hi];
                    if (ss.Contains(sum))
                    {
                        ss.Remove(sum);
                        ++goods;
                    }
                }
            }
        }
        Console.Write(goods);
    }
}