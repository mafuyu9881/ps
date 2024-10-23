internal class Program
{
    private static void Main(string[] args)
    {
        const char R = 'R';
        const char G = 'G';

        int n = int.Parse(Console.ReadLine()!);

        int mapLength = n * n;

        char[] map = new char[mapLength];
        for (int row = 0; row < n; ++row)
        {
            string tokens = Console.ReadLine()!;
            for (int col = 0; col < n; ++col)
            {
                map[ConvertIndex2DTo1D(n, new(row, col))] = tokens[col];
            }
        }

        int normalAreaCount = ComputeAreaCount(n, map, (char c0, char c1) => { return c0 == c1; });
        int blindAreaCount = ComputeAreaCount(n, map, (char c0, char c1) => 
        {
            if (c0 == c1)
                return true;

            if (c0 == R && c1 == G)
                return true;

            if (c1 == R && c0 == G)
                return true;

            return false;
        });

        Console.Write($"{normalAreaCount} {blindAreaCount}");
    }

    private static int ComputeAreaCount(int width, char[] map, Func<char, char, bool> colorEquals)
    {
        int mapLength = map.Length;

        HashSet<int> waitingIndices = new();
        for (int i = 0; i < mapLength; ++i)
        {
            waitingIndices.Add(i);
        }

        bool[] visitedLookup = new bool[mapLength];
        Queue<int> visitingQueue = new();

        LinkedList<LinkedList<int>> areaList = new();
        LinkedList<int>[] areaLookup = new LinkedList<int>[mapLength];

        while (waitingIndices.Count > 0)
        {
            if (visitingQueue.Count < 1)
            {
                int waitingIndex = waitingIndices.First();
                visitingQueue.Enqueue(waitingIndex);
                waitingIndices.Remove(waitingIndex);
            }

            int visitingIndex = visitingQueue.Dequeue();
            Index2D visitingIndex2D = ConvertIndex1DTo2D(width, visitingIndex);

            LinkedList<int>? area;
            if (visitedLookup[visitingIndex])
            {
                area = areaLookup[visitingIndex];
            }
            else
            {
                area = new LinkedList<int>();
                area.AddLast(visitingIndex);
                
                areaList.AddLast(area);
                areaLookup[visitingIndex] = area;
            }

            visitedLookup[visitingIndex] = true;

            Index2D[] adjacentIndices = new Index2D[]
            {
                new(visitingIndex2D.row + 1, visitingIndex2D.col),
                new(visitingIndex2D.row, visitingIndex2D.col + 1),
                new(visitingIndex2D.row - 1, visitingIndex2D.col),
                new(visitingIndex2D.row, visitingIndex2D.col - 1),
            };

            for (int i = 0; i < adjacentIndices.Length; ++i)
            {
                Index2D adjacentIndex2D = adjacentIndices[i];
                int adjacentIndex = ConvertIndex2DTo1D(width, adjacentIndex2D);

                if (Index2DValidation(width, width, adjacentIndex2D) == false)
                    continue;

                if (visitedLookup[adjacentIndex])
                    continue;

                if (colorEquals(map[visitingIndex], map[adjacentIndex]) == false)
                    continue;

                visitedLookup[adjacentIndex] = true;
                visitingQueue.Enqueue(adjacentIndex);
                area.AddLast(adjacentIndex);
                areaLookup[adjacentIndex] = area;
            }
        }

        return areaList.Count();
    }
    
    private static bool Index2DValidation(int width, int height, Index2D index2D)
    {
        int row = index2D.row;
        int col = index2D.col;

        return (row >= 0) && (row < height) && (col >= 0) && (col < width);
    }

    private static Index2D ConvertIndex1DTo2D(int width, int index1D)
    {
        return new(index1D / width, index1D % width);
    }

    private static int ConvertIndex2DTo1D(int width, Index2D index2D)
    {
        return index2D.row * width + index2D.col;
    }

    private struct Index2D
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