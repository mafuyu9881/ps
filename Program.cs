internal class Program
{
    private static void Main(string[] args)
    {
        const int AdjOffsets = 4;
        int[] adjRowOffsets = new int[AdjOffsets] { -1, 1, 0, 0 };
        int[] adjColOffsets = new int[AdjOffsets] { 0, 0, -1, 1 };
        const int HorseOffsets = 8;
        int[] horseRowOffsets = new int[HorseOffsets] { -1, -2, -2, -1, 1, 2, 2, 1 };
        int[] horseColOffsets = new int[HorseOffsets] { -2, -1, 1, 2, -2, -1, 1, 2 };

        int k = int.Parse(Console.ReadLine()!); // [0, 30]

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int width = tokens[0]; // [1, 200]
        int height = tokens[1]; // [1, 200]

        int[] map = new int[width * height];
        for (int row = 0; row < height; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col)
            {
                map[row * width + col] = tokens[col];
            }
        }

        const int InvalidMoves = -1;
        
        Queue<(int index, int usedK)> waitings = new();
        int[][] dp = new int[width * height][]; // the second dimension represents the count of horse-like moves
        for (int i = 0; i < dp.Length; ++i) // max tc = 40'000
        {
            dp[i] = new int[k + 1];
            for (int j = 0; j < dp[i].Length; ++j) // max tc = 31
            {
                dp[i][j] = InvalidMoves;
            }
        }

        int srcIndex = 0;
        waitings.Enqueue((srcIndex, 0));
        for (int i = 0; i < dp[srcIndex].Length; ++i)
        {
            dp[srcIndex][i] = 0;
        }

        // it's is better to get more k count when both have same distance
        while (waitings.Count > 0)
        {
            var element = waitings.Dequeue();
            int index = element.index;
            int row = index / width;
            int col = index % width;
            int usedK = element.usedK;
            int newMoves = dp[index][usedK] + 1;

            for (int i = 0; i < AdjOffsets; ++i)
            {
                int adjRow = row + adjRowOffsets[i];
                if (adjRow < 0 || adjRow > height - 1)
                    continue;

                int adjCol = col + adjColOffsets[i];
                if (adjCol < 0 || adjCol > width - 1)
                    continue;

                int adjIndex = adjRow * width + adjCol;
                if (map[adjIndex] == 1)
                    continue;

                int oldMoves = dp[adjIndex][usedK];
                if (oldMoves != InvalidMoves && oldMoves <= newMoves)
                    continue;

                dp[adjIndex][usedK] = newMoves;
                waitings.Enqueue((adjIndex, usedK));
            }

            if (usedK < k)
            {
                ++usedK;

                for (int i = 0; i < HorseOffsets; ++i)
                {
                    int horseRow = row + horseRowOffsets[i];
                    if (horseRow < 0 || horseRow > height - 1)
                        continue;

                    int horseCol = col + horseColOffsets[i];
                    if (horseCol < 0 || horseCol > width - 1)
                        continue;

                    int horseIndex = horseRow * width + horseCol;
                    if (map[horseIndex] == 1)
                        continue;

                    int oldMoves = dp[horseIndex][usedK];
                    if (oldMoves != InvalidMoves && oldMoves <= newMoves)
                        continue;

                    dp[horseIndex][usedK] = newMoves;
                    waitings.Enqueue((horseIndex, usedK));
                }
            }
        }

        int minMoves = InvalidMoves;
        int[] dstDP = dp[dp.Length - 1];
        for (int i = 0; i < dstDP.Length; ++i)
        {
            int moves = dstDP[i];
            if (moves == InvalidMoves)
                continue;

            if (minMoves != InvalidMoves && minMoves <= moves)
                continue;

            minMoves = moves;
        }
        Console.Write(minMoves);
    }
}