using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine()!);

        BigInteger a = 0;
        BigInteger b = 1;
        for (int i = 2; i <= n; ++i)
        {
            BigInteger temp = a + b;
            a = b;
            b = temp;
        }

        Console.Write(b);
    }
}