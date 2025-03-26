internal class Program
{
    private static void Main(string[] args)
    {
        const int Wall = 1;

        const int InvalidDistance = -1;

        const int Offsets = 4;
        int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0 };
        int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1 };

        // length = 2
        // element = [1, 1'000]
        int[] integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = integerTokens[0];
        int width = integerTokens[1];

        int[] map = new int[height * width];
        for (int row = 0; row < height; ++row)
        {
            string stringToken = Console.ReadLine()!;
            for (int col = 0; col < width; ++col)
            {
                map[row * width + col] = stringToken[col] - '0';
            }
        }

        int historyHeight = height * width;
        int historyWidth = 2;

        int[,] history = new int[historyHeight, historyWidth];
        for (int i = 0; i < historyHeight; ++i)
        {
            for (int j = 0; j < historyWidth; ++j)
            {
                history[i, j] = InvalidDistance;
            }
        }

        Queue<(int index, int smashes, int distance)> frontier = new();

        int s = 0;
        history[s, 0] = 1;
        frontier.Enqueue((s, 0, history[s, 0]));

        while (frontier.Count > 0)
        {
            var element = frontier.Dequeue();

            int index = element.index;
            int row = index / width;
            int col = index % width;
            int smashes = element.smashes;
            int newSmashes = smashes + 1;
            int newDistance = element.distance + 1;

            for (int i = 0; i < Offsets; ++i)
            {
                int adjRow = row + RowOffsets[i];
                if (adjRow < 0 || adjRow > height - 1)
                    continue;

                int adjCol = col + ColOffsets[i];
                if (adjCol < 0 || adjCol > width - 1)
                    continue;

                int adjIndex = adjRow * width + adjCol;
                if (map[adjIndex] == Wall)
                {
                    if (smashes < 1)
                    {
                        int oldDistance = history[adjIndex, newSmashes];
                        if (oldDistance == InvalidDistance || newDistance < oldDistance)
                        {
                            history[adjIndex, newSmashes] = newDistance;
                            frontier.Enqueue((adjIndex, newSmashes, newDistance));
                        }
                    }
                }
                else
                {
                    int oldDistance = history[adjIndex, smashes];
                    if (oldDistance == InvalidDistance || newDistance < oldDistance)
                    {
                        history[adjIndex, smashes] = newDistance;
                        frontier.Enqueue((adjIndex, smashes, newDistance));
                    }
                }
            }
        }

        int minDistance = InvalidDistance;
        for (int i = 0; i < historyWidth; ++i)
        {
            int distance = history[historyHeight - 1, i];

            if (distance == InvalidDistance)
                continue;

            if (minDistance != InvalidDistance && minDistance <= distance)
                continue;
                
            minDistance = distance;
        }
        Console.Write($"{minDistance}");
    }
}