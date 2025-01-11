using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100`000`000]
        int k = tokens[1]; // [1, 1`000`000`000]

        int nDigitCount = (int)Math.Log10(n) + 1; // [1, 9]
        int kNumberDigitCount = 1; // digit count of the number which includes kth digit [1, 9]

        int arrLength = nDigitCount + 1;
        // start number among the same digit numbers
        int[] starts = new int[arrLength];
        // counts of the same digit numbers
        long[] counts = new long[arrLength];
        long[] accCounts = new long[arrLength]; // max sc = 8B * (9 + 1) = 80B
        for (int i = 1; i < arrLength; ++i) // max tc = 10
        {
            starts[i] = ExponentiationBySquaringIteratively(10, i - 1);
            counts[i] = i * 9 * starts[i];
            accCounts[i] = accCounts[i - 1] + counts[i];

            if (k > accCounts[i])
            {
                ++kNumberDigitCount;
            }
        }

        long clampedK = k - accCounts[kNumberDigitCount - 1]; // [1, ?)
        long placedNumberCount = (clampedK - 1) / kNumberDigitCount;
        long kNumber = starts[kNumberDigitCount] + placedNumberCount;
        Console.Write($"{kNumber}"[(int)((clampedK - 1) % kNumberDigitCount)]);
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