using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();
        output.AppendLine("(3 ^ 1) ^ (5)");
        output.AppendLine("= (3 ^ 1) ^ (4 + 1)");
        output.AppendLine("= (3 ^ 1) ^ (4) * (3 ^ 1)");
        output.AppendLine("= (3 ^ 1) ^ (4 / 2 * 2) * (3 ^ 1)");
        output.AppendLine("= (3 ^ 2) ^ (2) * (3 ^ 1)");
        output.AppendLine("= (3 ^ 2) ^ (2 / 2 * 2) * (3 ^ 1)");
        output.AppendLine("= (3 ^ 4) ^ (1) * (3 ^ 1)");
        output.AppendLine("= (3 ^ 4) ^ (0 + 1) * (3 ^ 1)");
        output.AppendLine("= (3 ^ 4) ^ (0) * (3 ^ 4) * (3 ^ 1)");
        output.AppendLine("= (3 ^ 4) * (3 ^ 1)");
        output.Replace("0", "000");
        output.Replace("1", "001");
        output.Replace("2", "010");
        output.Replace("3", "011");
        output.Replace("4", "100");
        output.Replace("5", "101");
        Console.Write(output);
    }
    
    private static int ExponentiationBySquaringRecursively(int basis, int exponent)
    {
        if (exponent < 1)
            return 1;

        int sqrtBasis = ExponentiationBySquaringRecursively(basis, exponent / 2);

        if ((exponent & 1) == 1)
        {
            return sqrtBasis * sqrtBasis * basis;
        }
        else
        {
            return sqrtBasis * sqrtBasis;
        }
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