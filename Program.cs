class Program
{
    static void Main(string[] args)
    {
        const string DKSH = "DKSH";

        string s = Console.ReadLine()!;

        int output = 0;
        for (int i = 0; i < s.Length - (DKSH.Length - 1); ++i)
        {
            int combo = 0;
            for (int j = 0; j < DKSH.Length && i + j < s.Length; ++j)
            {
                if (s[i + j] != DKSH[j])
                    break;

                ++combo;
            }

            if (combo < DKSH.Length)
                continue;

            ++output;
        }
        Console.Write(output);
    }
}