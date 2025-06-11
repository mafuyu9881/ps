class Program
{
    static void Main(string[] args)
    {
        const int Max = 10000;

        int[,] combination = new int[Max + 1, Max + 1];
        for (int i = 0; i <= Max; ++i)
        {
            combination[i, 0] = 1;
            combination[i, i] = 1;
        }
        for (int row = 2; row <= Max; ++row)
        {
            for (int col = 1; col < row; ++col)
            {
                combination[row, col] = combination[row - 1, col - 1] + combination[row - 1, col];
            }
        }

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

        int teams = 0;
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
                // teams += counts[uniqueSequence[i] + Max] * (counts[-(uniqueSequence[i] / 2) + Max] / 2);
                teams += counts[uniqueSequence[i] + Max] * combination[counts[-(uniqueSequence[i] / 2) + Max], 2];
            }
        }
        Console.Write(teams);
    }
}