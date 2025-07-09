using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100]

        StringBuilder sb = new();
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0]; // [100, 1'000]
            int b = tokens[1]; // [100, 1'000]
            int x = tokens[2]; // [1, 100]
            sb.AppendLine($"{a * (x - 1) + b}");
        }
        Console.Write(sb);
    }
}