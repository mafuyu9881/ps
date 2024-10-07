internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(ExponentiationBySquaringRecursively(3, 3));
        Console.WriteLine(ExponentiationBySquaringIteratively(4, 1));
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