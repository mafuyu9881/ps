internal class Program
{
    private const int InvalidPlayerID = 0;

    private static int[,] _board = new int[3, 3];

    private static (int row, int col)[][] _lines = new (int, int)[8][]
    {
        new (int, int)[] { (0, 0), (0, 1), (0, 2) },
        new (int, int)[] { (1, 0), (1, 1), (1, 2) },
        new (int, int)[] { (2, 0), (2, 1), (2, 2) },
        new (int, int)[] { (0, 0), (1, 0), (2, 0) },
        new (int, int)[] { (0, 1), (1, 1), (2, 1) },
        new (int, int)[] { (0, 2), (1, 2), (2, 2) },
        new (int, int)[] { (0, 0), (1, 1), (2, 2) },
        new (int, int)[] { (0, 2), (1, 1), (2, 0) },
    };

    private static void Main(string[] args)
    {
        int firstPlayerID = int.Parse(Console.ReadLine()!); // [1, 2]
        int secondPlayerID = (firstPlayerID == 2) ? 1 : 2; // [1, 2]

        int winnerPlayerID = InvalidPlayerID;
        for (int i = 0; i < 9; ++i) // tc = 9
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int row = tokens[0] - 1;
            int col = tokens[1] - 1;

            int currPlayerID = (i % 2 == 0) ? firstPlayerID : secondPlayerID;
            
            _board[row, col] = currPlayerID;

            for (int j = 0; j < _lines.Length; ++j) // tc = 8
            {
                (int row, int col)[] line = _lines[j];

                int row0 = line[0].row;
                int col0 = line[0].col;
                int row1 = line[1].row;
                int col1 = line[1].col;
                if (_board[row0, col0] != _board[row1, col1])
                    continue;

                int row2 = line[2].row;
                int col2 = line[2].col;
                if (_board[row1, col1] != _board[row2, col2])
                    continue;

                winnerPlayerID = _board[row0, col0];
                break;
            }

            if (winnerPlayerID != InvalidPlayerID)
                break;
        }
        Console.Write(winnerPlayerID);
    }
}