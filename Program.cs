internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 100'000]

        // length = [2, 100'000]
        // element = [-1'000'000'000, 1'000'000'000]
        int[] sols = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(sols);
        
        (int sol1, int sol2) answerPair = (1000000000, 1000000000);
        {
            int i = 0;
            int j = sols.Length - 1;

            while (i < j)
            {
                int sol1 = sols[i];
                int sol2 = sols[j];
                int mixed = sol1 + sol2;

                if (Math.Abs(mixed) < Math.Abs(answerPair.sol1 + answerPair.sol2))
                {
                    answerPair = (sol1, sol2);
                }

                if (mixed < 0)
                {
                    ++i;
                }
                else if (mixed > 0)
                {
                    --j;
                }
                else
                {
                    answerPair = (sol1, sol2);
                    break;
                }
            }
        }
        Console.Write($"{answerPair.sol1} {answerPair.sol2}");
    }
}