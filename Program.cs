using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int Offsets = 4;
        int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0 };
        int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1 };

        int t = int.Parse(Console.ReadLine()!); // [1, 10]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 10
        {
            int[] tokens = null!;

            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int h = tokens[0]; // [2, 100]
            int w = tokens[1]; // [2, 100]
            int o = tokens[2]; // [0, h * w] = 10'000
            int f = tokens[3]; // [0, 10'000]
            int sRow = tokens[4]; // [1, h] = [1, 100]
            int sCol = tokens[5]; // [1, w] = [1, 100]
            int eRow = tokens[6]; // [1, h] = [1, 100]
            int eCol = tokens[7]; // [1, w] = [1, 100]

            int[,] map = new int[h + 1, w + 1];
            for (int j = 0; j < o; ++j) // max tc = 10'000
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int oRow = tokens[0]; // [1, h] = [1, 100]
                int oCol = tokens[1]; // [1, w] = [1, 100]
                int l = tokens[2]; // [1, 50]
                map[oRow, oCol] = l;
            }

            bool[,] visited = new bool[h + 1, w + 1];
            Queue<(int row, int col, int remainForce)> frontier = new();

            visited[sRow, sCol] = true;
            frontier.Enqueue((sRow, sCol, f));

            while (frontier.Count > 0)
            {
                var element = frontier.Dequeue();
                int row = element.row;
                int col = element.col;
                int remainForce = element.remainForce;
                int l = map[row, col];

                if (remainForce < 1)
                    continue;

                for (int j = 0; j < Offsets; ++j)
                {
                    int adjRow = row + RowOffsets[j];
                    if (adjRow < 1 || adjRow > h)
                        continue;

                    int adjCol = col + ColOffsets[j];
                    if (adjCol < 1 || adjCol > w)
                        continue;

                    if (visited[adjRow, adjCol])
                        continue;

                    int adjL = map[adjRow, adjCol];
                    if (remainForce < adjL - l)
                        continue;

                    visited[adjRow, adjCol] = true;
                    frontier.Enqueue((adjRow, adjCol, remainForce - 1));
                }
            }

            sb.AppendLine(visited[eRow, eCol] ? "잘했어!!" : "인성 문제있어??");
        }
        Console.Write(sb);
    }
}