class Program
{
    static void Main(string[] args)
    {
        const int Max = 10000;

        Func<int, long> Combination2 = (n) =>
        {
            return n * (n - 1) / 2;
        };

        Func<int, long> Combination3 = (n) =>
        {
            return n * (n - 1) * (n - 2) / 6;
        };

        int n = int.Parse(Console.ReadLine()!); // [1, 10'000]

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(sequence);

        int[] counts = new int[20000 + 1];
        List<int> uniqueSequence = new();
        for (int i = 0; i < n; ++i)
        {
            int elem = sequence[i];

            ++counts[elem + Max];

            if (uniqueSequence.Count == 0 ||
                uniqueSequence[uniqueSequence.Count - 1] != elem)
            {
                uniqueSequence.Add(elem);
            }
        }

        long teams = 0;
        for (int i = 0; i < uniqueSequence.Count; ++i)
        {
            int lo = 0;
            int hi = uniqueSequence.Count - 1;
            while (true)
            {
                if (lo == i)
                    ++lo;

                if (hi == i)
                    --hi;

                if (lo >= hi)
                    break;

                int sum = uniqueSequence[i] + uniqueSequence[lo] + uniqueSequence[hi];
                if (sum < 0)
                {
                    ++lo;
                }
                else if (sum > 0)
                {
                    --hi;
                }
                else
                {
                    teams += counts[uniqueSequence[i] + Max] * counts[uniqueSequence[lo] + Max] * counts[uniqueSequence[hi] + Max];
                    ++lo;
                    --hi;
                }
            }
        }
        teams /= 3;
        for (int i = 0; i < uniqueSequence.Count; ++i)
        {
            if (uniqueSequence[i] % 2 == 0)
            {
                if (uniqueSequence[i] == 0)
                {
                    long num = counts[0 + Max];
                    teams += num * (num - 1) * (num - 2) / 6;
                }
                else
                {
                    int num = counts[-(uniqueSequence[i] / 2) + Max];
                    teams += counts[uniqueSequence[i] + Max] * (long)(num * (num - 1) / 2);
                }
            }
        }
        Console.Write(teams);
    }
}