internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int width = tokens[0]; // [3, 100'000]
        int walls = tokens[1]; // [0, N) = [0, 100'000)
        int students = tokens[2]; // [1, 100'000]

        int[] map = new int[width + 1];
        long[] mapPrefixSums = new long[width + 1];
        for (int i = 0; i < walls; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int pos = tokens[0]; // [1, N] = [1, 100'000]
            int durability = tokens[1]; // [1, 100'000]
        }

        for (int i = 1; i <= width; ++i)
        {
            mapPrefixSums[i] = mapPrefixSums[i - 1] + map[i];
        }

        for (int i = 0; i < students; ++i)
        {
            int pos = int.Parse(Console.ReadLine()!);

            long leftDurabilities = mapPrefixSums[pos - 1];
            long rightDurabilities = mapPrefixSums[width] - mapPrefixSums[pos];
        }
    }
}