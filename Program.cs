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
            for (int i = 0; i < cows.Length; ++i)
            {
                if (cows[i] > n)
                    break;

                for (int j = i + 1; j < cows.Length; ++j)
                {
                    if (cows[i] + cows[j] > s)
                        break;

                    ++pairs;
                }
            }
        }
        Console.Write(pairs);
    }
}