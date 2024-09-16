using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();

        while (true)
        {
            string? input = Console.ReadLine();
            if (input == null)
                break;

            string[] tokens = input.Split();
            if (tokens == null)
                break;

            if (tokens.Length < 2)
                break;

            int a = int.Parse(tokens[0]);
            int b = int.Parse(tokens[1]);

            if (a == 0 && b == 0)
                break;

            output.AppendLine((a + b).ToString());
        }

        Console.Write(output);
    }
}

//Console.ReadKey();