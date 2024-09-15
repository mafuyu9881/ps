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

        int year = int.Parse(tokens[0]);

        bool leap = (year % 400 == 0) || ((year % 4 == 0) && (year % 100 != 0));
        Console.Write(leap ? 1 : 0);
    }
}

//Console.ReadKey();