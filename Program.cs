using System.Text;

internal class Program
{
    private static int[,] _shape = new int[,]
    {
        { 0, 0, 1, 0, 0 },
        { 0, 0, 1, 0, 0 },
        { 1, 1, 1, 1, 1 },
        { 0, 1, 1, 1, 0 },
        { 0, 1, 0, 1, 0 },
    };
    
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [0, 5]

        int w = ExponentiationBySquaringIteratively(5, n);
        
        StringBuilder output = new();
        if (n > 0)
        {
            for (int r = 0; r < w; ++r) // max tc = 5 ^ 5 = 3'125
            {
                for (int c = 0; c < w; ++c) // max tc = 3'125
                {
                    output.Append(Evaluate(r, c, n - 1) ? "*" : " ");
                }
                output.AppendLine();
            }
        }
        else
        {
            output.Append("*");
        }
        Console.Write(output);
    }

    private static int ExponentiationBySquaringIteratively(int basis, int exponent)
    {
        int output = 1;
        while (exponent > 0)
        {
            if (exponent % 2 == 1)
            {
                output *= basis;
            }
            basis *= basis;
            exponent >>= 1;
        }
        return output;
    }

    private static bool Evaluate(int r, int c, int n)
    {
        int powN = ExponentiationBySquaringIteratively(5, n);

        int rowSec = r / powN;
        int colSec = c / powN;

        if (_shape[rowSec, colSec] == 0)
            return false;

        if (n > 0)
        {
            int nextR = r - rowSec * powN;
            int nextC = c - colSec * powN;
            return Evaluate(nextR, nextC, n - 1);
        }
        else
        {
            return true;
        }
    }
}