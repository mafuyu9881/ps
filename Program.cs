using System.Numerics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // 0 ≤ k ≤ 10
        // 3 * 2^0 ≤ n ≤ 3 * 2^10 (n = 3 * 2^k)
        int n = int.Parse(Console.ReadLine()!);

        int duplicatingCount = BitOperations.Log2((uint)(n / 3));

        string[] cachedShape = new string[n];
        cachedShape[0] = "*";
        cachedShape[1] = "* *";
        cachedShape[2] = "*****";

        StringBuilder output = new();
        int writingIndex = 0;
        while (writingIndex < 3)
        {
            int borderBlankCount = n - 1 - writingIndex;

            StringBuilder line = new();
            line.Append(' ', borderBlankCount);
            line.Append(cachedShape[writingIndex]);
            line.Append(' ', borderBlankCount);
            output.AppendLine(line.ToString());

            ++writingIndex;
        }
        int initialIntervalBlankCount = 5;
        for (int i = 0; i < duplicatingCount; ++i)
        {
            int duplicatingShapeHeight = 3 * ExponentiationBySquaringInteratively(2, i);
            for (int j = 0; j < duplicatingShapeHeight; ++j)
            {
                StringBuilder shape = new();
                shape.Append(cachedShape[j]);
                shape.Append(' ', initialIntervalBlankCount - (2 * j));
                shape.Append(cachedShape[j]);
                cachedShape[writingIndex] = shape.ToString();

                int borderBlankCount = n - 1 - writingIndex;

                StringBuilder line = new();
                line.Append(' ', borderBlankCount);
                line.Append(cachedShape[writingIndex]);
                line.Append(' ', borderBlankCount);
                output.AppendLine(line.ToString());

                ++writingIndex;
            }
            initialIntervalBlankCount += 3 * ExponentiationBySquaringInteratively(2, i + 1); // 5 + sum of sequence { 0, 6, 12, 24, 48, ... }
        }
        Console.Write(output);
    }

    private static int ExponentiationBySquaringInteratively(int basis, int exponent)
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