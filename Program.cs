internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        const char D = 'D';
        const char K = 'K';
        const char S = 'S';
        const char H = 'H';
        
        SortedDictionary<char, char> previous = new()
        {
            { K, D },
            { S, K },
            { H, S },
        };

        SortedDictionary<char, long> combination = new()
        {
            { D, 0 },
            { K, 0 },
            { S, 0 },
            { H, 0 },
        };

        string token = Console.ReadLine()!;
        for (int i = 0; i < token.Length; ++i) // max tc = 100'000
        {
            char c = token[i];

            if (combination.ContainsKey(c)) // max tc = log2(4) = 2
            {
                if (c == D)
                {
                    ++combination[c]; // max tc = log2(4) = 2;
                }
                else
                {
                    combination[c] += combination[previous[c]]; // max tc = log2(4) + log2(4) + log2(3) = 5.xxx
                }
            }
        }
        Console.Write(combination[H]);
    }
}