using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        BigInteger[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), BigInteger.Parse);

        Console.Write(tokens[0] + tokens[1]);
    }
}