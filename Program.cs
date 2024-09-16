using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // n을 읽고 버린다.
        string? input = Console.ReadLine();
        input = Console.ReadLine();
        if (input == null)
            return;

        string[] tokens = input.Split();
        if (tokens == null)
            return;

        int tokensLength = tokens.Length;
        if (tokensLength < 1)
            return;

        int? min = null;
        int? max = null;
        for (int i = 0; i < tokensLength; ++i)
        {
            int num = int.Parse(tokens[i]);
            
            if (min == null || num < min)
                min = num;

            if (max == null || num > max)
                max = num;
        }

        Console.WriteLine($"{min} {max}");
    }
}

//Console.ReadKey();