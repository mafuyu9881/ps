using System.Numerics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        BigInteger s = BigInteger.Parse(Console.ReadLine()!);
        BigInteger d = BigInteger.Parse(Console.ReadLine()!);

        BigInteger k = (s + d) / 2;
        BigInteger n = (s - d) / 2;

        StringBuilder sb = new();
        sb.AppendLine($"{k}");
        sb.AppendLine($"{n}");
        Console.Write(sb);
    }
}