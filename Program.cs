using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string? input = Console.ReadLine();
        if (input == null)
            return;

        string[] tokens = input.Split();
        if (tokens == null)
            return;

        if (tokens.Length < 2)
            return;

        int h = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);
        m -= 45;

        if (m < 0)
        {
            h -= 1;
            m += 60;
        }

        if (h < 0)
        {
            h += 24;
        }

        Console.Write($"{h} {m}");
    }
}

//Console.ReadKey();