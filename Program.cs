internal class Program
{
    private static bool[] _s = new bool[1001];

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 1'000]
        int m = tokens[1]; // [0, 50]

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // element = [1, 1'000]
        for (int i = 0; i < tokens.Length; ++i) // max tc = 50
        {
            _s[tokens[i]] = true;
        }

        int diff = 0;
        int[] directions = new int[] { 1, -1 };
        while (true)
        {
            for (int i = 0; i < directions.Length; ++i)
            {
                int objective = n + diff * directions[i];

                if (objective < 1)
                    continue;

                if (Validation(1, objective) == false)
                    continue;

                goto End;
            }

            ++diff;
        }
End:
        Console.Write(diff);
    }

    private static bool Validation(int factor, int n)
    {
        while (_s[factor] || (n % factor != 0))
        {
            ++factor;
        }

        //if (factor > n)
        //    return false;

        
    }
}