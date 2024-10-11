using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();
        string input;
        while ((input = Console.ReadLine()!) != null)
        {
            int[] tokens = Array.ConvertAll(input.Split(), int.Parse);

            int n = tokens[0];
            int s = tokens[1];

            output.AppendLine($"{s / (n + 1)}");
        }
        Console.Write(output);
    }
}