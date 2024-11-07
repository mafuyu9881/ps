internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] trainWeights = new int[n];
        for (int i = 0; i < n; ++i)
        {
            trainWeights[i] = int.Parse(Console.ReadLine()!);
        }

        const int initialLastWrittenIndex = -1;
        int[] lis = new int[n];
        int lisLastWrittenIndex = initialLastWrittenIndex;
        int[] lds = new int[n];
        int ldsLastWrittenIndex = initialLastWrittenIndex;
        
        Func<int, int, bool> lowerBoundPredicate = delegate(int a, int b)
        {
            return a >= b;
        };
        Func<int, int, bool> upperBoundPredicate = delegate(int a, int b)
        {
            return a > b;
        };

        int output = 0;
        for (int i = 0; i < n; ++i)
        {
            int firstTrainWeight = trainWeights[i];
            lis[++lisLastWrittenIndex] = firstTrainWeight;
            lds[++ldsLastWrittenIndex] = firstTrainWeight;

            for (int j = i + 1; j < n; ++j)
            {
                int trainWeight = trainWeights[j];

                if (trainWeight > lis[lisLastWrittenIndex])
                {
                    lis[++lisLastWrittenIndex] = trainWeight;
                }
                else if (trainWeight > lis[0])
                {
                    int lowerBoundIndex = GetBound(new ReadOnlySpan<int>(lis, 1, lisLastWrittenIndex),
                                                   trainWeight,
                                                   lowerBoundPredicate,
                                                   true);
                    lis[lowerBoundIndex] = trainWeight;
                }

                if (trainWeight < lds[ldsLastWrittenIndex])
                {
                    lds[++ldsLastWrittenIndex] = trainWeight;
                }
                else if (trainWeight < lds[0])
                {
                    int upperBoundIndex = GetBound(new ReadOnlySpan<int>(lis, 1, ldsLastWrittenIndex),
                                                   trainWeight,
                                                   upperBoundPredicate,
                                                   false);
                    lds[upperBoundIndex] = trainWeight;
                }
            }

            int lisLength = lisLastWrittenIndex + 1;
            int ldsLength = ldsLastWrittenIndex + 1;
            output = Math.Max(output, lisLength + ldsLength - 1);
            lisLastWrittenIndex = initialLastWrittenIndex;
            ldsLastWrittenIndex = initialLastWrittenIndex;
        }
        Console.Write(output);
    }

    private static int GetBound(ReadOnlySpan<int> span,
                                int value,
                                Func<int, int, bool> predicate,
                                bool ascending)
    {
        int left = 0;
        int right = span.Length - 1;

        int output = -1;
        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (predicate(span[mid], value))
            {
                if (ascending) right = mid - 1;
                else left = mid + 1;

                output = mid;
            }
            else
            {
                if (ascending) left = mid + 1;
                else right = mid - 1;
            }
        }
        return output;
    }
}