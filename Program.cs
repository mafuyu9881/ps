internal class Program
{
    private static void Main(string[] args)
    {
        const int HomeAttribute = 1;
        const int ChickenShopAttribute = 2;

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int citySize = tokens[0]; // [2, 50]
        int choosableChickenShopCount = tokens[1]; // [1, 13]

        LinkedList<int> homeIndices1D = new(); // [1, citySize*2]
        LinkedList<int> chickenShopIndices1D = new(); // [1, 13]
        for (int row = 0; row < citySize; ++row) // max tc = 50
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < citySize; ++col) // max tc = 50
            {
                int index1D = row * citySize + col;
                int attribute = tokens[col];

                if (attribute == HomeAttribute)
                {
                    homeIndices1D.AddLast(index1D);
                }

                if (attribute == ChickenShopAttribute)
                {
                    chickenShopIndices1D.AddLast(index1D);
                }
            }
        }

        int homeCount = homeIndices1D.Count;
        int chickenShopCount = chickenShopIndices1D.Count;

        int[] chickenShopIndex1DArray = new int[chickenShopCount];
        int writingIndex = 0;
        for (var node = chickenShopIndices1D.First; node != null; node = node.Next)
        {
            chickenShopIndex1DArray[writingIndex] = node.Value;
            ++writingIndex;
        }

        // arrays of minimum distances from chicken shop to home
        int[][] minDistanceArrays = new int[chickenShopCount][];
        for (int i = 0; i < minDistanceArrays.Length; ++i) // max tc = 13
        {
            int chickenShopIndex1D = chickenShopIndex1DArray[i];
            int chickenShopRow = chickenShopIndex1D / citySize;
            int chickenShopCol = chickenShopIndex1D % citySize;

            minDistanceArrays[i] = new int[homeCount];
            int minDistanceArrayWritingIndex = 0;
            // max tc = maxCitySize * 2 = 50 * 2
            for (var node = homeIndices1D.First; node != null; node = node.Next)
            {
                int homeIndex1D = node.Value;
                int homeRow = homeIndex1D / citySize;
                int homeCol = homeIndex1D % citySize;

                minDistanceArrays[i][minDistanceArrayWritingIndex] = Math.Abs(homeRow - chickenShopRow) + Math.Abs(homeCol - chickenShopCol);
                ++minDistanceArrayWritingIndex;
            }
        }

        LinkedList<int[]> combinations = new();
        // should put in n instead of chickenShopIndex1DArray
        Combinating(combinations, chickenShopCount, choosableChickenShopCount, new(), 0);

        const int InvalidChickenDistance = -1;
        int minimumChickenDistanceSum = InvalidChickenDistance;
        // max tc = 13C7 = 1716
        for (var node = combinations.First; node != null; node = node.Next)
        {
            int[] chosenChickenShopIDs = node.Value; // chicken shop ID is same with the index of chickenShopIndex1DArray

            int chickenDistanceSum = 0;
            for (int i = 0; i < homeCount; ++i)
            {
                int minimumChickenDistance = InvalidChickenDistance;
                for (int j = 0; j < chosenChickenShopIDs.Length; ++j)
                {
                    int chickenDistance = minDistanceArrays[chosenChickenShopIDs[j]][i];

                    if (minimumChickenDistance != InvalidChickenDistance &&
                        minimumChickenDistance < chickenDistance)
                        continue;
                    
                    minimumChickenDistance = chickenDistance;
                }
                chickenDistanceSum += minimumChickenDistance;
            }

            if (minimumChickenDistanceSum != InvalidChickenDistance &&
                minimumChickenDistanceSum < chickenDistanceSum)
                continue;

            minimumChickenDistanceSum = chickenDistanceSum;
        }
        Console.Write(minimumChickenDistanceSum);
    }

    private static void Combinating(LinkedList<int[]> combinations,
                                    int n,
                                    int r,
                                    LinkedList<int> history,
                                    int beginIndex)
    {
        for (int i = beginIndex; i < n; ++i)
        {
            history.AddLast(i);

            if (history.Count < r)
            {
                int remainNumberCount = n - (i + 1);
                int remainChoiceCount = r - history.Count;
                if (remainNumberCount >= remainChoiceCount)
                {
                    Combinating(combinations, n, r, history, i + 1);
                }
            }
            else
            {
                int[] combination = new int[r];
                int combinationWritingIndex = 0;
                for (var node = history.First; node != null; node = node.Next) // max tc = 13
                {
                    combination[combinationWritingIndex] = node.Value;
                    ++combinationWritingIndex;
                }
                combinations.AddLast(combination);
            }

            history.RemoveLast();
        }
    }
}