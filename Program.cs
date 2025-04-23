internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int k = int.Parse(Console.ReadLine()!); // [1, 1'000'000'000]

        long pairs = 0;
        {
            int right = 0;
            int sum = sequence[0];

            for (int left = 0; left < sequence.Length; ++left)
            {
                while (true)
                {
                    if (sum > k)
                    {
                        pairs += (sequence.Length - 1) - (right) + 1;
                        break;
                    }
                    else
                    {
                        if (right < sequence.Length - 1)
                        {
                            ++right;
                            sum += sequence[right];
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                sum -= sequence[left];
            }
        }
        Console.Write(pairs);
    }
}