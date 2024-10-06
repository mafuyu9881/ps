internal class Program
{
    private static void Main(string[] args)
    {
        int temp = ExponentiationBySquareIteratively(3, 4);
    }
    
    private static int ExponentiationBySquareIteratively(int basis, int exponent)
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
    
    private static int ExponentiationBySquareRecursively(int basis, int exponent)
    {
        if (exponent < 1)
            return 1;

        int halfBasis = ExponentiationBySquareRecursively(basis, exponent / 2);

        if ((exponent & 1) == 1)
        {
            return basis * halfBasis * halfBasis;
        }
        else
        {
            return halfBasis * halfBasis;
        }
    }
}