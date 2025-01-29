internal class Program
{
    private static void Main(string[] args)
    {
        int[] integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = integerTokens[0] + 1; // [1, 100]
        int width = integerTokens[1] + 1; // [1, 100]

        const int Offsets = 3;
        int[] rowOffsets = new int[Offsets] { 0, -1, -1 };
        int[] colOffsets = new int[Offsets] { -1, 0, -1 };

        const int InvalidSquareSize = -1;
        int[] dp = new int[width * height];
        int maxSquareSize = 0;
        LinkedList<int> maxSquareIndices = new();
        for (int row = 1; row < height; ++row)
        {
            string stringToken = Console.ReadLine()!;
            for (int col = 1; col < width; ++col)
            {
                char charToken = stringToken[col - 1];
                if (charToken == '.')
                    continue;

                int index = row * width + col;

                int minSquareSize = InvalidSquareSize;
                for (int i = 0; i < Offsets; ++i)
                {
                    int adjRow = row + rowOffsets[i];
                    int adjCol = col + colOffsets[i];
                    int adjIndex = adjRow * width + adjCol;
                    if (minSquareSize != InvalidSquareSize && dp[adjIndex] >= minSquareSize)
                        continue;

                    minSquareSize = dp[adjIndex];
                }

                dp[index] = minSquareSize + 1;

                if (dp[index] > maxSquareSize)
                {
                    maxSquareSize = dp[index];
                    maxSquareIndices.Clear();
                }

                if (dp[index] >= maxSquareSize)
                {
                    maxSquareIndices.AddLast(index);
                }
            }
        }

        if (maxSquareIndices.Count < 2)
        {
            
        }
    }
}