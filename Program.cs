internal class Program
{
    private static void Main(string[] args)
    {
        const int MinExteriorAir = 2; // if the attribute is greater than 1, it is treated as ExteriorAir
        const int Cheese = 1;

        const int Offsets = 4;
        int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0 };
        int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1 };

        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];

        int[] map = new int[height * width];

        Func<int, int, int> ConvertIndex2DTo1D = (row, col) =>
        {
            return row * width + col;
        };
        Func<int, (int, int)> ConvertIndex1DTo2D = (index) =>
        {
            return (index / width, index % width);
        };

        int cheeses = 0;
        for (int row = 0; row < height; ++row) // max tc = 100
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col) // max tc = 100
            {
                int index = ConvertIndex2DTo1D(row, col);

                int attr = tokens[col];
                if (attr == Cheese)
                    ++cheeses;
                else
                    attr = MinExteriorAir;

                map[index] = attr;
            }
        }

        int elapsedTime = 0;
        int currExteriorAir = MinExteriorAir + 1;
        while (cheeses > 0) // max tc = below 10'000
        {
            int tempExteriorAir = currExteriorAir + 1;
            int nextExteriorAir = currExteriorAir + 2;

            Queue<int> frontier = new();

            int sIndex = 0;
            map[sIndex] = currExteriorAir;
            frontier.Enqueue(sIndex);
            while (frontier.Count > 0) // max tc = below 10'000
            {
                int index = frontier.Dequeue();
                int row = index / width;
                int col = index % width;
                
                for (int i = 0; i < Offsets; ++i) // tc = 4
                {
                    int adjRow = row + RowOffsets[i];
                    if (adjRow < 0 || adjRow > height - 1)
                        continue;

                    int adjCol = col + ColOffsets[i];
                    if (adjCol < 0 || adjCol > width - 1)
                        continue;

                    int adjIndex = ConvertIndex2DTo1D(adjRow, adjCol);
                    int adjAttr = map[adjIndex];
                    if (adjAttr == Cheese || adjAttr >= currExteriorAir)
                        continue;

                    map[adjIndex] = currExteriorAir;
                    frontier.Enqueue(adjIndex);
                }
            }

            for (int row = 0; row < height; ++row) // max tc = 100
            {
                for (int col = 0; col < width; ++col) // max tc = 100
                {
                    int index = ConvertIndex2DTo1D(row, col);
                    int attr = map[index];
                    if (attr != Cheese)
                        continue;

                    int exposed = 0;
                    for (int i = 0; i < Offsets; ++i) // tc = 4
                    {
                        int adjRow = row + RowOffsets[i];
                        if (adjRow < 0 || adjRow > height - 1)
                            continue;
                        
                        int adjCol = col + ColOffsets[i];
                        if (adjCol < 0 || adjCol > width - 1)
                            continue;

                        int adjIndex = ConvertIndex2DTo1D(adjRow, adjCol);
                        int adjAttr = map[adjIndex];
                        if (adjAttr == Cheese || adjAttr > currExteriorAir)
                            continue;

                        ++exposed;
                    }

                    if (exposed >= 2)
                    {
                        map[index] = tempExteriorAir;
                        --cheeses;
                    }
                }
            }
            
            currExteriorAir = nextExteriorAir;

            ++elapsedTime;
        }
        Console.Write(elapsedTime);
    }
}