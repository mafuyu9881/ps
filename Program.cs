internal class Program
{
    private static void Main(string[] args)
    {
        const int MinExteriorAir = 2; // if the attribute is greater than 1, it is treated as ExteriorAir
        const int InteriorAir = 0;
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

        LinkedList<int> cheeseIndices = new();
        for (int row = 0; row < height; ++row) // max tc = 100
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col) // max tc = 100
            {
                int index = ConvertIndex2DTo1D(row, col);

                int attr = tokens[col];
                if (attr == Cheese)
                    cheeseIndices.AddLast(index);

                map[index] = attr;
            }
        }

        Queue<int> frontier = new();

        int sIndex = 0;
        map[sIndex] = MinExteriorAir;
        frontier.Enqueue(sIndex);
        while (frontier.Count > 0) // max tc = 10'000
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

                int adjIndex = adjRow * width + adjCol;
                int adjAttr = map[adjIndex];
                if (adjAttr != InteriorAir)
                    continue;

                map[adjIndex] = MinExteriorAir;
                frontier.Enqueue(adjIndex);
            }
        }

        int currMaxExteriorAir = MinExteriorAir;
        int elapsedTime = 0;
        while (cheeseIndices.Count > 0) // max tc = below 10'000
        {
            int nextMaxExteriorAir = currMaxExteriorAir + 1;
            var cheeseIndicesCurrLLN = cheeseIndices.First;
            while (cheeseIndicesCurrLLN != null) // max tc = below 10'000
            {
                int index = cheeseIndicesCurrLLN.Value;

                int attr = map[index];
                int row = index / width;
                int col = index % width;

                var cheeseIndicesNextLLN = cheeseIndicesCurrLLN.Next;
                
                int exposed = 0;
                if (attr == Cheese)
                {
                    for (int j = 0; j < Offsets; ++j) // tc = 4
                    {
                        int adjRow = row + RowOffsets[j];
                        if (adjRow < 0 || adjRow > height - 1)
                            continue;

                        int adjCol = col + ColOffsets[j];
                        if (adjCol < 0 || adjCol > width - 1)
                            continue;

                        int adjIndex = adjRow * width + adjCol;
                        int adjAttr = map[adjIndex];
                        if (adjAttr < MinExteriorAir ||
                            adjAttr > currMaxExteriorAir)
                            continue;

                        ++exposed;
                    }
                }

                if (exposed >= 2)
                {
                    map[index] = nextMaxExteriorAir;
                    cheeseIndices.Remove(cheeseIndicesCurrLLN);
                }
                
                cheeseIndicesCurrLLN = cheeseIndicesNextLLN;
            }

            currMaxExteriorAir = nextMaxExteriorAir; // cheese always melts

            ++elapsedTime;
        }
        Console.Write(elapsedTime);
    }
}