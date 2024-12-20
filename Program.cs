internal class Program
{
    const int InvalidDistances = -1;
    const int offsets = 4;
    static readonly int[] RowOffsets = new int[4] { -1, 1, 0, 0 };
    static readonly int[] ColOffsets = new int[4] { 0, 0, -1, 1 };

    private static void Main(string[] args)
    {
        int[] integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = integerTokens[0]; // 2 ≤ height, width ≤ 100
        int width = integerTokens[1];

        int[,] map = new int[height, width];
        int[,] distances = new int[height, width];
        for (int row = 0; row < height; ++row)
        {
            string stringToken = Console.ReadLine()!;
            for (int col = 0; col < width; ++col)
            {
                map[row, col] = stringToken[col] - '0';
                distances[row, col] = InvalidDistances;
            }
        }

        int departureRow = 0;
        int departureCol = 0;
        int arrivalRow = height - 1;
        int arrivalCol = width - 1;

        Queue<(int row, int col)> q = new();

        distances[departureRow, departureCol] = 1;
        q.Enqueue(new(departureRow, departureCol));
        while (q.Count > 0)
        {
            var index2D = q.Dequeue();
            int row = index2D.row;
            int col = index2D.col;

            for (int i = 0; i < offsets; ++i)
            {
                (int row, int col) adjIndex2D = new(row + RowOffsets[i], col + ColOffsets[i]);
                int adjRow = adjIndex2D.row;
                if (adjRow < 0 || adjRow > height - 1)
                    continue;

                int adjCol = adjIndex2D.col;
                if (adjCol < 0 || adjCol > width - 1)
                    continue;

                if (map[adjRow, adjCol] == 0)
                    continue;

                if (distances[adjRow, adjCol] != InvalidDistances)
                    continue;

                distances[adjRow, adjCol] = distances[row, col] + 1;
                q.Enqueue(new(adjRow, adjCol));
            }
        }
        Console.Write(distances[arrivalRow, arrivalCol]);
    }
}