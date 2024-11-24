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
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];

        const int WhitePixel = 1;

        const int InvalidDistance = -1;
        int[] distances = new int[width * height];
        for (int i = 0; i < distances.Length; ++i)
        {
            distances[i] = InvalidDistance;
        }

        int[] map = new int[width * height];
        LinkedList<int> whitePixels = new();
        for (int row = 0; row < height; ++row)
        {
            string line = Console.ReadLine()!;
            for (int col = 0; col < width; ++col)
            {
                int pixel = line[col] - '0';

                int index1D = ConvertIndex2DTo1D(width, new(row, col));

                map[index1D] = pixel;
                if (pixel == WhitePixel)
                {
                    whitePixels.AddLast(index1D);
                    distances[index1D] = 0;
                }
            }
        }

        Queue<int> visitingQueue = new();
        while (true)
        {
            while (visitingQueue.Count < 1 && whitePixels.Count > 0)
            {
                var node = whitePixels.First!;

                int initialSrcIndex1D = node.Value;

                visitingQueue.Enqueue(initialSrcIndex1D);
                whitePixels.Remove(node);
            }

            if (visitingQueue.Count < 1)
                break;

            int srcIndex1D = visitingQueue.Dequeue();
            Index2D srcIndex2D = ConvertIndex1DTo2D(width, srcIndex1D);
            int srcRow = srcIndex2D.Row;
            int srcCol = srcIndex2D.Col;

            int newDistance = distances[srcIndex1D] + 1;
            Index2D[] adjIndices2D = new Index2D[]
            {
                new(srcRow - 1, srcCol),
                new(srcRow + 1, srcCol),
                new(srcRow, srcCol - 1),
                new(srcRow, srcCol + 1),
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
                int oldDistance = distances[adjIndex1D];
                if (oldDistance != InvalidDistance &&
                    oldDistance <= newDistance)
                    continue;

                distances[adjIndex1D] = newDistance;
                visitingQueue.Enqueue(adjIndex1D);
            }
        }

        StringBuilder output = new();
        for (int row = 0; row < height; ++row)
        {
            StringBuilder line = new();
            for (int col = 0; col < width; ++col)
            {
                line.Append($"{distances[ConvertIndex2DTo1D(width, new(row, col))]} ");
            }
            output.AppendLine($"{line}");
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