using System.Text;

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

        int t = int.Parse(tokens[0]);

        StringBuilder output = new();

        for (int i = 0; i < t; ++i)
        {
            input = Console.ReadLine();
            if (input == null)
                continue;
            
            tokens = input.Split();
            if (tokens.Length < 2)
                continue;

            int a = int.Parse(tokens[0]);
            int b = int.Parse(tokens[1]);

            output.AppendLine((a + b).ToString());
        }
        
        Console.WriteLine(output);
    }
}

//Console.ReadKey();