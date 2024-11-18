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
        // 1 ≤ n, m ≤ 300
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int m = tokens[1];

        bool[,] map = new bool[m, n];
        for (int row = 0; row < m; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < n; ++col)
            {
                map[row, col] = tokens[col] == 1;
            }
        }

        bool[,] visitedTable = new bool[m, n];
        Queue<Index2D> visitingIndices = new();
        Index2D ltIndex2D = new(0, 0);
        visitingIndices.Enqueue(ltIndex2D);
        visitedTable[ltIndex2D.Row, ltIndex2D.Col] = true;
        while (visitingIndices.Count > 0)
        {
            Index2D index2D = visitingIndices.Dequeue();
            int row = index2D.Row;
            int col = index2D.Col;
            
            Index2D[] adjacentIndices2D = new Index2D[]
            {
                new(row - 1, col),
                new(row + 1, col),
                new(row, col - 1),
                new(row, col + 1),
            };

            for (int i = 0; i < adjacentIndices2D.Length; ++i)
            {
                Index2D adjacentIndex2D = adjacentIndices2D[i];
                int adjacentRow = adjacentIndex2D.Row;
                int adjacentCol = adjacentIndex2D.Col;

                if (adjacentRow < 0 || adjacentRow > (m - 1))
                    continue;

                if (adjacentCol < 0 || adjacentCol > (n - 1))
                    continue;

                if (visitedTable[adjacentRow, adjacentCol])
                    continue;

                if (map[adjacentRow, adjacentCol] == false)
                    continue;

                visitingIndices.Enqueue(adjacentIndex2D);
                visitedTable[adjacentRow, adjacentCol] = true;
            }
        }
        Index2D rbIndex2D = new(m - 1, n - 1);
        Console.Write(visitedTable[rbIndex2D.Row, rbIndex2D.Col] ? "Yes" : "No");
    }
}