using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [1, 1'000'000]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 1'000'000
        {
            // element = [1, 1'000]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            sb.AppendLine($"{tokens[0] + tokens[1]}");
        }
        Console.Write(sb);
    }
}