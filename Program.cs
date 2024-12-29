using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int ladderCount = tokens[0];
        int snakeCount = tokens[1];
        int i;

        Dictionary<int, int> ladders = new();
        for (i = 0; i < ladderCount; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            ladders.Add(tokens[0], tokens[1]);
        }

        Dictionary<int, int> snakes = new();
        for (i = 0; i < snakeCount; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            snakes.Add(tokens[0], tokens[1]);
        }

        const int LastCellIndex = 100;
        const int InvalidCount = 0;
        int[] dp = new int[LastCellIndex + 1];
        for (i = 2; i < dp.Length; ++i)
        {
            for (int j = 1; j <= 6; ++j)
            {
                int prevIndex = i - j;
                if (prevIndex < 1)
                    break;

                if (snakes.ContainsKey(prevIndex))
                    continue;

                if (dp[i] != InvalidCount && dp[i] < dp[prevIndex] + 1)
                    continue;

                dp[i] = dp[prevIndex] + 1;
            }

            if (ladders.ContainsKey(i))
            {
                dp[ladders[i]] = dp[i];
            }
            
            if (snakes.ContainsKey(i))
            {
                if (dp[i] < dp[snakes[i]])
                {
                    dp[snakes[i]] = dp[i];
                    i = snakes[i];
                }
            }
        }
        Console.Write(dp[100]);
    }
}