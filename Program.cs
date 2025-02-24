internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 1'000]

        // length = [1, 1'000]
        // element = [1, 1'000]
        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        // monotonically increasing
        int[] dp0 = new int[sequence.Length];
        for (int i = 0; i < dp0.Length; ++i) // max tc = 1'000
        {
            dp0[i] = 1;
        }
        for (int i = 1; i < sequence.Length; ++i) // max tc = 1'000
        {
            for (int j = 0; j < i; ++j) // max tc = 1'000
            {
                if (sequence[i] > sequence[j])
                {
                    dp0[i] = Math.Max(dp0[i], dp0[j] + 1);
                }
            }
        }

        // monotonically increasing (reversed)
        int[] dp1 = new int[sequence.Length];
        for (int i = 0; i < dp1.Length; ++i) // max tc = 1'000
        {
            dp1[i] = 1;
        }
        for (int i = sequence.Length - 2; i >= 0; --i) // max tc = 1'000
        {
            for (int j = sequence.Length - 1; j > i; --j) // max tc = 1'000
            {
                if (sequence[i] > sequence[j])
                {
                    dp1[i] = Math.Max(dp1[i], dp1[j] + 1);
                }
            }
        }

        int output = 1;
        for (int i = 0; i < sequence.Length; ++i) // max tc = 1'000
        {
            output = Math.Max(output, dp0[i] + dp1[i] - 1);
        }
        Console.Write(output);
    }
}