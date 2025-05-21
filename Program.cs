internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        int[] prefixSums = new int[1000000 + 1];

        for (int i = 0; i < n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            int s = Parse(tokens[0]);
            int e = Parse(tokens[1]);
            prefixSums[s] += 1;
            prefixSums[e + 1] -= 1;
        }

        for (int ym = 1; ym < prefixSums.Length; ++ym)
        {
            prefixSums[ym] += prefixSums[ym - 1];
        }

        int maxEarliestYM = 0;
        {
            int maxFriends = 0;
            for (int ym = 0; ym < prefixSums.Length; ++ym)
            {
                int friends = prefixSums[ym];
                if (friends > maxFriends)
                {
                    maxFriends = friends;
                    maxEarliestYM = ym;
                }
            }
        }
        Console.Write(Serialize(maxEarliestYM));
    }

    private static int Parse(string token)
    {
        string[] tokens = token.Split('-');
        int y = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);
        return y * 100 + m;
    }

    private static string Serialize(int ym)
    {
        //int m = 0;
        //for (int i = 0; i < 2; ++i)
        //{
        //    int modulus = ExponentiationBySquaringIteratively(10, i + 1);
        //    int divisor = ExponentiationBySquaringIteratively(10, i);
        //    m += ((ym % modulus) / divisor) * ExponentiationBySquaringIteratively(10, i);
        //}

        //int y = 0;
        //for (int i = 2; i < 6; ++i)
        //{
        //    int modulus = ExponentiationBySquaringIteratively(10, i + 1);
        //    int divisor = ExponentiationBySquaringIteratively(10, i);
        //    y += ((ym % modulus) / divisor) * ExponentiationBySquaringIteratively(10, i - 2);
        //}

        int m = ym % ExponentiationBySquaringIteratively(10, 2);
        int y = ym / ExponentiationBySquaringIteratively(10, 2);

        return $"{y.ToString("D4")}-{m.ToString("D2")}";
    }

    private static int ExponentiationBySquaringIteratively(int basis, int exponent)
    {
        int output = 1;
        while (exponent > 0)
        {
            if (exponent % 2 == 1)
            {
                output *= basis;
            }
            basis *= basis;
            exponent >>= 1;
        }
        return output;
    }
}