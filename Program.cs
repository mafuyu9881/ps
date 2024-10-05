// 시간 제한: 1초
// 메모리 제한: 128MB
// 1 <= (계단 수) <= 300

internal class Program
{
    private static void Main(string[] args)
    {
        const int MaxTNOStairs = 301;

        int n = int.Parse(Console.ReadLine()!);
        int[] scores = new int[MaxTNOStairs];
        for (int i = 1; i <= n; ++i)
        {
            scores[i] = int.Parse(Console.ReadLine()!);
        }

        int[] accumulatedScores = new int[MaxTNOStairs];
        accumulatedScores[0] = 0;
        accumulatedScores[1] = scores[1];
        accumulatedScores[2] = scores[1] + scores[2];
        for (int i = 3; i <= n; ++i)
        {
            accumulatedScores[i] = Math.Max(accumulatedScores[i - 2] + scores[i],
                                            accumulatedScores[i - 3] + scores[i - 1] + scores[i]);
        }
        Console.Write(accumulatedScores[n]);
    }
}