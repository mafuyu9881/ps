internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // 1 ≤ m, n ≤ 500
        int m = tokens[1];
        int b = tokens[2]; // 0 ≤ b ≤ 6.4 × 10^7

        // 일일이 특정 셀에 블록이 몇 개인지 기록하고 찾아볼 필요 없음
        // 딱 처음에
        // 처음부터 보유 중인 블록의 개수
        // 디깅 할 블록의 개수
        // 라이징 할 블록의 개수
        // 를 기록해두고 거기서 더하고 빼면 될 것으로 보임
        const int InvalidHeight = -1; // 0 ≤ height ≤ 256
        int minimumHeight = InvalidHeight;
        int maximumHeight = InvalidHeight;
        int[] map = new int[n * m];
        for (int row = 0; row < n; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < m; ++ col)
            {
                int height = tokens[col];

                if (minimumHeight != InvalidHeight)
                {
                    minimumHeight = Math.Min(minimumHeight, height);
                }
                else
                {
                    minimumHeight = height;
                }

                if (maximumHeight != InvalidHeight)
                {
                    maximumHeight = Math.Max(maximumHeight, height);
                }
                else
                {
                    maximumHeight = height;
                }

                map[row * m + col] = height;
            }
        }

        const int InvalidCost = -1;
        int minimumCost = InvalidCost;
        PriorityQueue<int, int> minimumCostHeights = new();
        for (int desiredHeight = minimumHeight; desiredHeight <= maximumHeight; ++desiredHeight)
        {
            int holdingBlocks = b;
            int cost = 0;

            for (int j = 0; j < map.Length; ++j)
            {
                int height = map[j];

                if (height > desiredHeight)
                {
                    int diggedHeight = height - desiredHeight;
                    holdingBlocks += diggedHeight;
                    cost += diggedHeight * 2;
                }
                else if (height < desiredHeight)
                {
                    int risedHeight = desiredHeight - height;
                    holdingBlocks -= risedHeight;
                    cost += risedHeight;
                }
            }

            if (holdingBlocks < 0)
                break;

            if (minimumCost != InvalidCost && cost > minimumCost)
                continue;

            if (minimumCost == InvalidCost || cost < minimumCost)
            {
                minimumCost = cost;
                minimumCostHeights.Clear();
            }
            minimumCostHeights.Enqueue(desiredHeight, -desiredHeight);
        }
        Console.Write($"{minimumCost} {minimumCostHeights.Dequeue()}");
    }
}