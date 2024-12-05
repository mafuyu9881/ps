internal class Program
{
    private struct AnnualInterestRate
    {
        private int _years;
        public int Years => _years;
        private float _interestRate;
        public float InterestRate => _interestRate;

        public AnnualInterestRate(int years, float interestRate)
        {
            _years = years;
            _interestRate = interestRate;
        }
    }

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int h = tokens[0]; // 10,000 ≤ H ≤ 100,000
        int y = tokens[1]; // 0 ≤ Y ≤ 10

        AnnualInterestRate[] airs = new AnnualInterestRate[]
        {
            new(1, 1.05f),
            new(3, 1.2f),
            new(5, 1.35f),
        };

        int[] dp = new int[y + 1];
        dp[0] = h;
        for (int currIndex = 1; currIndex < dp.Length; ++currIndex)
        {
            for (int j = 0; j < airs.Length; ++j)
            {
                ref var air = ref airs[j];
                int years = air.Years;

                int prevIndex = currIndex - years;
                if (prevIndex < 0)
                    continue;

                dp[currIndex] = Math.Max(dp[currIndex], (int)(dp[prevIndex] * air.InterestRate));
            }
        }
        Console.Write(dp[y]);
    }
}