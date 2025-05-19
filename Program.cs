using System.Numerics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        BigInteger a = BigInteger.Parse(Console.ReadLine()!);
        BigInteger b = BigInteger.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        sb.AppendLine($"{a + b}");
        sb.AppendLine($"{a - b}");
        sb.AppendLine($"{a * b}");
        Console.Write(sb);
    }
}