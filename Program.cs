using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine()!;

        string[] tokens = input.Split();
        if (tokens == null || tokens.Length < 1)
            return;

        int t = int.Parse(tokens[0]);

        StringBuilder output = new();

        for (int i = 0; i < t; ++i)
        {
            input = Console.ReadLine()!;

            tokens = input.Split();
            if (tokens == null || tokens.Length < 2)
                continue;

            int a = int.Parse(tokens[0]);
            int b = int.Parse(tokens[1]);

            output.AppendLine($"Case #{i + 1}: {a} + {b} = {a + b}");
        }

        Console.Write(output);
    }
}