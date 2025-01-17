internal class Program
{
    private static void Main(string[] args)
    {
        const char GeunNumber = '2';

        int n = int.Parse(Console.ReadLine()!);
        
        string s = Console.ReadLine()!;

        long[] wholeNumberPrefixSum = new long[1000001]; // max sc = 4B * 1'000'001 = about 4MB
        for (int i = 1; i < wholeNumberPrefixSum.Length; ++i) // tc = 1'000'000
        {
            wholeNumberPrefixSum[i] = wholeNumberPrefixSum[i - 1] + i;
        }

        long[] geunNumberScores = new long[1000001];
        for (int i = 1; i < geunNumberScores.Length; ++i) // tc = 1'000'000
        {
            geunNumberScores[i] = geunNumberScores[i - 1] + wholeNumberPrefixSum[i];
        }

        long output = 0;
        int geunNumberCombo = 0;
        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == GeunNumber)
            {
                ++geunNumberCombo;
            }

            if (i >= s.Length - 1 || s[i + 1] != GeunNumber)
            {
                output += geunNumberScores[geunNumberCombo];
                geunNumberCombo = 0;
            }
        }
        Console.Write(output);
    }
}