class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 2'000]

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int goods = 0;
        {
            SortedDictionary<int, int> sd = new();
            for (int i = 0; i < n; ++i)
            {
                sd.Add(sequence[i], 1);
            }

            for (int lo = 0; lo < n; ++lo)
            {
                for (int hi = lo + 1; hi < n; ++hi)
                {
                    int sum = sequence[lo] + sequence[hi];
                    if (sd.ContainsKey(sum))
                    {
                        --sd[sum];
                        ++goods;

                        if (sd[sum] < 1)
                        {
                            sd.Remove(sum);
                        }
                    }
                }
            }
        }
        Console.Write(goods);
    }
}