internal class Program
{
    private static void Main(string[] args)
    {
        const int Village = 1;
        const int InvalidCost = -1;
        const int Offsets = 4;
        int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0 };
        int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1 };

        // length = 2
        // element = [2, 20]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];
        
        Func<int, int, int> ConvertIndex2DTo1D = (row, col) =>
        {
            return row * width + col;
        };

        int[] map = new int[height * width];
        for (int row = 0; row < height; ++row) // max tc = 20
        {
            string line = Console.ReadLine()!;
            for (int col = 0; col < width; ++col) // max tc = 20
            {
                map[ConvertIndex2DTo1D(row, col)] = line[col] - '0';
            }
        }

        Action<int[], int> BFS = (minCost, s) =>
        {
            Queue<int> frontier = new();

            minCost[s] = 0;
            frontier.Enqueue(s);
            while (frontier.Count > 0)
            {
                int index = frontier.Dequeue();
                int row = index / width;
                int col = index % width;

                int adjNewMinCost = minCost[index] + 1;

                for (int i = 0; i < Offsets; ++i)
                {
                    int adjRow = row + RowOffsets[i];
                    if (adjRow < 0 || adjRow > height - 1)
                        continue;

                    int adjCol = col + ColOffsets[i];
                    if (adjCol < 0 || adjCol > width - 1)
                        continue;

                    int adjIndex = ConvertIndex2DTo1D(adjRow, adjCol);
                    int adjOldMinCost = minCost[adjIndex];
                    if (adjOldMinCost != InvalidCost && adjOldMinCost <= adjNewMinCost)
                        continue;

                    minCost[adjIndex] = adjNewMinCost;
                    frontier.Enqueue(adjIndex);
                }
            }
        };

        int minPoisoningCost = InvalidCost;
        for (int i0 = 0; i0 < map.Length; ++i0) // max tc = 400
        {
            if (map[i0] == Village)
                continue;

            for (int i1 = i0 + 1; i1 < map.Length; ++i1) // max tc = 400
            {
                if (map[i1] == Village)
                    continue;

                int[] minCost = new int[map.Length];
                for (int i = 0; i < minCost.Length; ++i) // max tc = 400
                {
                    minCost[i] = InvalidCost;
                }

                BFS(minCost, i0);
                BFS(minCost, i1);

                int poisoningCost = InvalidCost;
                for (int i = 0; i < minCost.Length; ++i) // max tc = 400
                {
                    if (map[i] != Village)
                        continue;

                    if (poisoningCost != InvalidCost && poisoningCost >= minCost[i])
                        continue;

                    poisoningCost = minCost[i];
                }

                if (minPoisoningCost == InvalidCost || poisoningCost < minPoisoningCost)
                {
                    minPoisoningCost = poisoningCost;
                }
            }
        }
        Console.Write(minPoisoningCost);
    }
}