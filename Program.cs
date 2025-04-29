internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 100'000]

        // length = [2, 100'000]
        // element = [-1'000'000'000, 1'000'000'000] (element != 0)
        int[] solutions = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        List<int> acidicSolutions = new(n);
        List<int> alkalineSolutions = new(n);
        for (int i = 0; i < n; ++i) // max tc = 100'000
        {
            int solution = solutions[i];
            if (solution < 0)
            {
                alkalineSolutions.Add(solution);
            }
            else
            {
                acidicSolutions.Add(solution);
            }
        }
        alkalineSolutions.Sort((x, y) => y.CompareTo(x));

        (int solution1, int solution2) answerPair = (1000000001, 1000000001);

        if (acidicSolutions.Count > 0)
        {
            for (int i = 0; i < alkalineSolutions.Count; ++i)
            {
                int alkalineSolution = alkalineSolutions[i];

                int lo = 0 - 1;
                int hi = (acidicSolutions.Count - 1) + 1;
                while (lo < hi - 1)
                {
                    int mid = (lo + hi) / 2;

                    int mixed = alkalineSolution + acidicSolutions[mid];

                    if (mixed > 0) // |acidicSolution| > |alkalineSolution|
                    {
                        hi = mid;
                    }
                    else if (mixed < 0)
                    {
                        lo = mid;
                    }
                    else
                    {
                        lo = mid;
                        hi = mid;
                        break;
                    }
                }

                if (lo > -1 && Math.Abs(alkalineSolution + acidicSolutions[lo]) < Math.Abs(answerPair.solution1 + answerPair.solution2))
                {
                    answerPair = new(alkalineSolution, acidicSolutions[lo]);
                }

                if (hi < acidicSolutions.Count && Math.Abs(alkalineSolution + acidicSolutions[hi]) < Math.Abs(answerPair.solution1 + answerPair.solution2))
                {
                    answerPair = new(alkalineSolution, acidicSolutions[hi]);
                }
            }
        }

        if (alkalineSolutions.Count >= 2)
        {
            if (Math.Abs(alkalineSolutions[0] + alkalineSolutions[1]) < Math.Abs(answerPair.solution1 + answerPair.solution2))
            {
                answerPair = new(alkalineSolutions[0], alkalineSolutions[1]);
            }
        }

        if (acidicSolutions.Count >= 2)
        {
            if (Math.Abs(acidicSolutions[0] + acidicSolutions[1]) < Math.Abs(answerPair.solution1 + answerPair.solution2))
            {
                answerPair = new(acidicSolutions[0], acidicSolutions[1]);
            }
        }

        Console.Write($"{Math.Min(answerPair.solution1, answerPair.solution2)} {Math.Max(answerPair.solution1, answerPair.solution2)}");
    }
}