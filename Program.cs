class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(sequence);

        int goods = 0;
        for (int i = 0; i < n; ++i)
        {
            int expected = sequence[i];

            int lo = 0;
            int hi = n - 1;
            while (true)
            {
                if (lo == i)
                    ++lo;

                if (hi == i)
                    --hi;

                if (lo >= hi)
                    break;

                int sum = sequence[lo] + sequence[hi];
                if (sum < expected)
                {
                    ++lo;
                }
                else if (sum > expected)
                {
                    --hi;
                }
                else
                {
                    ++goods;
                    break;
                }
            }
        }
        Console.Write(goods);
    }
}