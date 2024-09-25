using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        BigInteger a = BigInteger.Parse(tokens[0]);
        BigInteger b = BigInteger.Parse(tokens[1]);

        Console.Write(a + b);
    }
}