using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 1'000]

        StringBuilder output = new();
        for (int i = 0; i < n; ++i) // max tc = 1'000
        {
            string s = Console.ReadLine()!;

            int deepestDepth = 0;
            int depth = 0; // the depth is start from zero
            for (int j = 0; j < s.Length; ++j) // max tc = 150
            {
                char c = s[j];
                if (c == '[') 
                {
                    ++depth;
                }
                else
                {
                    --depth;
                }
                deepestDepth = Math.Max(deepestDepth, depth);
            }
            output.AppendLine($"{ExponentiationBySquaringIteratively(2, deepestDepth)}");
        }
        Console.Write(output);
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