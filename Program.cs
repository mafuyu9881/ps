using System.Text;

internal class Program
{
    private struct Index2D
    {
        public int row;
        public int col;
        public int moves;

        public Index2D(int row, int col)
        {
            this.row = row;
            this.col = col;
            moves = 0;
        }

        public bool Equals(Index2D opponent)
        {
            return (row == opponent.row) && (col == opponent.col);
        }
    }

    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int width = int.Parse(Console.ReadLine()!);

            int[] srcRowCol = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int[] dstRowCol = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            Index2D srcIndex2D = new(srcRowCol[0], srcRowCol[1]);
            Index2D dstIndex2D = new(dstRowCol[0], dstRowCol[1]);

            bool[,] visited = new bool[width, width];
            Queue<Index2D> visitingQueue = new();

            visited[srcIndex2D.row, srcIndex2D.col] = true;
            visitingQueue.Enqueue(srcIndex2D);
http://boj.kr/b625c1c19e7b43d5b9cc20f20c0e0b47
            while (visitingQueue.Count > 0)
            {
                Index2D originIndex2D = visitingQueue.Dequeue();
                int originRow = originIndex2D.row;
                int originCol = originIndex2D.col;

                if (originIndex2D.Equals(dstIndex2D))
                {
                    output.AppendLine($"{originIndex2D.moves}");
                    break;
                }

                Index2D[] adjacentIndices2D =
                {
                    new(originRow - 2, originCol + 1),
                    new(originRow - 1, originCol + 2),
                    new(originRow + 1, originCol + 2),
                    new(originRow + 2, originCol + 1),
                    new(originRow + 2, originCol - 1),
                    new(originRow + 1, originCol - 2),
                    new(originRow - 1, originCol - 2),
                    new(originRow - 2, originCol - 1),
                };

                for (int j = 0; j < adjacentIndices2D.Length; ++j)
                {
                    Index2D adjacentIndex2D = adjacentIndices2D[j];
                    int adjacentRow = adjacentIndex2D.row;
                    int adjacentCol = adjacentIndex2D.col;

                    if (adjacentRow < 0 || adjacentRow > width - 1 ||
                        adjacentCol < 0 || adjacentCol > width - 1)
                        continue;

                    if (visited[adjacentRow, adjacentCol])
                        continue;

                    visited[adjacentRow, adjacentCol] = true;

                    adjacentIndex2D.moves = originIndex2D.moves + 1;
                    visitingQueue.Enqueue(adjacentIndex2D);
                }
            }
        }
        Console.Write(output);
    }
}