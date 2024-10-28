using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            string s = Console.ReadLine()!;

            output.AppendLine($"{s[0]}{s[s.Length - 1]}");
        }
        Console.Write(output);
    }
}