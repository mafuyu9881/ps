using System.Text;

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

        int n = int.Parse(tokens[0]);
        int x = int.Parse(tokens[1]);

        input = Console.ReadLine();
        if (input == null)
            return;

        tokens = input.Split();
        if (tokens.Length < n)
            return;

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            int m = int.Parse(tokens[i]);
            if (x > m)
            {
                output.Append($"{m} ");
            }
        }
        Console.Write(output);
    }
}

//Console.ReadKey();