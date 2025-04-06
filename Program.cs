using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int InvalidCost = -1;
        const int InvalidIndex = -1;

        const int Offsets = 4;
        int[] RowOffsets = new int[] { -1, 1, 0, 0 };
        int[] ColOffsets = new int[] { 0, 0, -1, 1 };

        const int BabyShark = 9;
        const int MinFish = 1;
        const int MaxFish = 6;

        Func<int, bool> IsBabyShark = (attr) => { return attr == BabyShark; };
        Func<int, bool> IsFish = (attr) => { return attr >= MinFish && attr <= MaxFish; };

        int n = int.Parse(Console.ReadLine()!); // [2, 20]
        
        Func<int, (int row, int col)> ConvertIndex1DTo2D = (int index) => { return (index / n, index % n); };
        Func<(int row, int col), int> ConvertIndex2DTo1D = ((int row, int col) index2D) => { return index2D.row * n + index2D.col; };

        int babySharkSize = 2;
        int babySharkSatiation = 0;
        int babySharkIndex = InvalidIndex;
        SortedSet<int> fishIndices = new();

        int[] map = new int[n * n];
        for (int row = 0; row < n; ++row) // max tc = 20
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < n; ++col) // max tc = 20
            {
                int attr = tokens[col];
                int index = ConvertIndex2DTo1D((row, col));

                if (IsBabyShark(attr))
                {
                    babySharkIndex = index;
                }
                
                if (IsFish(attr))
                {
                    fishIndices.Add(index);
                }

                map[index] = attr;
            }
        }

        int[] costs = new int[map.Length];
        
        Func<int, int, int, int> HigherPriority = (int preyIndex, int adjIndex, int adjCost) =>
        {
            if (preyIndex == InvalidIndex)
                return adjIndex;

            var babySharkIndex2D = ConvertIndex1DTo2D(babySharkIndex);
            var preyIndex2D = ConvertIndex1DTo2D(preyIndex);
            var adjIndex2D = ConvertIndex1DTo2D(adjIndex);

            int preyCost = costs[preyIndex];

            if (adjCost < preyCost)
            {
                return adjIndex;
            }
            if (adjCost == preyCost)
            {
                if (adjIndex2D.row < preyIndex2D.row)
                {
                    return adjIndex;
                }
                else if (adjIndex2D.row == preyIndex2D.row)
                {
                    if (adjIndex2D.col < preyIndex2D.col)
                    {
                        return adjIndex;
                    }
                    else if (adjIndex2D.col == preyIndex2D.col)
                    {
                        // can't happen
                        return adjIndex;
                    }
                    else
                    {
                        return preyIndex;
                    }
                }
                else
                {
                    return preyIndex;
                }
            }
            else
            {
                return preyIndex;
            }
        };

        int elapsedTime = 0;
        while (fishIndices.Count > 0) // max tc = 399
        {
            for (int i = 0; i < costs.Length; ++i) // max tc = 400
            {
                costs[i] = InvalidCost;
            }

            int preyIndex = InvalidIndex;

            Queue<int> frontier = new();

            costs[babySharkIndex] = 0;
            frontier.Enqueue(babySharkIndex);
            while (frontier.Count > 0) // max tc = 400
            {
                int index = frontier.Dequeue();
                var index2D = ConvertIndex1DTo2D(index);

                int adjCost = costs[index] + 1;

                for (int i = 0; i < Offsets; ++i)
                {
                    int adjRow = index2D.row + RowOffsets[i];
                    if (adjRow < 0 || adjRow > n - 1)
                        continue;

                    int adjCol = index2D.col + ColOffsets[i];
                    if (adjCol < 0 || adjCol > n - 1)
                        continue;

                    int adjIndex = adjRow * n + adjCol;
                    if (costs[adjIndex] != InvalidCost)
                        continue;

                    // in this context, adjAttr can't be BabyShark
                    int adjAttr = map[adjIndex];
                    if (IsFish(adjAttr) && adjAttr > babySharkSize)
                        continue;

                    if (IsFish(adjAttr) && adjAttr < babySharkSize)
                        preyIndex = HigherPriority(preyIndex, adjIndex, adjCost);

                    costs[adjIndex] = adjCost;
                    frontier.Enqueue(adjIndex);
                }
            }

            if (preyIndex != InvalidIndex)
            {
                elapsedTime += costs[preyIndex];

                map[babySharkIndex] = 0;
                map[preyIndex] = BabyShark;
                babySharkIndex = preyIndex;
                ++babySharkSatiation;

                if (babySharkSatiation >= babySharkSize)
                {
                    babySharkSatiation = 0;
                    ++babySharkSize;
                }
            }
            else
            {
                break;
            }
        }
        Console.Write(elapsedTime);
    }
}