using System.Text;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new();
        {
            while (true)
            {
                BigInteger n = BigInteger.Parse(Console.ReadLine()!);
                if (n == 0)
                    break;

                output.AppendLine((n % 42 == 0) ? "PREMIADO" : "TENTE NOVAMENTE");
            }
        }

        Console.Write(output);
    }
}