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
        
        Queue<int> waitings = new();
        (int moves, int usedK)[] cost = new (int, int)[width * height];
        for (int i = 0; i < cost.Length; ++i) // max tc = 40'000
        {
            cost[i] = (InvalidMoves, 0);
        }

        int srcIndex = 0;
        waitings.Enqueue(srcIndex);
        cost[srcIndex] = (0, 0);

        // it's is better to get more k count when both have same distance
        while (waitings.Count > 0)
        {
            int index = waitings.Dequeue();
            int row = index / width;
            int col = index % width;

            int newMoves = cost[index].moves + 1;
            int newUsedK = cost[index].usedK;

            for (int i = 0; i < AdjOffsets; ++i)
            {
                int adjRow = row + adjRowOffsets[i];
                if (adjRow < 0 || adjRow > height - 1)
                    continue;

                int adjCol = col + adjColOffsets[i];
                if (adjCol < 0 || adjCol > width - 1)
                    continue;

                int adjIndex = adjRow * width + adjCol;
                if (adjIndex == srcIndex)
                    continue;

                if (map[adjIndex] == 1)
                    continue;

                int oldMoves = cost[adjIndex].moves;
                int oldUsedK = cost[adjIndex].usedK;
                if ((oldMoves != InvalidMoves) &&
                    ((oldMoves < newMoves) || 
                     (oldMoves == newMoves && oldUsedK <= newUsedK)))
                    continue;

                cost[adjIndex] = (newMoves, newUsedK);
                waitings.Enqueue(adjIndex);
            }

            if (newUsedK < k)
            {
                ++newUsedK;

                for (int i = 0; i < HorseOffsets; ++i)
                {
                    int horseRow = row + horseRowOffsets[i];
                    if (horseRow < 0 || horseRow > height - 1)
                        continue;

                    int horseCol = col + horseColOffsets[i];
                    if (horseCol < 0 || horseCol > width - 1)
                        continue;

                    int horseIndex = horseRow * width + horseCol;
                    if (horseIndex == 0)
                        continue;

                    if (map[horseIndex] == 1)
                        continue;

                    int oldMoves = cost[horseIndex].moves;
                    int oldUsedK = cost[horseIndex].usedK;
                    if ((oldMoves != InvalidMoves) &&
                        ((oldMoves < newMoves) ||
                         (oldMoves == newMoves && oldUsedK <= newUsedK)))
                        continue;

                    cost[horseIndex] = (newMoves, newUsedK);
                    waitings.Enqueue(horseIndex);
                }
            }
        }

        Console.Write(cost[cost.Length - 1].moves);
    }
}