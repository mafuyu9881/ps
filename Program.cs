using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        BigInteger a = 1;
        BigInteger b = 1;

        for (int i = 3; i <= n; ++i)
        {
            BigInteger temp = a + b;
            a = b;
            b = temp;
        }

        Console.Write(b);
    }
}