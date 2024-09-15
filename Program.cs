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
        
        int n = int.Parse(tokens[0]);

        StringBuilder output = new StringBuilder();
        for (int i = 1; i <= n; ++i)
        {
            output.AppendLine(i.ToString());
        }
        Console.WriteLine(output);
    }
}

//Console.ReadKey();