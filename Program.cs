internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 20'000]
        int s = tokens[1]; // [1, 1'000'000]

        int[] cows = new int[n];
        for (int i = 0; i < cows.Length; ++i)
        {
            cows[i] = int.Parse(Console.ReadLine()!); // [1, 1'000'000]
        }
        Array.Sort(cows);

        int pairs = 0;
        {
            int i = 0;
            int j = 1;
            while (i < cows.Length && j < cows.Length)
            {
                int l = cows[i] + cows[j];

                if (l <= s)
                {
                    ++pairs;
                }

                if (l >= s)
                {
                    ++i;
                    j = i;
                }
                ++j;
            }
        }
        Console.Write(pairs);
    }
}