class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2^0, 2^10] = [1, 1'024]

        int[,] map = new int[n, n];
        for (int row = 0; row < n; ++row) // max tc = 2^10
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < n; ++col) // max tc = 2^10
            {
                map[row, col] = tokens[col];
            }
        }

        Func<int, int, int, int, int> Solve = null!;
        Solve = (int sRow, int sCol, int eRow, int eCol) =>
        {
            if (sRow == eRow && sCol == eCol)
            {
                return map[sRow, sCol];
            }
            else
            {
                int width = eCol - sCol;
                int height = eRow - sRow;

                int[] candidates = new int[4];
                candidates[0] = Solve(sRow + 0, sCol + 0, sRow + height / 2, sCol + width / 2);
                candidates[1] = Solve(sRow + 0, sCol + width / 2 + 1, sRow + height / 2, sCol + width);
                candidates[2] = Solve(sRow + height / 2 + 1, sCol + 0, sRow + height, sCol + width / 2);
                candidates[3] = Solve(sRow + height / 2 + 1, sCol + width / 2 + 1, sRow + height, sCol + width);
                Array.Sort(candidates);
                return candidates[1];
            }
        };

        Console.Write(Solve(0, 0, n - 1, n - 1));
    }
}