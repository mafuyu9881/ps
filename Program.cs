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
        // geosurvcomp, detectors for underground oil deposits
        // works on one large rect at a time,
        // and creates a grid which divides the rect into numerous square plots
        // @: pocket (because it contains oil), *: just a plot
        // check how many different deposits are contained in a grid
        // => connected components problem
        
        StringBuilder output = new();
        while (true)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int height = tokens[0]; // [1..100]
            int width = tokens[1]; // [1..100]

            if (height == 0) // as the problem guided
                break;
            
            LinkedList<int> objectives = new();
            bool[] map = new bool[width * height];
            for (int row = 0; row < height; ++row)
            {
                string line = Console.ReadLine()!;
                for (int col = 0; col < width; ++col)
                {
                    if (line[col] == '@')
                    {
                        int index1D = ConvertIndex2DTo1D(width, new(row, col));
                        map[index1D] = true;
                        objectives.AddLast(index1D);
                    }
                }
            }

            Dictionary<int, HashSet<int>> deposits = new();
            Queue<int> visitingQueue = new();
            bool[] visitedTable = new bool[width * height];

            int depositCount = 0;
            while (objectives.Count > 0)
            {
                if (visitingQueue.Count < 1)
                {
                    var node = objectives.First;
                    if (node == null) // never happens, but to prevent a compile warning
                        break;

                    visitingQueue.Enqueue(node.Value);
                    objectives.Remove(node);
                }

                int index1D = visitingQueue.Dequeue();
                Index2D index2D = ConvertIndex1DTo2D(width, index1D);
                int row = index2D.Row;
                int col = index2D.Col;

                HashSet<int>? deposit = null;
                if (visitedTable[index1D])
                {
                    deposit = deposits[index1D];
                }
                else
                {
                    deposit = new() { index1D };
                    deposits.Add(index1D, deposit);
                    ++depositCount;
                }
                
                Index2D[] adjIndices2D = new Index2D[]
                {
                    new(row - 1, col),
                    new(row + 1, col),
                    new(row, col - 1),
                    new(row, col + 1),
                    new(row - 1, col - 1),
                    new(row - 1, col + 1),
                    new(row + 1, col - 1),
                    new(row + 1, col + 1),
                };
                for (int j = 0; j < adjIndices2D.Length; ++j)
                {
                    Index2D adjIndex2D = adjIndices2D[j];

                    int adjRow = adjIndex2D.Row;
                    if (adjRow < 0 || adjRow > (height - 1))
                        continue;

                    int adjCol = adjIndex2D.Col;
                    if (adjCol < 0 || adjCol > (width - 1))
                        continue;
                    
                    int adjIndex1D = ConvertIndex2DTo1D(width, adjIndex2D);
                    if (visitedTable[adjIndex1D])
                        continue;

                    if (map[adjIndex1D] == false)
                        continue;

                    // if deposits already contain the deposit which adjIndex1D associated,
                    // then deposit already contains adjIndex1D too
                    if (deposits.ContainsKey(adjIndex1D) == false)
                    {
                        deposit.Add(adjIndex1D);
                        deposits.Add(adjIndex1D, deposit);
                    }

                    visitingQueue.Enqueue(adjIndex1D);
                    visitedTable[adjIndex1D] = true;
                }
            }
            output.AppendLine($"{depositCount}");
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