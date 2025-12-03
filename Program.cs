using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            int n = int.Parse(Console.ReadLine()!);
            for (int j = 0; j < n; ++j)
            {
                int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int a = tokens[0];
                int b = tokens[1];
                sb.AppendLine($"{a + b} {a * b}");
            }
        }
        Console.Write(sb);
    }
}