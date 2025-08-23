using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        BigInteger a = BigInteger.Parse(Console.ReadLine()!);
        BigInteger b = BigInteger.Parse(Console.ReadLine()!);
        BigInteger c = BigInteger.Parse(Console.ReadLine()!);
        Console.Write((b - c) / a);
    }
}