using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine()!);
        Console.Write(n % 20000303);
    }
}