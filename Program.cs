using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string? input = Console.ReadLine();
        if (input == null)
            return;

        string[] tokens = input.Split();
        if (tokens == null || tokens.Length < 1)
            return;

        int t = int.Parse(tokens[0]);

        StringBuilder output = new();

        for (int i = 0; i < t; ++i)
        {
            input = Console.ReadLine();
            if (input == null)
                continue;

            tokens = input.Split();
            if (tokens == null || tokens.Length < 3)
                continue;

            int h = int.Parse(tokens[0]);
            int w = int.Parse(tokens[1]);
            int n = int.Parse(tokens[2]);

            int x = (n - 1) / h + 1;
            int y = n % h;
            if (y == 0)
                y = h;

            string xx;
            if (x < 10)
                xx = "0" + x.ToString();
            else
                xx = x.ToString();
            string yy = y.ToString();

            output.AppendLine(yy + xx);
        }

        Console.Write(output);
    }
}

//Console.ReadKey();