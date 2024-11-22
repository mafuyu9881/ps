using System.Numerics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        BigInteger[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), BigInteger.Parse);
        BigInteger n = tokens[0];
        BigInteger m = tokens[1];
        
        StringBuilder output = new();
        output.AppendLine($"{n / m}");
        output.AppendLine($"{n % m}");
        Console.Write(output);
    }
}