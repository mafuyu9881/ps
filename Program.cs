internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int boardSize = tokens[0];
        int coins = tokens[1];


    }

    private static int[]? Solve(int baseIndex, int boardSize, int coins)
    {
        int[]? output = null;

        int cells = boardSize * boardSize;

        // board size is even
        if (boardSize % 2 == 0)
        {
            int blacks = cells / 2;
            int whites = blacks;

            if (coins < blacks)
                return output;

            coins -= blacks;
            if (coins % 2 == 1)
                return output;

            output = new int[2];
            output[0] = blacks + coins / 2;
            output[1] = coins / 2;
            return output;
        }
        else
        {
            int blacks = cells / 2 + 1;
            int whites = cells / 2 + 0;

            int[] squaresArr = new int[] { blacks, whites };

            for (int color0 = 0; color0 < squaresArr.Length; ++color0)
            {
                int color1 = color0 == 0 ? 1 : 0;

                int color0Squares = squaresArr[color0];

                if (coins < color0Squares)
                    continue;

                int remainCoins = coins - color0Squares;
                if ((remainCoins % cells) == 1)
                    continue;

                // base coins + 
                output[color0] += color0Squares; // base coins
                // piled up coins
                // remain coins
                 + remainCoins - (remainCoins % (cells * 2));
                break;
            }
        }

        // board size is odd
    }
}