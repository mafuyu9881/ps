internal class Program
{
    private static void Main(string[] args)
    {
        int gridSize = int.Parse(Console.ReadLine()!);

        int[] map = new int[gridSize * gridSize];
        for (int row = 0; row < gridSize; ++row)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < gridSize; ++col)
            {
                map[row * gridSize + col] = tokens[col];
            }
        }

        int srcTailIndex1D = 0; // 0 * gridSize + 0
        int srcHeadIndex1D = 1; // 0 * gridSize + 1

        int[] visitedCount = new int[map.Length];
        // state 0 = horizontal, 1 = diagonal, 2 = vertical
        Queue<(int state, int headIndex1D)> visitingQueue = new();

        visitedCount[srcTailIndex1D] = 1;
        visitedCount[srcHeadIndex1D] = 1;
        visitingQueue.Enqueue(new(0, srcHeadIndex1D));

        int[] rowMovementOffsets = new int[] { 0, 1, 1 };
        int[] colMovementOffsets = new int[] { 1, 1, 0 };

        // the index of the first dimention means state
        int[][] rowTestOffsetsBundle = new int[3][];
        int[][] colTestOffsetsBundle = new int[3][];

        rowTestOffsetsBundle[0] = new int[] { 0 };
        colTestOffsetsBundle[0] = new int[] { 1 };

        rowTestOffsetsBundle[1] = new int[] { 0, 1, 1 };
        colTestOffsetsBundle[1] = new int[] { 1, 1, 0 };

        rowTestOffsetsBundle[2] = new int[] { 1 };
        colTestOffsetsBundle[2] = new int[] { 0 };

        while (visitingQueue.Count > 0)
        {
            var dequeuedElement = visitingQueue.Dequeue();
            int state = dequeuedElement.state;
            int headIndex1D = dequeuedElement.headIndex1D;
            int headRow = headIndex1D / gridSize;
            int headCol = headIndex1D % gridSize;

            int minNewState = Math.Max(0, state - 1);
            int maxNewState = Math.Min(state + 1, 2);

            for (int newState = minNewState; newState <= maxNewState; ++newState)
            {
                int[] rowTestOffsets = rowTestOffsetsBundle[newState];
                int[] colTestOffsets = colTestOffsetsBundle[newState];
                bool testSucceeded = true;
                for (int i = 0; i < rowTestOffsets.Length; ++i)
                {
                    int testingRow = headRow + rowTestOffsets[i];
                    if (testingRow < 0 || testingRow > gridSize - 1)
                    {
                        testSucceeded = false;
                        break;
                    }

                    int testingCol = headCol + colTestOffsets[i];
                    if (testingCol < 0 || testingCol > gridSize - 1)
                    {
                        testSucceeded = false;
                        break;
                    }

                    int testingIndex1D = testingRow * gridSize + testingCol;
                    if (map[testingIndex1D] == 1)
                    {
                        testSucceeded = false;
                        break;
                    }
                }

                if (testSucceeded == false)
                    continue;

                int newRow = headRow + rowMovementOffsets[newState];
                int newCol = headCol + colMovementOffsets[newState];
                int newHeadIndex1D = newRow * gridSize + newCol;

                ++visitedCount[newHeadIndex1D];
                visitingQueue.Enqueue(new(newState, newHeadIndex1D));
            }
        }

        Console.Write(visitedCount[(gridSize - 1) * gridSize + (gridSize - 1)]);
    }
}