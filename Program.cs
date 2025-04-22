internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int k = int.Parse(Console.ReadLine()!); // [1, 1'000'000'000]

        int pairs = 0;
        {
            int i = 0;
            int j = -1;
            int sum = 0;
            while (true)
            {
                if (sum > k)
                {
                    sum -= sequence[i];
                    ++i;
                    ++j;
                }
                else
                {
                    ++j;
                }

                if (j > sequence.Length - 1)
                    break;

                sum += sequence[j];

                if (sum > k)
                {
                    pairs += (sequence.Length - 1) - (j) + 1;
                }
            }
        }
        Console.Write(pairs);
    }
}