using System.Text;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder output = new();
        for (int t = 0; t < 3; ++t)
        {
            int n = int.Parse(Console.ReadLine()!);

            BigInteger sum = 0;
            for (int i = 0; i < n; ++i)
            {
                sum += long.Parse(Console.ReadLine()!);
            }
            
            string sign = "0";
            if (sum > 0)
            {
                sign = "+";
            }
            else if (sum < 0)
            {
                sign = "-";
            }
            output.AppendLine(sign);
        }
        Console.Write(output);
    }
}