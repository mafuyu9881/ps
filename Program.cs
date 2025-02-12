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

        const int InvalidIndex = -1;

        int[] result = new int[map.Length];
        for (int row = 0; row < height; ++row) // max tc = 500
        {
            for (int col = 0; col < width; ++col) // max tc = 500
            {
                int currIndex = row * width + col;

                while (true)
                {
                    int currRow = currIndex / width;
                    int currCol = currIndex % width;
                    
                    int nextIndex = InvalidIndex;

                    for (int i = 0; i < Offsets; ++i) // tc = 4
                    {
                        int adjRow = currRow + rowOffsets[i];
                        if (adjRow < 0 || adjRow > height - 1)
                            continue;

                        int adjCol = currCol + colOffsets[i];
                        if (adjCol < 0 || adjCol > width - 1)
                            continue;

                        int adjIndex = adjRow * width + adjCol;
                        if (map[adjIndex] > map[currIndex])
                            continue;

                        if (nextIndex != InvalidIndex && map[adjIndex] > map[nextIndex])
                            continue;

                        nextIndex = adjIndex;
                    }

                    if (nextIndex == InvalidIndex)
                        break;

                    currIndex = nextIndex;
                }

                ++result[currIndex];
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