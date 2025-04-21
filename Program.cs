internal class Program
{
    private static void Main(string[] args)
    {
        const int MaxElement = 10;

        int n = int.Parse(Console.ReadLine()!); // [1, 1'000'000]

        // length = [1, n] = [1, 1'000'000]
        // element = [1, 10]
        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[] counts = new int[MaxElement + 1];

        int maxStreak = 0;
        {
            int i = -1;
            int j = -1;
            int max = 10 + 1;
            int min = 0;
            while (true)
            {
                if (max - min > 2)
                {
                    if (i >= 0 && i < sequence.Length)
                    {
                        --counts[sequence[i]];
                    }

                    ++i;
                    ++j;

                    if (j >= 0 && j < sequence.Length)
                    {
                        ++counts[sequence[j]];
                    }
                }
                else
                {
                    ++j;

                    if (j >= 0 && j < sequence.Length)
                    {
                        ++counts[sequence[j]];
                    }
                }

                for (int k = 1; k < counts.Length; ++k)
                {
                    if (counts[k] > 0)
                    {
                        min = k;
                        break;
                    }
                }

                for (int k = counts.Length - 1; k >= 0; --k)
                {
                    if (counts[k] > 0)
                    {
                        max = k;
                        break;
                    }
                }

                if (j < sequence.Length)
                {
                    if (max - min <= 2)
                    {
                        maxStreak = Math.Max(maxStreak, j - i + 1);
                    }
                }
                else
                {
                    break;
                }
            }
        }
        Console.Write(maxStreak);
    }
}