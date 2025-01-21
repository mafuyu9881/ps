using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0]; // [1, 1'000]
        int width = tokens[1]; // [1, 1'000]

        int subjects = int.Parse(Console.ReadLine()!);

        int[,] jungles = new int[height, width];
        int[,] oceans = new int[height, width];
        int[,] ices = new int[height, width];

        for (int row = 0; row < height; ++row) // max tc = 1'000
        {
            string line = Console.ReadLine()!;
            for (int col = 0; col < width; ++col) // max tc = 1'000
            {
                char biome = line[col];
                Accumulate(jungles, row, col, biome == 'J');
                Accumulate(oceans, row, col, biome == 'O');
                Accumulate(ices, row, col, biome == 'I');
            }
        }

        StringBuilder output = new();
        for (int i = 0; i < subjects; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int x0 = tokens[0] - 1;
            int y0 = tokens[1] - 1;
            int x1 = tokens[2] - 1;
            int y1 = tokens[3] - 1;

            Research(output, jungles, x0, y0, x1, y1);
            Research(output, oceans, x0, y0, x1, y1);
            Research(output, ices, x0, y0, x1, y1);
            output.AppendLine();
        }
        Console.Write(output);
    }

    private static void Accumulate(int[,] arr, int row, int col, bool detected)
    {
        bool leftUnavailable = (col - 1) < 0;
        bool upUnavailable = (row - 1) < 0;

        int fromLeft = leftUnavailable ? 0 : arr[row, col - 1];
        int fromUp = upUnavailable ? 0 : arr[row - 1, col];
        int duplicated = (leftUnavailable || upUnavailable) ? 0 : arr[row - 1, col - 1];
        
        arr[row, col] = fromLeft + fromUp + (detected ? 1 : 0) - duplicated;
    }

    private static void Research(StringBuilder output, int[,] arr, int x0, int y0, int x1, int y1)
    {
        bool leftUnavailable = (x0 - 1) < 0;
        bool upUnavailable = (y0 - 1) < 0;

        int fromLeft = leftUnavailable ? 0 : arr[x0 - 1, y1];
        int fromUp = upUnavailable ? 0 : arr[x1, y0 - 1];
        int duplicated = (leftUnavailable || upUnavailable) ? 0 : arr[x0 - 1, y0 - 1];

        output.Append($"{arr[x1, y1] - fromUp - fromLeft + duplicated} ");
    }
}