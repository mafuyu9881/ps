internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100'000]
        int m = tokens[1]; // [1, 1'000'000'000]

        // length = [1, n] = [1, 100'000]
        // element = [1, 1'000'000'000]
        int[] stats = new int[n];
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int i = 0; i < stats.Length; ++i)
            {
                stats[i] = tokens[i];
            }
            Array.Sort(stats);
        }

        int teams = 0;
        {
            int i = 0;
            int j = stats.Length - 1;

            while (i < j)
            {
                int sum = stats[i] + stats[j];
                if (sum < m)
                {
                    ++i;
                }
                else
                {
                    ++teams;
                    ++i;
                    --j;
                }
            }
        }
        Console.Write(teams);
    }
}