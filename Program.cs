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
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];

        const int TastyElevation = 0;

        bool[] map = new bool[height * width];
        LinkedList<int> badList = new();
        for (int row = 0; row < height; ++row)
        {
            int[] line = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col)
            {
                int index1D = ConvertIndex2DTo1D(width, new(row, col));

                bool bad = line[col] > TastyElevation;

                map[index1D] = bad;
                if (bad) badList.AddLast(index1D);
            }
        }

        int badIslandCount = 0;
        Dictionary<int, HashSet<int>> badIslands = new();
        Queue<int> visitingQueue = new();

        while (true)
        {
            while (visitingQueue.Count < 1 && badList.Count > 0)
            {
                var node = badList.First!;

                int firstSrcIndex1D = node.Value;
                if (badIslands.ContainsKey(firstSrcIndex1D) == false)
                {
                    badIslands.Add(firstSrcIndex1D, new() { firstSrcIndex1D });
                    visitingQueue.Enqueue(firstSrcIndex1D);
                    ++badIslandCount;
                }

                badList.Remove(node);
            }

            if (visitingQueue.Count < 1)
                break;

            int srcIndex1D = visitingQueue.Dequeue();
            HashSet<int> srcBadIsland = badIslands[srcIndex1D];
            Index2D srcIndex2D = ConvertIndex1DTo2D(width, srcIndex1D);
            int srcRow = srcIndex2D.Row;
            int srcCol = srcIndex2D.Col;
            Index2D[] adjIndices2D = new Index2D[]
            {
                new(srcRow - 1, srcCol),
                new(srcRow + 1, srcCol),
                new(srcRow, srcCol - 1),
                new(srcRow, srcCol + 1),
                new(srcRow - 1, srcCol - 1),
                new(srcRow + 1, srcCol + 1),
                new(srcRow - 1, srcCol + 1),
                new(srcRow + 1, srcCol - 1),
            };
            for (int i = 0; i < adjIndices2D.Length; ++i)
            {
                Index2D adjIndex2D = adjIndices2D[i];

                int adjRow = adjIndex2D.Row;
                if (adjRow < 0 || adjRow > (height - 1))
                    continue;

                int adjCol = adjIndex2D.Col;
                if (adjCol < 0 || adjCol > (width - 1))
                    continue;

                int adjIndex1D = ConvertIndex2DTo1D(width, adjIndex2D);
                if (map[adjIndex1D] == false)
                    continue;

                if (badIslands.ContainsKey(adjIndex1D))
                    continue;
                
                srcBadIsland.Add(adjIndex1D);
                badIslands.Add(adjIndex1D, srcBadIsland);
                visitingQueue.Enqueue(adjIndex1D);
            }
        }
        Console.Write(badIslandCount);
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