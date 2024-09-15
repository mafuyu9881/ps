internal class Program
{
    private static void Main(string[] args)
    {
        string? input = Console.ReadLine();
        if (input == null)
            return;
        
        string[] tokens = input.Split();
        if (tokens.Length < 1)
            return;

        int score = int.Parse(tokens[0]);

        Tuple<int, char>[] cutoffs =
        {
            new (90, 'A'),
            new (80, 'B'),
            new (70, 'C'),
            new (60, 'D'),
        };

        int cutoffsLength = cutoffs.Length;
        for (int i = 0; i < cutoffsLength; ++i)
        {
            var cutoff = cutoffs[i];
            if (score >= cutoff.Item1)
            {
                Console.Write(cutoff.Item2);
                return;
            }
        }
        
        Console.Write('F');
    }
}

//Console.ReadKey();