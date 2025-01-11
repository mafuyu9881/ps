internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100`000`000]
        int k = tokens[1]; // [1, 1`000`000`000]

        int[] arr = new int[]; // max sc = 9 + 1 = 10
        for (int i = 1; i < arr.Length; ++i) // max tc = 10
        {
            arr[i] = arr[i - 1] + i * 9 * ExponentiationBySquaringIteratively(10, (i - 1));
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