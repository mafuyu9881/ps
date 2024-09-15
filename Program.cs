internal class Program
{
    private static void Main(string[] args)
    {
        string? input = Console.ReadLine();

        if (input == null)
            return;
        
        string[] tokens = input.Split();
        if (tokens.Length < 5)
            return;
        
        int i = 0;
        for (int j = 0; j < tokens.Length; ++j)
        {
            int k = int.Parse(tokens[j]);
            i += k * k;
        }
        Console.Write(i % 10);
    }
}

//Console.ReadKey();