internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100'000]
        int k = tokens[1]; // [1, 100'000]

        // length = [1, 100'000]
        // [0, 20]
        int[] scores = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        Func<int, bool> Condition = (objectiveScoreSum) =>
        {
            int groups = 0;
            int scoreSum = 0;

            for (int i = 0; i < n; ++i)
            {
                int score = scores[i];
                if (scoreSum >= objectiveScoreSum)
                {
                    ++groups;
                    scoreSum = score;
                }
                else
                {
                    scoreSum += score;
                }
            }

            if (scoreSum >= objectiveScoreSum)
            {
                ++groups;
                scoreSum = 0;
            }
            
            return groups >= k;
        };

        int lo = 0 - 1;
        int hi = 20 * 100000 + 1;
        while (lo < hi - 1)
        {
            int mid = (lo + hi) / 2;
            
            if (Condition(mid))
            {
                lo = mid;
            }
            else
            {
                hi = mid;
            }
        }
        Console.Write(lo);
    }
}