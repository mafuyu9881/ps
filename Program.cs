internal class Program
{
    private static void Main(string[] args)
    {
        long[] longTokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        int width = (int)longTokens[0]; // [1, 1'000'000'000]
        int height = (int)longTokens[1]; // [1, 1'000'000'000]
        long maxPiece = longTokens[2]; // [1, 1'000'000'000^2]

        int[] integerTokens = null!;

        int[] verticalSegments = null!;
        {
            int horizontalCutCount = int.Parse(Console.ReadLine()!); // [1, 1'100'000]

            verticalSegments = new int[horizontalCutCount + 1];

            integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int horizontalCutBegin = 0;
            for (int i = 0; i < horizontalCutCount; ++i) // max tc = 1'100'000
            {
                int horizontalCutEnd = integerTokens[i];

                verticalSegments[i] = horizontalCutEnd - horizontalCutBegin;

                horizontalCutBegin = horizontalCutEnd;
            }

            verticalSegments[horizontalCutCount] = height - horizontalCutBegin;

            Array.Sort(verticalSegments);
        }

        int[] horizontalSegments = null!;
        {
            int verticalCutCount = int.Parse(Console.ReadLine()!); // [1, 1'100'000]

            horizontalSegments = new int[verticalCutCount + 1];

            integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int verticalCutBegin = 0;
            for (int i = 0; i < verticalCutCount; ++i) // max tc = 1'100'000
            {
                int verticalCutEnd = integerTokens[i];

                horizontalSegments[i] = verticalCutEnd - verticalCutBegin;

                verticalCutBegin = verticalCutEnd;
            }

            horizontalSegments[verticalCutCount] = width - verticalCutBegin;

            Array.Sort(horizontalSegments);
        }

        long shareableCount = 0;
        for (int i = 0; i < verticalSegments.Length; ++i)
        {
            int verticalSegment = verticalSegments[i];

            int lo = 0 - 1;
            int hi = (horizontalSegments.Length - 1) + 1;
            while (lo < hi - 1)
            {
                int mid = (lo + hi) / 2;

                if (verticalSegment * (long)horizontalSegments[mid] > maxPiece)
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }
            }

            shareableCount += lo + 1;
        }
        Console.Write(shareableCount);
    }
}