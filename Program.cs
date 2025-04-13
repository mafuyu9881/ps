internal class Program
{
    private static void Main(string[] args)
    {
        const int InvalidCost = -1;

        int n = int.Parse(Console.ReadLine()!); // [1, 3]

        // length = [1, 3]
        // element = [1, 60]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[] hp = new int[3];
        for (int i = 0; i < tokens.Length; ++i) // max tc = 3
        {
            hp[i] = tokens[i];
        }

        int initialHP0 = hp[0];
        int initialHP1 = hp[1];
        int initialHP2 = hp[2];

        int[,,] dp = new int[initialHP0 + 1, initialHP1 + 1, initialHP2 + 1];
        for (int i = initialHP0; i >= 0; --i) // max tc = 61
        {
            for (int j = initialHP1; j >= 0; --j) // max tc = 61
            {
                for (int k = initialHP2; k >= 0; --k) // max tc = 61
                {
                    dp[i, j, k] = InvalidCost;
                }
            }
        }

        Action<int, int, int, int, int, int> Transition = (i, j, k, damageI, damageJ, damageK) =>
        {
            if (dp[i, j, k] == InvalidCost)
                return;

            int nextI = Math.Max(0, i - damageI);
            int nextJ = Math.Max(0, j - damageJ);
            int nextK = Math.Max(0, k - damageK);

            int oldCost = dp[nextI, nextJ, nextK];
            int newCost = dp[i, j, k] + 1;
            if (oldCost != InvalidCost && oldCost <= newCost)
                return;

            dp[nextI, nextJ, nextK] = newCost;
        };

        dp[initialHP0, initialHP1, initialHP2] = 0;
        for (int i = initialHP0; i >= 0; --i) // max tc = 61
        {
            for (int j = initialHP1; j >= 0; --j) // max tc = 61
            {
                for (int k = initialHP2; k >= 0; --k) // max tc = 61
                {
                    Transition(i, j, k, 9, 3, 1);
                    Transition(i, j, k, 9, 1, 3);
                    Transition(i, j, k, 3, 9, 1);
                    Transition(i, j, k, 3, 1, 9);
                    Transition(i, j, k, 1, 3, 9);
                    Transition(i, j, k, 1, 9, 3);
                }
            }
        }
        Console.Write(dp[0, 0, 0]);
    }
}