using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;
        
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int n = int.Parse(Console.ReadLine()!);

            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int b = tokens[1];

            output.AppendLine($"Material Management {i + 1}");

            for (int j = 0; j < n; ++j)
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int u = tokens[0];
                int v = tokens[1];
            }

            output.AppendLine("Classification ---- End!");
        }
        Console.Write(output);
    }
}