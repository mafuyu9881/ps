using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        Dictionary<string, string> dictionary = new();
        for (int i = 0; i < n; ++i)
        {
            tokens = Console.ReadLine()!.Split();

            dictionary.Add(tokens[0], tokens[1]);
        }

        StringBuilder output = new();
        for (int i = 0; i < m; ++i)
        {
            output.AppendLine(dictionary[Console.ReadLine()!]);
        }
        Console.Write(output);
    }
}