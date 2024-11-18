using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // −10^9 ≤ x, y ≤ 10^9
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            output.AppendLine($"{tokens[0] + tokens[1]}");
        }
        Console.Write(output);
    }
}