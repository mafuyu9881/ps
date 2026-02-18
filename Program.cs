class Program
{
    static void Main(string[] args)
    {
        int[] naturals = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int naturalsLength = naturals.Length;

        const int Invalid = -1;
        int output = Invalid;
        for (int i = 0; i < naturalsLength; ++i)
        {
            for (int j = i + 1; j < naturalsLength; ++j)
            {
                for (int k = j + 1; k < naturalsLength; ++k)
                {
                    int lcd = LCD(LCD(naturals[i], naturals[j]), naturals[k]);
                    if (output == Invalid || lcd < output)
                    {
                        output = lcd;
                    }
                }
            }
        }
        Console.Write(output);
    }

    static int GCD(int a, int b)
    {
        int min = Math.Min(a, b);

        for (int i = min; i > 0; --i)
        {
            if (a % i == 0 && b % i == 0)
            {
                return i;
            }
        }

        return 1;
    }

    static int LCD(int a, int b)
    {
        return a * b / GCD(a, b);
    }
}