internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 10'000]
        int m = tokens[1]; // [1, 300'000'000]

        // length = [1, 10'000]
        // element = [1, 30'000]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int cases = 0;
        {
            for (int i = 0; i < tokens.Length; ++i)
            {
                int sum = 0;
                for (int j = i; j < tokens.Length; ++j)
                {
                    sum += tokens[j];

                    if (sum >= m)
                    {
                        if (sum == m)
                        {
                            ++cases;
                        }
                        break;
                    }
                }
            }
        }
        Console.Write(cases);
    }
}