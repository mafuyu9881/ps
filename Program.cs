internal class Program
{
    struct Index2D
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
        int n = int.Parse(Console.ReadLine()!); // 1 <= n <= 1,000

        const char asteroidCharacter = '*';

        char[] map = new char[n * n];
        // Hoped to use HashSet<int> in here but,
        // There is no ways to get any element from the HashSet in O(1) time complexity.
        // So sadly, I choosed to use linked list here.
        LinkedList<int> visitableAsteroids = new();
        for (int row = 0; row < n; ++row) // max tc = 1,000,000
        {
            string line = Console.ReadLine()!;
            for (int col = 0; col < n; ++col)
            {
                char c = line[col];
                int cIndex1D = ConvertIndex2DTo1D(n, new(row, col));

                map[cIndex1D] = c;

                if (c == asteroidCharacter)
                {
                    visitableAsteroids.AddLast(cIndex1D);
                }
            }
        }

        // we don't use a variable just for visiting history
        int asteroidChunkCount = 0;
        Dictionary<int, HashSet<int>> asteroidChunks = new();
        Queue<int> asteroidQueue = new();

        while (true) // max tc = 1,000,000
        {
            while (asteroidQueue.Count < 1 &&
                   visitableAsteroids.Count > 0)
            {
                var node = visitableAsteroids.First!;

                int firstSrcIndex1D = node.Value;
                if (asteroidChunks.ContainsKey(firstSrcIndex1D) == false)
                {
                    // birth of the new chunk
                    asteroidChunks.Add(firstSrcIndex1D, new() { firstSrcIndex1D });
                    ++asteroidChunkCount;

                    asteroidQueue.Enqueue(firstSrcIndex1D); // tc = 1
                }

                visitableAsteroids.Remove(node);
            }

            if (asteroidQueue.Count < 1) // there is no more asteroid to consider
                break;

            int srcIndex1D = asteroidQueue.Dequeue();
            Index2D srcIndex2D = ConvertIndex1DTo2D(n, srcIndex1D);
            int srcRow = srcIndex2D.Row;
            int srcCol = srcIndex2D.Col;

            HashSet<int> srcAsteroidChunk = asteroidChunks[srcIndex1D];

            Index2D[] adjIndices2D = new Index2D[]
            {
                new(srcRow - 1, srcCol),
                new(srcRow + 1, srcCol),
                new(srcRow, srcCol - 1),
                new(srcRow, srcCol + 1),
            };

            for (int i = 0; i < adjIndices2D.Length; ++i) // tc = 4
            {
                Index2D adjIndex2D = adjIndices2D[i];
                int adjRow = adjIndex2D.Row;
                int adjCol = adjIndex2D.Col;
                if (adjRow < 0 || adjRow > (n - 1))
                    continue;

                if (adjCol < 0 || adjCol > (n - 1))
                    continue;

                int adjIndex1D = ConvertIndex2DTo1D(n, adjIndex2D);
                if (map[adjIndex1D] != asteroidCharacter)
                    continue;

                // The semantic of this condition is whether 'asteroid which of ID is adjIndex1D'
                // already confirmed to be affiliated with any asteroid chunk.
                // So, it's same with 'visitableAsteroids.Contains(adjIndex1D) == false'.
                if (srcAsteroidChunk.Contains(adjIndex1D))
                    continue;

                srcAsteroidChunk.Add(adjIndex1D);
                asteroidChunks.Add(adjIndex1D, srcAsteroidChunk);

                asteroidQueue.Enqueue(adjIndex1D);
            }
        }

        Console.Write(asteroidChunkCount);
    }

    private static Index2D ConvertIndex1DTo2D(int width, int index1D)
    {
        return new(index1D / width, index1D % width);
    }

    private static int ConvertIndex2DTo1D(int width, Index2D index2D)
    {
        return index2D.Row * width + index2D.Col;
    }
}