using System.Text;

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
        StringBuilder output = new();
        while (true)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int w = tokens[0];
            int h = tokens[1];

            if (w == 0)
                break;

            bool[] map = new bool[w * h];
            LinkedList<int> objectives = new();
            for (int row = 0; row < h; ++row)
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                for (int col = 0; col < w; ++col)
                {
                    int index1D = ConvertIndex2DTo1D(w, new(row, col));

                    bool land = tokens[col] == 1;
                    map[index1D] = land;
                    if (land) objectives.AddLast(index1D);
                }
            }

            Dictionary<int, HashSet<int>> islands = new();
            Queue<int> visitingQueue = new();
            bool[] visitedTable = new bool[w * h];

            int islandCount = 0;
            while (objectives.Count > 0)
            {
                if (visitingQueue.Count < 1)
                {
                    var node = objectives.First;
                    if (node == null) // never happens, but to prevent a compile warning
                        break;

                    int index1D = node.Value;
                    visitingQueue.Enqueue(index1D);
                    visitedTable[index1D] = true;
                    objectives.Remove(node);
                }

                int srcIndex1D = visitingQueue.Dequeue();
                Index2D srcIndex2D = ConvertIndex1DTo2D(w, srcIndex1D);
                int srcRow = srcIndex2D.Row;
                int srcCol = srcIndex2D.Col;

                HashSet<int>? island = null;
                if (islands.ContainsKey(srcIndex1D))
                {
                    island = islands[srcIndex1D];
                }
                else
                {
                    island = new() { srcIndex1D };
                    islands.Add(srcIndex1D, island);
                    ++islandCount;
                }

                Index2D[] adjIndices2D = new Index2D[]
                {
                    new(srcRow - 1, srcCol),
                    new(srcRow + 1, srcCol),
                    new(srcRow, srcCol - 1),
                    new(srcRow, srcCol + 1),
                    new(srcRow - 1, srcCol - 1),
                    new(srcRow - 1, srcCol + 1),
                    new(srcRow + 1, srcCol - 1),
                    new(srcRow + 1, srcCol + 1),
                };
                for (int i = 0; i < adjIndices2D.Length; ++i)
                {
                    Index2D adjIndex2D = adjIndices2D[i];
                    int adjRow = adjIndex2D.Row;
                    int adjCol = adjIndex2D.Col;
                    int adjIndex1D = ConvertIndex2DTo1D(w, adjIndex2D);
                    
                    if (adjRow < 0 || adjRow > (h - 1))
                        continue;

                    if (adjCol < 0 || adjCol > (w - 1))
                        continue;

                    if (visitedTable[adjIndex1D])
                        continue;

                    if (map[adjIndex1D] == false)
                        continue;

                    if (islands.ContainsKey(adjIndex1D) == false)
                    {
                        island.Add(adjIndex1D);
                        islands.Add(adjIndex1D, island);
                    }

                    visitingQueue.Enqueue(adjIndex1D);
                    visitedTable[adjIndex1D] = true;
                }
            }
            output.AppendLine($"{islandCount}");
        }
        Console.Write(output);
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