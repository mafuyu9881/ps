internal class Program
{
    private static void Main(string[] args)
    {
        int m = 4;
        int n = 3;
        
        Index2D[] puddles = [ new(2, 2) ];

        const int GroundAttribute = 0;
        const int PuddleAttribute = 1;
        const int SchoolAttribute = 2;

        int[,] map = new int[n, m];
        for (int i = 0; i < puddles.Length; ++i)
        {
            Index2D puddleIndex2D = puddles[i];

            map[puddleIndex2D.row, puddleIndex2D.col] = PuddleAttribute;
        }
        map[n - 1, m - 1] = SchoolAttribute;

        int pathsCount = 0;
        bool[,] visited = new bool[n, m];
        ComputePathsCount(ref pathsCount,
                          map,
                          visited,
                          m,
                          n,
                          new Index2D(0, 0),
                          PuddleAttribute,
                          SchoolAttribute);
        Console.Write(pathsCount);
    }

    private static void ComputePathsCount(ref int pathsCount,
                                          int[,] map,
                                          bool[,] visited,
                                          int width,
                                          int height,
                                          Index2D srcIndex2D,
                                          int puddleAttribute,
                                          int schoolAttribute)
    {
        Index2D[] candidateIndices2D = new Index2D[]
        {
            new Index2D(srcIndex2D.row + 1, srcIndex2D.col),
            new Index2D(srcIndex2D.row, srcIndex2D.col + 1),
        };

        for (int i = 0; i < candidateIndices2D.Length; ++i)
        {
            Index2D candidateIndex2D = candidateIndices2D[i];
            int candidateRow = candidateIndex2D.row;
            int candidateCol = candidateIndex2D.col;

            if (candidateRow > height - 1 || candidateCol > width - 1)
                continue;

            if (visited[candidateRow, candidateCol])
                continue;

            int candidateAttribute = map[candidateRow, candidateCol];
            if (candidateAttribute == puddleAttribute)
                continue;

            visited[candidateRow, candidateCol] = true;

            if (candidateAttribute == schoolAttribute)
            {
                ++pathsCount;
            }
            else
            {
                ComputePathsCount(ref pathsCount,
                                  map,
                                  visited,
                                  width,
                                  height,
                                  candidateIndex2D,
                                  puddleAttribute,
                                  schoolAttribute);
            }

            visited[candidateRow, candidateCol] = false;
        }
    }

    public struct Index2D
    {
        public int row;
        public int col;

        public Index2D(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}