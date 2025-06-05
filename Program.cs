class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 2'000]

        bool[] visited = new bool[n];
        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(sequence);

        int goods = 0;
        {
            const int InvalidIndex = -1;

            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    int sum = sequence[i] + sequence[j];

                    int lo = 0 - 1;
                    int hi = (n - 1) + 1;
                    int index = InvalidIndex;
                    while (lo < hi - 1)
                    {
                        int mid = (lo + hi) / 2;

                        int num = sequence[mid];
                        if (num < sum)
                        {
                            lo = mid;

                            int next = (lo + hi) / 2;
                            if (i == next || j == next)
                            {
                                ++lo;
                            }
                        }
                        else if (num > sum)
                        {
                            hi = mid;

                            int next = (lo + hi) / 2;
                            if (i == next || j == next)
                            {
                                --hi;
                            }
                        }
                        else
                        {
                            index = mid;
                            break;
                        }
                    }

                    if (index != InvalidIndex && visited[index] == false)
                    {
                        visited[index] = true;
                        ++goods;
                    }
                }
            }
        }
        Console.Write(goods);
    }
}