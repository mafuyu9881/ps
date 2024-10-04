// 시간 제한: 1초
// 메모리 제한: 256MB
// 2 ≤ M,N ≤ 1,000

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int width = int.Parse(tokens[0]);
        int height = int.Parse(tokens[1]);

        const int ripeTomatoAttribute = 1;
        const int unripeTomatoAttribute = 0;
        const int blankAttribute = -1;

        const int InvalidDays = -1;

        int[, ] map = new int[height, width];
        int[, ] daysTakenForRipeningMap = new int[height, width];
        LinkedList<Index2D> unripeTomatoes = new();
        Queue<Index2D> visitingQueue = new();
        for (int row = 0; row < height; ++row)
        {
            tokens = Console.ReadLine()!.Split();
            for (int col = 0; col < width; ++col)
            {
                int attribute = int.Parse(tokens[col]);

                map[row, col] = attribute;

                int days = InvalidDays;
                Index2D index2D = new Index2D(row, col);
                if (attribute == unripeTomatoAttribute)
                {
                    unripeTomatoes.AddLast(index2D);
                }
                else if (attribute == ripeTomatoAttribute)
                {
                    days = 0;
                    visitingQueue.Enqueue(index2D);
                }
                daysTakenForRipeningMap[row, col] = days;
            }
        }

        bool[, ] visited = new bool[height, width];
        int entireDaysTakenForRipening = 0;
        while (visitingQueue.Count > 0)
        {
            Index2D originIndex2D = visitingQueue.Dequeue();
            int originRow = originIndex2D.row;
            int originCol = originIndex2D.col;

            Index2D[] adjacentIndices2D = new Index2D[]
            {
                new(originRow - 1, originCol),
                new(originRow + 1, originCol),
                new(originRow, originCol - 1),
                new(originRow, originCol + 1),
            };

            for (int i = 0; i < adjacentIndices2D.Length; ++i)
            {
                Index2D adjacentIndex2D = adjacentIndices2D[i];
                int adjacentRow = adjacentIndex2D.row;
                int adjacentCol = adjacentIndex2D.col;

                if (adjacentRow < 0 || adjacentRow > height - 1)
                    continue;

                if (adjacentCol < 0 || adjacentCol > width - 1)
                    continue;

                if (visited[adjacentRow, adjacentCol])
                    continue;

                if (map[adjacentRow, adjacentCol] == blankAttribute)
                    continue;

                if (map[adjacentRow, adjacentCol] == ripeTomatoAttribute)
                    continue;

                int daysTakenForRipening = daysTakenForRipeningMap[originRow, originCol] + 1;
                if (daysTakenForRipening > entireDaysTakenForRipening)
                {
                    entireDaysTakenForRipening = daysTakenForRipening;
                }
                visited[adjacentRow, adjacentCol] = true;
                daysTakenForRipeningMap[adjacentRow, adjacentCol] = daysTakenForRipening;
                visitingQueue.Enqueue(adjacentIndex2D);
            }
        }

        for (var node = unripeTomatoes.First; node != null; node = node.Next)
        {
            Index2D index2D = node.Value;
            if (daysTakenForRipeningMap[index2D.row, index2D.col] == InvalidDays)
            {
                entireDaysTakenForRipening = -1;
                break;
            }
        }

        Console.Write(entireDaysTakenForRipening);
    }

    private struct Index2D
    {
        public int row;
        public int col;
        public Index2D(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}