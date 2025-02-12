using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0]; // [1, 500]
        int width = tokens[1]; // [1, 500]

        int[] map = new int[height * width];
        for (int row = 0; row < height; ++row) // max tc = 500
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col) // max tc = 500
            {
                map[row * width + col] = tokens[col];
            }
        }

        const int Offsets = 8;
        int[] rowOffsets = new int[Offsets] { -1, 1, 0, 0, -1, 1, -1, 1 };
        int[] colOffsets = new int[Offsets] { 0, 0, -1, 1, -1, -1, 1, 1 };

        const int InvalidArrival = -1;
        int[] arrivalIndices = new int[map.Length];
        for (int i = 0; i < arrivalIndices.Length; ++i) // max tc = 25'000
        {
            arrivalIndices[i] = InvalidArrival;
        }

        const int InvalidIndex = -1;

        int[] result = new int[map.Length];
        for (int row = 0; row < height; ++row) // max tc = 500
        {
            for (int col = 0; col < width; ++col) // max tc = 500
            {
                int marbleIndex = row * width + col;

                LinkedList<int> visitedIndices = new();
                while (true) // total tc = 25'000
                {
                    if (arrivalIndices[marbleIndex] != InvalidArrival)
                    {
                        marbleIndex = arrivalIndices[marbleIndex];
                        break;
                    }
                    else
                    {
                        visitedIndices.AddLast(marbleIndex);
                        
                        int currRow = marbleIndex / width;
                        int currCol = marbleIndex % width;

                        int movableIndex = InvalidIndex;

                        for (int i = 0; i < Offsets; ++i) // tc = 8
                        {
                            int adjRow = currRow + rowOffsets[i];
                            if (adjRow < 0 || adjRow > height - 1)
                                continue;

                            int adjCol = currCol + colOffsets[i];
                            if (adjCol < 0 || adjCol > width - 1)
                                continue;

                            int adjIndex = adjRow * width + adjCol;
                            if (map[adjIndex] > map[marbleIndex])
                                continue;

                            if (movableIndex != InvalidIndex && map[adjIndex] > map[movableIndex])
                                continue;

                            movableIndex = adjIndex;
                        }

                        if (movableIndex == InvalidIndex)
                            break;

                        marbleIndex = movableIndex;
                    }
                }

                for (var node = visitedIndices.First; node != null; node = node.Next) // total tc = 25'000
                {
                    arrivalIndices[node.Value] = marbleIndex;
                }

                ++result[marbleIndex];
            }
        }

        StringBuilder sb = new();
        for (int row = 0; row < height; ++row)
        {
            for (int col = 0; col < width; ++col)
            {
                sb.Append($"{result[row * width + col]} ");
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}