using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // length = 3
        // element = [2, 10'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];
        int c = tokens[2];

        StringBuilder sb = new();
        sb.AppendLine($"{(a + b) % c}");
        sb.AppendLine($"{((a % c) + (b % c)) % c}");
        sb.AppendLine($"{(a * b) % c}");
        sb.AppendLine($"{((a % c) * (b % c)) % c}");
        Console.Write(sb);
    }
}