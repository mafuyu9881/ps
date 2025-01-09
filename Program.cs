internal class Program
{
    private static int _boardSize;
    private static int _requiredQueens;
    private static bool[]? _lockedRows = null;
    private static bool[]? _lockedCols = null;
    private static bool[]? _lockedSlashDiagonal = null;
    private static bool[]? _lockedBackslashDiagonal = null;
    private static int _cases = 0;

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        _boardSize = n;
        _requiredQueens = n;

        _lockedRows = new bool[_boardSize];
        _lockedCols = new bool[_boardSize];
        _lockedSlashDiagonal = new bool[_boardSize * 2 - 1];
        _lockedBackslashDiagonal = new bool[_boardSize * 2 - 1];

        Solve(0);
        Console.Write(_cases);
    }

    private static void Solve(int currRow)
    {
        for (int col = 0; col < _boardSize; ++col)
        {
            if (_lockedRows![currRow])
                continue;

            if (_lockedCols![col])
                continue;

            int slashDiagonalIndex = col + currRow;
            if (_lockedSlashDiagonal![slashDiagonalIndex])
                continue;

            int backslashDiagonalIndex = col - currRow + (_boardSize - 1);
            if (_lockedBackslashDiagonal![backslashDiagonalIndex])
                continue;

            _lockedRows[currRow] = true;
            _lockedCols[col] = true;
            _lockedSlashDiagonal[slashDiagonalIndex] = true;
            _lockedBackslashDiagonal[backslashDiagonalIndex] = true;

            int nextRow = currRow + 1;
            if (nextRow < _requiredQueens)
            {
                Solve(nextRow);
            }
            else
            {
                ++_cases;
            }

            _lockedRows[currRow] = false;
            _lockedCols[col] = false;
            _lockedSlashDiagonal[slashDiagonalIndex] = false;
            _lockedBackslashDiagonal[backslashDiagonalIndex] = false;
        }
    }
}