using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] multiples = new int[3] { 1, 3, 5 };

        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int g = tokens[0];
            int c = tokens[1];
            int e = tokens[2];

            output.AppendLine($"{Math.Max(0, e - c) * multiples[g - 1]}");
        }
        Console.Write(output);
    }
}