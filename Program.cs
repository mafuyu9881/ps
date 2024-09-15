internal class Program
{
    private static void Main(string[] args)
    {
        string? input = Console.ReadLine();

        if (input == null)
            return;
        
        string[] tokens = input.Split();
        if (tokens.Length < 2)
            return;

        int token0 = int.Parse(tokens[0]);
        int token1 = int.Parse(tokens[1]);

        if (token0 > token1)
        {
            Console.Write('>');
        }
        else if (token0 < token1)
        {
            Console.Write('<');
        }
        else
        {
            Console.WriteLine("==");
        }
    }
}

//Console.ReadKey();