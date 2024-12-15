internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int containerLength = Math.Max(3, n);

        // 1 2 3 4 1 2 3 4로 진행해야하나?
        int[] prefixSums = new int[containerLength];
        prefixSums[0] = 1;
        prefixSums[1] = 4;
        prefixSums[2] = 9;
        for (int i = 3; i < prefixSums.Length; ++i)
        {
            int prevPrefixSum = prefixSums[i - 1];
            prefixSums[i] = prevPrefixSum + (prevPrefixSum + ComputeCyclicNumber(i - 2, 3));
        }

        int[] dp = new int[containerLength];
        dp[0] = 1;
        dp[1] = 3;
        dp[2] = 5;
        for (int i = 3; i < dp.Length; ++i)
        {
            //dp[i] = prefixSums[i - 1] + ComputeCyclicNumber(i - 2, 3);
            for (int j = 0; j < i; ++j)
            {
                dp[i] += dp[j];
            }
            dp[i] += ComputeCyclicNumber(i - 2, 4);
        }
        Console.Write(dp[n - 1]);
    }
    
    private static int ComputeCyclicNumber(int input, int period)
    {
        int output = input % period;

        if (output == 0)
        {
            output = period;
        }

        return output;
    }
}