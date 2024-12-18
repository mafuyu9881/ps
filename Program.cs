internal class Program
{
    private struct Index2D
    {
        private int _row;
        public int Row => _row;
        private int _col;
        public int Col => _col;

        public Index2D(int row, int col)
        {
            _row = row;
            _col = col;
        }
    }

    private static void Main(string[] args)
    {
        int[] integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = integerTokens[0]; // 1 <= n <= 600
        int width = integerTokens[1]; // 1 <= m <= 600

        const char Wall = 'X';
        const char Start = 'I';
        const char Objective = 'P';

        char[] map = new char[height * width];
        int startIndex1D = 0;
        for (int row = 0; row < height; ++row)
        {
            string stringToken = Console.ReadLine()!;
            for (int col = 0; col < width; ++col)
            {
                int index1D = ConvertIndex2DTo1D(width, new(row, col));
                char c = stringToken[col];

                if (c == Start)
                {
                    startIndex1D = index1D;
                }
                
                map[index1D] = c;
            }
        }
        
        bool[] visited = new bool[height * width];
        Queue<int> queue = new();
        visited[startIndex1D] = true;
        queue.Enqueue(startIndex1D);
        int achievedObjectives = 0;
        while (queue.Count > 0)
        {
            int index1D = queue.Dequeue();
            Index2D index2D = ConvertIndex1DTo2D(width, index1D);
            int row = index2D.Row;
            int col = index2D.Col;

            Index2D[] adjIndices2D = new Index2D[]
            {
                new (row - 1, col),
                new (row + 1, col),
                new (row, col - 1),
                new (row, col + 1),
            };
            for (int i = 0; i < adjIndices2D.Length; ++i)
            {
                Index2D adjIndex2D = adjIndices2D[i];

                int adjRow = adjIndex2D.Row;
                if (adjRow < 0 || adjRow > height - 1)
                    continue;

                int adjCol = adjIndex2D.Col;
                if (adjCol < 0 || adjCol > width - 1)
                    continue;

                int adjIndex1D = ConvertIndex2DTo1D(width, adjIndex2D);
                if (visited[adjIndex1D])
                    continue;

                char adjC = map[adjIndex1D];
                if (adjC == Objective)
                {
                    ++achievedObjectives;
                }

                if (adjC != Wall)
                {
                    queue.Enqueue(adjIndex1D);
                }

                visited[adjIndex1D] = true;
            }
        }
        Console.Write((achievedObjectives > 0) ? achievedObjectives : "TT");
    }

    private static int ConvertIndex2DTo1D(int width, Index2D index2D)
    {
        return index2D.Row * width + index2D.Col;
    }

    private static Index2D ConvertIndex1DTo2D(int width, int index1D)
    {
        return new(index1D / width, index1D % width);
    }
}