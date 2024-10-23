using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int m = tokens[1];

        int side = n + 1;

        int[,] map = new int[side, side];
        for (int i = 0; i < n; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int j = 0; j < n; ++j)
            {
                map[i + 1, j + 1] = tokens[j];
            }
        }

        int[,] sumLookup = new int[side, side];
        for (int row = 1; row < side; ++row)
        {
            int colSum = 0;
            for (int col = 1; col < side; ++col)
            {
                colSum += map[row, col];
                sumLookup[row, col] = sumLookup[row - 1, col] + colSum;
            }
        }

        StringBuilder output = new();
        for (int i = 0; i < m; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int x1 = tokens[0];
            int y1 = tokens[1];
            int x2 = tokens[2];
            int y2 = tokens[3];

            output.AppendLine($"{sumLookup[x2, y2] - (sumLookup[x1 - 1, y2] + sumLookup[x2, y1 - 1]) + sumLookup[x1 - 1, y1 - 1]}");
        }
        Console.Write(output);
    }
}