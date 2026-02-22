using System.Numerics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        const int Max = 490;

        BigInteger[] fibonacci = new BigInteger[Max + 1];
        {
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            fibonacci[2] = 1;
            for (int i = 3; i <= Max; ++i)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }
        }

        StringBuilder output = new();
        {
            while (true)
            {
                int x = int.Parse(Console.ReadLine()!);
                if (x == -1)
                    break;

                output.AppendLine($"Hour {x}: {fibonacci[x]} cow(s) affected");
            }
        }

        Console.Write(output);
    }
}