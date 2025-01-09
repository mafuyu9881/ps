internal class Program
{
    private static int _boardSize;
    private static int _requiredQueens;
    private static bool[]? _lockedRows = null;
    private static bool[]? _lockedCols = null;
    private static bool[]? _lockedSlashDiagonal = null;
    private static bool[]? _lockedBackslashDiagonal = null;

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        _boardSize = n;
        _requiredQueens = n;

        _lockedRows = new bool[_boardSize];
        _lockedCols = new bool[_boardSize];
        _lockedSlashDiagonal = new bool[_boardSize * 2 - 1];
        _lockedBackslashDiagonal = new bool[_boardSize * 2 - 1];

        int output = 0;
        Solve(ref output, 0, 0);
        Console.Write(output);
    }

    private static void Solve(ref int cases, int beginIndex, int prevPlacedQueens)
    {
        for (int i = beginIndex; i < _boardSize * _boardSize; ++i)
        {
            int row = i / _boardSize;
            if (_lockedRows![row])
                continue;

            int col = i % _boardSize;
            if (_lockedCols![col])
                continue;

            int slashDiagonalIndex = col - row + (_boardSize - 1);
            if (_lockedSlashDiagonal![slashDiagonalIndex])
                continue;

            int backslashDiagonalIndex = col + row;
            if (_lockedBackslashDiagonal![backslashDiagonalIndex])
                continue;

            _lockedRows[row] = true;
            _lockedCols[col] = true;
            _lockedSlashDiagonal[slashDiagonalIndex] = true;
            _lockedBackslashDiagonal[backslashDiagonalIndex] = true;

            int currPlacedQueens = prevPlacedQueens + 1;
            if (currPlacedQueens < _requiredQueens)
            {
                Solve(ref cases, i + 1, currPlacedQueens);
            }
            else
            {
                ++cases;
            }
            
            _lockedRows[row] = false;
            _lockedCols[col] = false;
            _lockedSlashDiagonal[slashDiagonalIndex] = false;
            _lockedBackslashDiagonal[backslashDiagonalIndex] = false;
        }
    }
}