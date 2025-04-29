internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100'000]
        int m = tokens[1]; // [0, 2'000'000'000]

        int[] sequence = new int[n];
        for (int i = 0; i < n; ++i)
        {
            sequence[i] = int.Parse(Console.ReadLine()!);
        }
        Array.Sort(sequence);

        int minDiff = 2000000000;
        {
            int i = 0;
            int j = 0;
            while (i < sequence.Length && j < sequence.Length)
            {
                int diff = sequence[j] - sequence[i];

                if (diff >= m)
                {
                    minDiff = Math.Min(minDiff, diff);
                }

                if (diff > m)
                {
                    ++i;
                }
                else
                {
                    ++j;
                }
            }
        }
        Console.Write(minDiff);
    }
}