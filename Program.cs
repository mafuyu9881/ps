class Program
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine()!;

        int wordLength = word.Length;

        string elected = null!;
        {
            for (int i = 1; i < wordLength - 1; ++i)
            {
                for (int j = i + 1; j < wordLength; ++j)
                {
                    string a = Reverse(word.Substring(0, i));
                    string b = Reverse(word.Substring(i, j - i));
                    string c = Reverse(word.Substring(j));

                    string candidate = a + b + c;

                    if (elected == null || string.CompareOrdinal(candidate, elected) < 0)
                    {
                        elected = candidate;
                    }
                }
            }
        }

        Console.Write(elected);
    }

    static string Reverse(string s)
    {
        char[] ca = s.ToCharArray();
        Array.Reverse(ca);
        return new(ca);
    }
}