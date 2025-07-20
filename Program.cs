class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        // length = 2
        // element = [1, 1'000'000]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int s = tokens[0];
        int p = tokens[1];

        string sequence = Console.ReadLine()!;

        // length = 4
        // element = [0, s]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int requiredA = tokens[0];
        int requiredC = tokens[1];
        int requiredG = tokens[2];
        int requiredT = tokens[3];

        int variations = 0;
        {
            int countA = 0;
            int countC = 0;
            int countG = 0;
            int countT = 0;
            int j = 0;
            for (int i = 0; i < sequence.Length - (p - 1); ++i)
            {
                while (j - i + 1 <= p)
                {
                    char c = sequence[j];
                    if (c == 'A')
                    {
                        ++countA;
                    }
                    else if (c == 'C')
                    {
                        ++countC;
                    }
                    else if (c == 'G')
                    {
                        ++countG;
                    }
                    else // if (c == 'T')
                    {
                        ++countT;
                    }
                    ++j;
                }

                if (countA >= requiredA &&
                    countC >= requiredC &&
                    countG >= requiredG &&
                    countT >= requiredT)
                {
                    ++variations;
                }

                {
                    char c = sequence[i];
                    if (c == 'A')
                    {
                        --countA;
                    }
                    else if (c == 'C')
                    {
                        --countC;
                    }
                    else if (c == 'G')
                    {
                        --countG;
                    }
                    else // if (c == 'T')
                    {
                        --countT;
                    }
                }
            }
        }
        Console.Write(variations);
    }
}