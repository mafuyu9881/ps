using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int c = ExponentiationBySquaringIteratively(2, 3);
        int d = ExponentiationBySquaringIteratively(2, 4);
        int e = ExponentiationBySquaringIteratively(3, 4);

        int t = int.Parse(Console.ReadLine()!); // [1, 1'000]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            // element = [1, 1'000'000]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int b = tokens[1];

            long rightProduct = a * (long)b;
            long wrongProduct = WrongMultiplication(a, b);
            
            sb.AppendLine(rightProduct == wrongProduct ? "1" : "0");
        }
        Console.Write(sb);
    }

    private static long WrongMultiplication(int a, int b)
    {
        string sa = a.ToString();
        string sb = b.ToString();
        
        string longerString;
        string shorterString;
        if (sa.Length > sb.Length)
        {
            longerString = sa;
            shorterString = sb;
        }
        else // if (sa.Length <= sb.Length)
        {
            longerString = sb;
            shorterString = sa;
        }

        long output = 0;

        int exceededLength = longerString.Length - shorterString.Length;
        for (int i = 0; i < exceededLength; ++i)
        {
            output *= 10;
            output += longerString[i] - '0';
        }

        for (int i = 0; i < shorterString.Length; ++i)
        {
            int product = (longerString[exceededLength + i] - '0') * (shorterString[i] - '0');

            output *= ExponentiationBySquaringIteratively(10, product.ToString().Length);
            output += product;
        }

        return output;
    }

    private static int ExponentiationBySquaringIteratively(int basis, int exponent)
    {
        int output = 1;
        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
            {
                output *= basis;
            }

            basis *= basis;
            exponent >>= 1;
        }
        return output;
    }
}