class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 2'000]

        // length = n = [1, 2'000]
        // element = [1, 1'000'000'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int goods = 0;
        {
            SortedSet<int> ss = new();
            for (int i = 0; i < n; ++i)
            {
                ss.Add(tokens[i]);
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    int sum = tokens[i] + tokens[j];
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