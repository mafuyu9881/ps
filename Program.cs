internal class Program
{
    private static void Main(string[] args)
    {
        const int InvalidRow = -1;
        const int AirPurifier = -1;
        const int AirPurifierCol = 0;

        const int Offsets = 4;
        int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0 };
        int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1 };

        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 3
        int height = tokens[0]; // [6, 50]
        int width = tokens[1]; // [6, 50]
        int t = tokens[2]; // [1, 1'000]

        int[,] frontBuffer = new int[height, width];
        int[,] backBuffer = new int[height, width];

        int upperAirPurifierRow = InvalidRow;
        int lowerAirPurifierRow = InvalidRow;

        for (int row = 0; row < height; ++row) // max tc = 50
        {
            // length = width = [6, 50]
            // element = [-1, 1'000]
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col) // max tc = 50
            {
                int attr = tokens[col];

                if (attr == AirPurifier)
                {
                    if (upperAirPurifierRow == InvalidRow)
                    {
                        upperAirPurifierRow = row;
                    }
                    else
                    {
                        lowerAirPurifierRow = row;
                    }
                }

                frontBuffer[row, col] = attr;
            }
        }
        
        Action ClearBackBuffer = () =>
        {
            for (int row = 0; row < height; ++row) // max tc = 50
            {
                for (int col = 0; col < width; ++col) // max tc = 50
                {
                    backBuffer[row, col] = Math.Min(frontBuffer[row, col], 0); // to consider -1
                }
            }
        };

        Action SwapBuffer = () =>
        {
            var temp = frontBuffer;
            frontBuffer = backBuffer;
            backBuffer = temp;
        };

        Action<int> LeftShift = (row) =>
        {
            for (int col = width - 1; col > 0; --col) // max tc = about 50
            {
                backBuffer[row, col - 1] = frontBuffer[row, col];
            }
        };

        Action<int> RightShift = (row) =>
        {
            for (int col = 0; col < width - 1; ++col) // max tc = about 50
            {
                int attr = frontBuffer[row, col];
                if (attr == AirPurifier)
                    attr = 0;

                backBuffer[row, col + 1] = attr;
            }
        };

        Action<int, int, int> UpShift = (col, startRow, endRow) =>
        {
            if (startRow <= endRow) // max tc = about 50
                return; // startRow must be greater than endRow

            for (int row = startRow; row > endRow; --row)
            {
                if (backBuffer[row - 1, col] == AirPurifier)
                    continue;

                backBuffer[row - 1, col] = frontBuffer[row, col]; // in this context, `frontBuffer[row, col]` can't be `AirPurifier`
            }
        };

        Action<int, int, int> DownShift = (col, startRow, endRow) =>
        {
            if (startRow >= endRow) // max tc = about 50
                return; // startRow must be less than endRow

            for (int row = startRow; row < endRow; ++row)
            {
                if (backBuffer[row + 1, col] == AirPurifier)
                    continue;

                backBuffer[row + 1, col] = frontBuffer[row, col]; // frontBuffer[row, col] can't be `AirPurifier` too
            }
        };

        for (int i = 0; i < t; ++i) // max tc = 1'000
        {
            ClearBackBuffer();

            for (int row = 0; row < height; ++row) // max tc = 50
            {
                for (int col = 0; col < width; ++col) // max tc = 50
                {
                    int attr = frontBuffer[row, col];
                    if (attr <= 0)
                        continue;

                    int spread = attr / 5;
                    if (spread > 0)
                    {
                        for (int j = 0; j < Offsets; ++j) // max tc = 4
                        {
                            int adjRow = row + RowOffsets[j];
                            if (adjRow < 0 || adjRow > height - 1)
                                continue;

                            int adjCol = col + ColOffsets[j];
                            if (adjCol < 0 || adjCol > width - 1)
                                continue;

                            if (backBuffer[adjRow, adjCol] == AirPurifier)
                                continue;

                            attr -= spread;
                            backBuffer[adjRow, adjCol] += spread;
                        }
                    }

                    backBuffer[row, col] += attr;
                }
            }

            SwapBuffer();

            ClearBackBuffer();

            RightShift(upperAirPurifierRow);
            UpShift(width - 1, upperAirPurifierRow, 0);
            LeftShift(0);
            DownShift(0, 0, upperAirPurifierRow);

            RightShift(lowerAirPurifierRow);
            DownShift(width - 1, lowerAirPurifierRow, height - 1);
            LeftShift(height - 1);
            UpShift(0, height - 1, lowerAirPurifierRow);

            for (int row = 0 + 1; row < upperAirPurifierRow; ++row) // max tc = less than 50
            {
                for (int col = AirPurifierCol + 1; col < width - 1; ++col) // max tc = less than 50
                {
                    backBuffer[row, col] = frontBuffer[row, col];
                }
            }

            for (int row = lowerAirPurifierRow + 1; row < height - 1; ++row) // max tc = less than 50
            {
                for (int col = AirPurifierCol + 1; col < width - 1; ++col) // max tc = less than 50
                {
                    backBuffer[row, col] = frontBuffer[row, col];
                }
            }

            SwapBuffer();
        }

        int fineDust = 0;
        for (int row = 0; row < height; ++row) // max tc = 50
        {
            for (int col = 0; col < width; ++col) // max tc = 50
            {
                int attr = frontBuffer[row, col];
                if (attr == AirPurifier)
                    continue;

                fineDust += attr;
            }
        }
        Console.Write(fineDust);
    }
}