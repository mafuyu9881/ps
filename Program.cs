using System.Text;
using Index2D = System.Tuple<int, int>;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();
        
        int height = int.Parse(tokens[0]);
        int width = int.Parse(tokens[1]);

        const int InvalidAttribute = -1;
        int[, ] map = new int[height, width];
        int[, ] distanceMap = new int[height, width];
        Index2D? objectiveIndex2D = null;

        for (int row = 0; row < height; ++row)
        {
            tokens = Console.ReadLine()!.Split();
            for (int col = 0; col < width; ++col)
            {
                int attribute = int.Parse(tokens[col]);

                if (attribute == 2)
                    objectiveIndex2D = new(row, col);

                map[row, col] = attribute;
                distanceMap[row, col] = InvalidAttribute;
            }
        }

        Queue<Index2D> visitingQueue = new();
        visitingQueue.Enqueue(objectiveIndex2D!);
        distanceMap[objectiveIndex2D!.Item1, objectiveIndex2D!.Item2] = 0;
        while (visitingQueue.Count > 0)
        {
            var originIndex2D = visitingQueue.Dequeue();
            int originRow = originIndex2D.Item1;
            int originCol = originIndex2D.Item2;

            Index2D[] adjacentIndices2D = new Index2D[]
            {
                new Index2D(originRow - 1, originCol),
                new Index2D(originRow, originCol - 1),
                new Index2D(originRow + 1, originCol),
                new Index2D(originRow, originCol + 1)
            };

            for (int i = 0; i < adjacentIndices2D.Length; ++i)
            {
                var adjacentIndex2D = adjacentIndices2D[i];
                int adjacentRow = adjacentIndex2D.Item1;
                int adjacentCol = adjacentIndex2D.Item2;

                if (adjacentRow < 0 || adjacentRow > height - 1)
                    continue;
                
                if (adjacentCol < 0 || adjacentCol > width - 1)
                    continue;

                if (objectiveIndex2D!.Item1 == adjacentRow &&
                    objectiveIndex2D!.Item2 == adjacentCol)
                    continue;

                if (map[adjacentRow, adjacentCol] == 0)
                    continue;

                if (distanceMap[adjacentRow, adjacentCol] != InvalidAttribute)
                    continue;

                visitingQueue.Enqueue(adjacentIndex2D);
                distanceMap[adjacentRow, adjacentCol] = distanceMap[originRow, originCol] + 1;
            }
        }

        StringBuilder output = new();
        for (int row = 0; row < height; ++row)
        {
            for (int col = 0; col < width; ++col)
            {
                if (map[row, col] != 0)
                {
                    output.Append($"{distanceMap[row, col]} ");
                }
                else
                {
                    output.Append($"0 ");
                }

            }
            output.AppendLine();
        }
        Console.Write(output);
    }
}