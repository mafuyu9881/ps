class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 300'000]
        int b = tokens[1]; // [0, 300'000]
        int w = tokens[2]; // [0, 300'000]

        LinkedList<int> wLL = new();
        {
            wLL.AddLast(0);

            string line = Console.ReadLine()!;
            for (int i = 0; i < n; ++i)
            {
                char c = line[i];
                if (c == 'W')
                {
                    ++wLL.Last!.ValueRef;
                }
                else
                {
                    wLL.AddLast(0);
                }
            }
        }

        int maxLength = 0;
        {
            int[] wArr = wLL.ToArray();
            int ws = 0;
            int hi = 0;
            int lo = 0;
            while (hi < wArr.Length)
            {
                if (hi <= b)
                {
                    while (hi <= b && hi < wArr.Length)
                    {
                        ws += wArr[hi];
                        ++hi;
                    }
                }
                else
                {
                    ws -= wArr[lo];
                    ws += wArr[hi];
                    ++lo;
                    ++hi;
                }

                if (ws >= w)
                {
                    maxLength = Math.Max(maxLength, ws + hi - lo);
                }
            }
        }
        Console.Write(maxLength);
    }
}