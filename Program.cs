internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 500'000]
        int m = tokens[1]; // [1, 1'000'000'000]

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] holes = new int[tokens.Length];
        for (int i = 0; i < holes.Length; ++i)
        {
            holes[i] = tokens[i];
        }

        long maxUsedVolume = 0;
        {
            int i = 0;
            int j = 0;

            long usedVolume = holes[0];

            while (true)
            {
                if (usedVolume < m)
                {
                    maxUsedVolume = Math.Max(maxUsedVolume, usedVolume);

                    ++j;
                    if (j < holes.Length)
                    {
                        usedVolume += holes[j];
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    usedVolume -= holes[i];
                    ++i;
                }
            }
        }
        Console.Write(maxUsedVolume);
    }
}