internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0]; // [2, 1'000]
        int width = tokens[1]; // [2, 1'000]

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int departureRow = tokens[0] - 1; // [1, 1'000]
        int departureCol = tokens[1] - 1; // [1, 1'000]
        int departureIndex = departureRow * width + departureCol;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int arrivalRow = tokens[0] - 1; // [1, 1'000]
        int arrivalCol = tokens[1] - 1; // [1, 1'000]
        int arrivalIndex = arrivalRow * width + arrivalCol;

        const int Wall = 1;

        int[] map = new int[height * width];
        for (int row = 0; row < height; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col)
            {
                map[row * width + col] = tokens[col];
            }
        }

        const int InvalidDistance = -1;
        const int InitialWands = 1;
        int[][] d = new int[map.Length][];
        for (int i = 0; i < d.Length; ++i)
        {
            d[i] = new int[InitialWands + 1];
            for (int j = 0; j < d[i].Length; ++j)
            {
                d[i][j] = InvalidDistance;
            }
        }

        const int Offsets = 4;
        int[] rowOffsets = new int[Offsets] { -1, 1, 0, 0 };
        int[] colOffsets = new int[Offsets] { 0, 0, -1, 1 };

        Queue<(int index, int remainWands)> frontier = new();

        d[departureIndex][InitialWands] = 0;
        frontier.Enqueue((departureIndex, InitialWands));
        while (frontier.Count > 0)
        {
            var elem = frontier.Dequeue();
            int index = elem.index;
            int row = index / width;
            int col = index % width;
            int remainWands = elem.remainWands;

            for (int i = 0; i < Offsets; ++i)
            {
                int adjRow = row + rowOffsets[i];
                if (adjRow < 0 || adjRow > height - 1)
                    continue;

                int adjCol = col + colOffsets[i];
                if (adjCol < 0 || adjCol > width - 1)
                    continue;

                int adjIndex = adjRow * width + adjCol;
                int adjRemainWands = remainWands;
                if (map[adjIndex] == Wall)
                    --adjRemainWands;

                if (adjRemainWands < 0)
                    continue;

                int oldDistance = d[adjIndex][adjRemainWands];
                int newDistance = d[index][remainWands] + 1;
                if (oldDistance != InvalidDistance && oldDistance < newDistance)
                    continue;

                d[adjIndex][adjRemainWands] = newDistance;
                frontier.Enqueue((adjIndex, adjRemainWands));
            }
        }

        int minDistance = InvalidDistance;
        for (int i = 0; i < d[arrivalIndex].Length; ++i)
        {
            int distance = d[arrivalIndex][i];
            if (distance == InvalidDistance)
                continue;

            if (minDistance != InvalidDistance &&
                minDistance <= distance)
                continue;

            minDistance = distance;
        }
        Console.Write(minDistance);
    }
}