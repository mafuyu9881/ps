internal class Program
{
    private static void Main(string[] args)
    {
        LinkedList<(int[] rowOffsets, int[] colOffsets)> offsets = new();
        offsets.AddLast((
            new int[] { 0, 1, 2, 3 }, // I tetromino (vertical)
            new int[] { 0, 0, 0, 0 }
        ));
        offsets.AddLast((
            new int[] { 0, 0, 0, 0 }, // I tetromino (horizontal)
            new int[] { 0, 1, 2, 3 }
        ));
        offsets.AddLast((
            new int[] { 0, 0, 1, 1 }, // O tetromino
            new int[] { 0, 1, 0, 1 }
        ));
        offsets.AddLast((
            new int[] { 0, 1, 2, 2 }, // L tetromino
            new int[] { 0, 0, 0, 1 }
        ));
        offsets.AddLast((
            new int[] { 0, 0, 0, 1 }, // L tetromino -90deg
            new int[] { 0, 1, 2, 0 }
        ));
        offsets.AddLast((
            new int[] { 0, 0, 1, 2 }, // L tetromino -180deg
            new int[] { 0, 1, 1, 1 }
        ));
        offsets.AddLast((
            new int[] { 1, 1, 1, 0 }, // L tetromino -270deg
            new int[] { 0, 1, 2, 2 }
        ));
        offsets.AddLast((
            new int[] { 2, 2, 1, 0 }, // J tetromino 
            new int[] { 0, 1, 1, 1 }
        ));
        offsets.AddLast((
            new int[] { 0, 1, 1, 1 }, // J tetromino -90deg
            new int[] { 0, 0, 1, 2 }
        ));
        offsets.AddLast((
            new int[] { 0, 0, 1, 2 }, // J tetromino -180deg
            new int[] { 0, 1, 0, 0 }
        ));
        offsets.AddLast((
            new int[] { 0, 0, 0, 1 }, // J tetromino -270deg
            new int[] { 0, 1, 2, 2 }
        ));
        offsets.AddLast((
            new int[] { 0, 1, 1, 2 }, // S tetromino
            new int[] { 0, 0, 1, 1 }
        ));
        offsets.AddLast((
            new int[] { 1, 1, 0, 0 }, // S tetromino -90deg
            new int[] { 0, 1, 1, 2 }
        ));
        offsets.AddLast((
            new int[] { 0, 1, 1, 2 }, // Z tetromino
            new int[] { 1, 1, 0, 0 }
        ));
        offsets.AddLast((
            new int[] { 0, 0, 1, 1 }, // Z tetromino -90deg
            new int[] { 0, 1, 1, 2 }
        ));
        offsets.AddLast((
            new int[] { 1, 1, 1, 0 }, // T tetromino
            new int[] { 0, 1, 2, 1 }
        ));
        offsets.AddLast((
            new int[] { 0, 1, 1, 2 }, // T tetromino -90deg
            new int[] { 0, 0, 1, 0 }
        ));
        offsets.AddLast((
            new int[] { 0, 0, 0, 1 }, // T tetromino -180deg
            new int[] { 0, 1, 2, 1 }
        ));
        offsets.AddLast((
            new int[] { 1, 0, 1, 2 }, // T tetromino -270deg
            new int[] { 0, 1, 1, 1 }
        ));

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];

        int[] map = new int[width * height];
        for (int row = 0; row < height; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col)
            {
                map[row * width + col] = tokens[col]; // [1, 1000]
            }
        }
        
        const int InvalidSum = -1;

        int maxSum = InvalidSum;
        for (int index1D = 0; index1D < map.Length; ++index1D)
        {
            int row = index1D / width;
            int col = index1D % width;

            for (var node = offsets.First; node != null; node = node.Next)
            {
                int sum = 0;
                int[] rowOffsets = node.Value.rowOffsets;
                int[] colOffsets = node.Value.colOffsets;
                for (int j = 0; j < rowOffsets.Length; ++j)
                {
                    int adjRow = row + rowOffsets[j];
                    int adjCol = col + colOffsets[j];
                    if (adjRow < 0 || adjRow > height - 1 ||
                        adjCol < 0 || adjCol > width - 1)
                    {
                        sum = InvalidSum;
                        break;
                    }

                    sum += map[adjRow * width + adjCol];
                }

                if (sum == InvalidSum)
                    continue;

                if (maxSum != InvalidSum && sum < maxSum)
                    continue;

                maxSum = sum;
            }
        }

        Console.Write(maxSum);
    }
}