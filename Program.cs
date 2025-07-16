class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [5, 1'000]

        const int InvalidIndex = -1;
        int barracksIndex = InvalidIndex;
        LinkedList<int> deserterIndices = new();

        int[] map = new int[n * n];
        for (int row = 0; row < n; ++row) // max tc = 1'000
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < n; ++col) // max tc = 1'000
            {
                int index = row * n + col;
                int attr = tokens[col];

                if (attr == -1)
                {
                    barracksIndex = index;
                }
                else if (attr == 0)
                {
                    deserterIndices.AddLast(index);
                }

                map[index] = tokens[col];
            }
        }

        const int InvalidCost = -1;

        int answerCost = InvalidCost;
        if (deserterIndices.Count > 0)
        {
            const int Offsets = 4;
            int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0 };
            int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1 };

            Func<int, int[]> ComputeMinCost = (int s) =>
            {
                int[] minCost = new int[map.Length];
                for (int i = 0; i < minCost.Length; ++i)
                {
                    minCost[i] = InvalidCost;
                }

                PriorityQueue<(int index, int cost), int> pq = new();

                minCost[s] = 0;
                pq.Enqueue((s, 0), 0);

                while (pq.Count > 0)
                {
                    var element = pq.Dequeue();
                    int index = element.index;
                    int row = index / n;
                    int col = index % n;
                    int cost = element.cost;

                    if (minCost[index] != InvalidCost && minCost[index] < cost)
                        continue;

                    for (int i = 0; i < Offsets; ++i)
                    {
                        int adjRow = row + RowOffsets[i];
                        if (adjRow < 0 || adjRow > n - 1)
                            continue;

                        int adjCol = col + ColOffsets[i];
                        if (adjCol < 0 || adjCol > n - 1)
                            continue;

                        int adjIndex = adjRow * n + adjCol;

                        int oldAdjCost = minCost[adjIndex];
                        int newAdjCost = cost + Math.Max(0, map[adjIndex]);
                        if (oldAdjCost != InvalidCost && oldAdjCost <= newAdjCost)
                            continue;

                        minCost[adjIndex] = newAdjCost;
                        pq.Enqueue((adjIndex, newAdjCost), newAdjCost);
                    }
                }

                return minCost;
            };

            int[] deserterIndexArr = deserterIndices.ToArray();
            Array.Sort(deserterIndexArr);

            int[][] minCosts = new int[n * n][];
            minCosts[barracksIndex] = ComputeMinCost(barracksIndex);
            for (int i = 0; i < deserterIndexArr.Length; ++i)
            {
                int deserterIndex = deserterIndexArr[i];
                minCosts[deserterIndex] = ComputeMinCost(deserterIndex);
            }

            do
            {
                int cost = 0;

                cost += minCosts[barracksIndex][deserterIndexArr[0]];

                for (int i = 0; i < deserterIndexArr.Length - 1; ++i)
                {
                    cost += minCosts[deserterIndexArr[i]][deserterIndexArr[i + 1]];
                }

                cost += minCosts[deserterIndexArr[deserterIndexArr.Length - 1]][barracksIndex];

                if (answerCost == InvalidCost || cost < answerCost)
                {
                    answerCost = cost;
                }
            }
            while (NextPermutation(deserterIndexArr));
        }
        answerCost = Math.Max(answerCost, 0);
        Console.Write(answerCost);
    }

    static bool NextPermutation(int[] arr)
    {
        // The index where the first monotonic increase occurs when scanning the array from its end
        int i = arr.Length - 2;
        while (i >= 0 && arr[i] >= arr[i + 1])
        {
            --i;
        }

        if (i < 0)
            return false;

        // The first index satisfying arr[i] < arr[j] when scanning the array from its end
        int j = arr.Length - 1;
        while (arr[j] <= arr[i])
        {
            --j;
        }

        (arr[i], arr[j]) = (arr[j], arr[i]);

        Array.Reverse(arr, i + 1, arr.Length - (i + 1));

        return true;
    }
}