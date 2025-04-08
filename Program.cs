internal class Program
{
    private static void Main(string[] args)
    {
        const int ExteriorAir = -1;
        const int InteriorAir = 0;
        const int Cheese = 1;

        const int Offsets = 4;
        int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0 };
        int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1 };

        int[] tokens = null!;
        
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];

        int[] frontBuffer = new int[height * width];
        int[] backBuffer = new int[height * width];

        Action Flush = () =>
        {
            var temp = frontBuffer;
            frontBuffer = backBuffer;
            backBuffer = temp;

            // no need to clear `backBuffer`
        };

        Func<int, int, int> ConvertIndex2DTo1D = (row, col) =>
        {
            return row * width + col;
        };
        Func<int, (int, int)> ConvertIndex1DTo2D = (index) =>
        {
            return (index / width, index % width);
        };

        int cheeses = 0;
        for (int row = 0; row < height; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col)
            {
                int index = ConvertIndex2DTo1D(row, col);

                int attr = tokens[col];
                if (attr == Cheese)
                    ++cheeses;

                frontBuffer[index] = attr;
            }
        }

        Queue<int> frontier = new();

        int sIndex = 0;
        frontBuffer[sIndex] = ExteriorAir;        
        frontier.Enqueue(sIndex);
        while (frontier.Count > 0)
        {
            int index = frontier.Dequeue();
            int row = index / width;
            int col = index % width;

            for (int i = 0; i < Offsets; ++i)
            {
                int adjRow = row + RowOffsets[i];
                if (adjRow < 0 || adjRow > height - 1)
                    continue;

                int adjCol = col + ColOffsets[i];
                if (adjCol < 0 || adjCol > width - 1)
                    continue;

                int adjIndex = adjRow * width + adjCol;
                int adjAttr = frontBuffer[adjIndex];
                if (adjAttr != InteriorAir)
                    continue;

                frontBuffer[adjIndex] = ExteriorAir;
                frontier.Enqueue(adjIndex);
            }
        }

        int elapsedTime = 0;
        while (cheeses > 0)
        {
            for (int index = 0; index < frontBuffer.Length; ++index)
            {
                int frontBufferAttr = frontBuffer[index];
                int row = index / width;
                int col = index % width;

                int exposed = 0;
                if (frontBufferAttr == Cheese)
                {
                    for (int j = 0; j < Offsets; ++j)
                    {
                        int adjRow = row + RowOffsets[j];
                        if (adjRow < 0 || adjRow > height - 1)
                            continue;

                        int adjCol = col + ColOffsets[j];
                        if (adjCol < 0 || adjCol > width - 1)
                            continue;

                        int adjIndex = adjRow * width + adjCol;
                        int adjAttr = frontBuffer[adjIndex];
                        if (adjAttr != ExteriorAir)
                            continue;

                        ++exposed;
                    }
                }
                
                if (exposed < 2)
                {
                    backBuffer[index] = frontBufferAttr;
                }
                else
                {
                    backBuffer[index] = ExteriorAir;
                    --cheeses;
                }
            }

            Flush();

            ++elapsedTime;
        }
        Console.Write(elapsedTime);
    }
}