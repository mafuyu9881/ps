internal class Program
{
    private static void Main(string[] args)
    {
        int temp = ExponentationBySquareIteratively(3, 4);
    }
    
    private static int ExponentationBySquareIteratively(int basis, int exponent)
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
    
    private static int ExponentationBySquareRecursively(int basis, int exponent)
    {
        if (exponent < 1)
            return 1;

        int halfBasis = ExponentationBySquareRecursively(basis, exponent / 2);

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